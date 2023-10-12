using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class File
    {
        [Key]
        public Guid Id { get; set; }

        [DisplayName("Nome")]
        [Required(ErrorMessage = "O nome é obrigatório")]
        public string Name { get; set; }

        [DisplayName("Caminho")]
        [Required(ErrorMessage = "O caminho é obrigatório")]
        public string Path { get; set; }

        [DisplayName("Documento")]
        [Required(ErrorMessage = "O documento é obrigatório")]
        public Guid DocumentId { get; set; }

        [DisplayName("Criado em")]
        public DateTime CreatedAt { get; set; }

        public Document Document { get; set; }
    }
}
