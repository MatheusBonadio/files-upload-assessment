using System;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infra
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() { }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Document> Documents { get; set; }

        public DbSet<File> Files { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<File>()
            .Property(d => d.Version)
            .HasDefaultValue(0);

            // modelBuilder.Entity<Document>()
            //     .HasQueryFilter(d => d.DeletedAt == null);

            modelBuilder.Seed();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connection = "" +
                "Integrated Security=SSPI;" +
                "Persist Security Info=False;" +
                "Data Source=LOCALHOST\\SQLEXPRESS;" +
                "Initial Catalog=files_upload;";

            optionsBuilder.UseSqlServer(connection);
        }
    }
}
