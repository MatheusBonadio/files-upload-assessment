using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

using Infra;
using Domain.Entities;
using Application.Interfaces;

namespace Application.Repositories
{
    public class DocumentRepository : IDocumentRepository
    {
        private readonly ApplicationDbContext _context;

        public DocumentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Document> List()
        {
            var documents = _context.Documents
                .OrderByDescending(d => d.UpdatedAt)
                .ThenByDescending(d => d.CreatedAt)
                .Include(d => d.Files)
                .ToList();

            return OrderFilesByCreation(documents);
        }

        public Document Create(Document document)
        {
            if (document == null) return null;

            _context.Documents.Add(document);
            _context.SaveChanges();

            return document;
        }

        public Document Update(Document document)
        {
            if (document == null) return null;

            document.UpdatedAt = DateTime.Now;
            _context.Documents.Update(document);
            _context.SaveChanges();

            return document;
        }

        public void Delete(Guid id)
        {
            var document = FindById(id);

            if (document == null) return;

            _context.Documents.Remove(document);
            _context.SaveChanges();
        }

        public Document FindById(Guid id)
        {
            var document = _context.Documents
                .Include(d => d.Files)
                .AsNoTracking()
                .FirstOrDefault(d => d.Id == id);

            if (document == null) return null;

            return OrderFilesByCreation(new List<Document> { document }).FirstOrDefault();
        }

        public Document FindByTitle(string title)
        {
            var document = _context.Documents
                .AsNoTracking()
                .FirstOrDefault(d => d.Title == title);

            if (document == null) return null;

            return document;
        }

        public bool TitleExists(Document document)
        {
            var documentExists = FindByTitle(document.Title);

            if (documentExists == null)
                return false;

            if (documentExists.Id == document.Id)
                return false;

            return true;
        }

        private List<Document> OrderFilesByCreation(List<Document> documents)
        {
            documents.ForEach(document =>
            {
                var files = document.Files.OrderByDescending(f => f.CreatedAt).ToList();
                document.Files.Clear();

                if (files != null)
                    document.Files = files;
            });

            return documents;
        }
    }
}