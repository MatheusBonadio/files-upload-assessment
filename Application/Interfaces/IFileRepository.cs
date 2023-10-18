using System;

using Domain.Entities;

namespace Application.Interfaces
{
    public interface IFileRepository
    {
        public File Create(File file);

        public void Delete(Guid id);

        public File FindById(Guid id);
    }
}