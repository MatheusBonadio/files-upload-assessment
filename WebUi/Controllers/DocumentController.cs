using Infra;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using Newtonsoft.Json;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace WebUI.Controllers
{
    public class DocumentController : Controller
    {

        readonly private ApplicationDbContext _db;
        readonly private string _path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/files");

        public DocumentController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Document> documents = _db.Documents
                .OrderByDescending(d => d.UpdatedAt)
                .ThenByDescending(d => d.CreatedAt)
                .Include(d => d.Files)
                .ToList();

            foreach (var document in documents)
            {
                var lastFile = document.Files.OrderByDescending(f => f.CreatedAt).FirstOrDefault();
                document.Files.Clear();

                if (lastFile != null)
                    document.Files.Add(lastFile);
            }
            return View(documents);
        }

        public IActionResult Create()
        {
            return View();
        }

        public async Task<IActionResult> Update(Document documentId)
        {
            if (documentId == null)
                return NotFound();

            var document = _db.Documents.Include(d => d.Files).FirstOrDefault(f => f.Id == documentId.Id);

            var lastFile = document.Files.OrderByDescending(f => f.CreatedAt).FirstOrDefault();
            document.Files.Clear();

            if (lastFile != null)
                document.Files.Add(lastFile);

            if (document == null)
                return NotFound();

            return View(document);
        }

        public ActionResult Details(Document documentId)
        {
            if (documentId == null)
                return NotFound();

            var document = _db.Documents.Include(d => d.Files).FirstOrDefault(f => f.Id == documentId.Id);
            document.Files = document.Files.OrderByDescending(f => f.CreatedAt).ToList();

            if (document == null)
                return NotFound();

            return View(document);
        }

        [HttpPost]
        public async Task<IActionResult> Create(IFormFile file, Document document)
        {
            var documentId = Guid.NewGuid();

            var newDocument = new Document
            {
                Id = documentId,
                Title = document.Title,
                Description = document.Description,
                Files = new List<Domain.Entities.File>
                {
                    new Domain.Entities.File
                    {
                        Id = Guid.NewGuid(),
                        Name = document.Files.First().Name,
                        Extension = Path.GetExtension(file.FileName),
                        CreatedAt = DateTime.Now,
                        DocumentId = documentId,
                    }
                },
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
            };

            if (UploadFile(file, newDocument.Files.First().Id))
            {
                _db.Documents.Add(newDocument);
                await _db.SaveChangesAsync();
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Update(IFormFile file, Document document)
        {
            if (document == null)
                return NotFound();

            document.UpdatedAt = DateTime.Now;

            if (file != null)
            {
                var newFile = new Domain.Entities.File
                {
                    Id = Guid.NewGuid(),
                    Name = document.Files.First().Name,
                    Version = document.Files.First().Version + 1,
                    Extension = Path.GetExtension(file.FileName),
                    CreatedAt = DateTime.Now,
                    DocumentId = document.Id,
                };

                if (UploadFile(file, newFile.Id))
                {
                    document.Files.Clear();
                    _db.Files.Add(newFile);
                }
            }

            _db.Documents.Update(document);
            _db.SaveChanges();

            return View();
        }

        public async Task<IActionResult> Delete(Document documentId)
        {
            var document = _db.Documents.Include(d => d.Files).FirstOrDefault(d => d.Id == documentId.Id);

            foreach (var file in document.Files)
            {
                var filePath = Path.Combine(_path, file.Id + file.Extension);
                if (System.IO.File.Exists(filePath))
                    System.IO.File.Delete(filePath);
            }

            _db.Documents.Remove(document);
            _db.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        private bool UploadFile(IFormFile file, Guid fileId)
        {
            // string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/files");

            try
            {
                if (!Directory.Exists(_path))
                    Directory.CreateDirectory(_path);

                using var stream = new FileStream(Path.Combine(_path, fileId + Path.GetExtension(file.FileName)), FileMode.Create);
                file.CopyTo(stream);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
                return false;
            }

            return true;
        }

        public IActionResult DownloadFile(Domain.Entities.File fileId)
        {
            var file = _db.Files.FirstOrDefault(f => f.Id == fileId.Id);
            var filePath = Path.Combine(_path, file.Id + file.Extension);

            if (System.IO.File.Exists(filePath))
            {
                byte[] fileBytes = System.IO.File.ReadAllBytes(filePath);

                return File(fileBytes, "application/force-download", file.Name + file.Extension);
            }
            else
            {
                return NotFound();
            }
        }
    }
}
