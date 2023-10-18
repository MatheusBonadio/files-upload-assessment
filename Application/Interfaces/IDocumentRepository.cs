using System;
using System.Collections.Generic;

using Domain.Entities;

namespace Application.Interfaces
{
    public interface IDocumentRepository
    {
        public List<Document> List();

        public Document Create(Document document);

        public Document Update(Document document);

        public void Delete(Guid id);

        public Document FindById(Guid id);

        public Document FindByTitle(string title);

        public bool TitleExists(Document document);
    }
}