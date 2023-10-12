using System;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

public static class ModelBuilderExtensions
{
    public static void Seed(this ModelBuilder modelBuilder)
    {
        var documentId = Guid.NewGuid();

        modelBuilder.Entity<Document>()
            .Property(p => p.Version)
            .HasDefaultValue(0);

        modelBuilder.Entity<Document>().HasData(
            new Document
            {
                Id = documentId,
                Title = "Título 1",
                Description = "Descrição 1",
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            }
        );

        modelBuilder.Entity<File>().HasData(
            new File
            {
                Id = Guid.NewGuid(),
                Name = "Name 1",
                Path = "Path 1",
                CreatedAt = DateTime.Now,
                DocumentId = documentId,
            },
            new File
            {
                Id = Guid.NewGuid(),
                Name = "Name 2",
                Path = "Path 2",
                CreatedAt = DateTime.Now,
                DocumentId = documentId,
            }
        );
    }
}