using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Document
    {
        [Key]
        public Guid Id { get; set; }

        [DisplayName("Título")]
        [Required(ErrorMessage = "O título é obrigatório")]
        [MaxLength(100)]
        public string Title { get; set; }

        [DisplayName("Descrição")]
        [Required(ErrorMessage = "A descrição é obrigatória")]
        [MaxLength(2000)]
        public string Description { get; set; }

        [DisplayName("Versão")]
        [Required(ErrorMessage = "A versão é obrigatória")]
        public int Version { get; set; }

        [DisplayName("Criado em")]
        public DateTime CreatedAt { get; set; }

        [DisplayName("Atualizado em")]
        public DateTime UpdatedAt { get; set; }

        [DisplayName("Arquivos")]
        public IList<File> Files { get; set; }
    }
}
