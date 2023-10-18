using System;
using System.Linq;

using Infra;
using Domain.Entities;
using Application.Interfaces;

namespace Application.Repositories
{
    public class FileRepository : IFileRepository
    {
        private readonly ApplicationDbContext _context;

        public FileRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public File Create(File file)
        {
            if (file == null) return null;

            _context.Files.Add(file);
            _context.SaveChanges();

            return file;
        }

        public void Delete(Guid id)
        {
            var file = _context.Files.First(d => d.Id == id);

            if (file == null) return;

            _context.Files.Remove(file);
            _context.SaveChanges();
        }

        public File FindById(Guid id)
        {
            var file = _context.Files.FirstOrDefault(d => d.Id == id);

            if (file == null) return null;

            return file;
        }
    }
}