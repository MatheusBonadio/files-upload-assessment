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
        public string Name { get; set; }

        [DisplayName("Versão")]
        [Required(ErrorMessage = "A versão é obrigatória")]
        public int Version { get; set; }

        [DisplayName("Extensão")]
        public string Extension { get; set; }

        [DisplayName("Documento")]
        [Required(ErrorMessage = "O documento é obrigatório")]
        public Guid DocumentId { get; set; }

        [DisplayName("Criado em")]
        public DateTime CreatedAt { get; set; }
    }
}
