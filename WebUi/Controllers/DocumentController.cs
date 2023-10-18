using System;
using System.IO;
using System.Linq;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

using Domain.Entities;
using Application.Interfaces;
using Newtonsoft.Json;

namespace WebUI.Controllers
{
    public class DocumentController : Controller
    {

        private readonly IDocumentRepository _documentRepository;
        private readonly IFileRepository _fileRepository;
        private readonly string _path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/files");

        public DocumentController(IDocumentRepository documentRepository, IFileRepository fileRepository)
        {
            _documentRepository = documentRepository;
            _fileRepository = fileRepository;
        }

        public IActionResult Index()
        {
            return View(_documentRepository.List());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(IFormFile file, Document document)
        {
            if (ModelState.IsValid == false)
                return View();

            if (_documentRepository.TitleExists(document))
                return RedirectToAction(nameof(Index));

            var documentId = Guid.NewGuid();

            var newDocument = new Document
            {
                Id = documentId,
                Title = document.Title,
                Description = document.Description,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
            };

            var newFile = new Domain.Entities.File
            {
                Id = Guid.NewGuid(),
                Name = document.Files.First().Name,
                Extension = Path.GetExtension(file.FileName),
                CreatedAt = DateTime.Now,
                DocumentId = documentId,
            };

            if (UploadFile(file, newFile.Id))
            {
                _documentRepository.Create(newDocument);
                _fileRepository.Create(newFile);
            }

            return View();
        }

        public IActionResult Update(Guid documentId)
        {
            if (documentId == Guid.Empty)
                return RedirectToAction(nameof(Index));

            var document = _documentRepository.FindById(documentId);

            if (document == null)
                return RedirectToAction(nameof(Index));

            return View(document);
        }

        [HttpPost]
        public IActionResult Update(IFormFile file, Document document)
        {
            if (ModelState.IsValid == false)
                return View();

            if (_documentRepository.TitleExists(document))
                return RedirectToAction(nameof(Index));

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
                    _fileRepository.Create(newFile);
                }
            }

            _documentRepository.Update(document);

            return RedirectToAction(nameof(Update));
        }

        public IActionResult Delete(Guid documentId)
        {
            var document = _documentRepository.FindById(documentId);

            foreach (var file in document.Files)
            {
                var filePath = Path.Combine(_path, file.Id + file.Extension);

                if (System.IO.File.Exists(filePath))
                    System.IO.File.Delete(filePath);
            }

            _documentRepository.Delete(documentId);

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Details(Guid documentId)
        {
            if (documentId == Guid.Empty)
                return RedirectToAction(nameof(Index));

            var document = _documentRepository.FindById(documentId);

            if (document == null)
                return RedirectToAction(nameof(Index));

            return View(document);
        }

        private bool UploadFile(IFormFile file, Guid fileId)
        {
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

        public IActionResult DownloadFile(Guid fileId)
        {
            var file = _fileRepository.FindById(fileId);
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
