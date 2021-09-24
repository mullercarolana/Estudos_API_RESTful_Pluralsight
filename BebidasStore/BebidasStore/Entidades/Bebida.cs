using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BebidasStore.Entidades
{
    public class Bebida
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Nome { get; set; }

        [Required]
        [MaxLength(100)]
        public string Descricao { get; set; }

        [ForeignKey("MarcaId")]
        public Marca Marca { get; set; }
        public Guid MarcaId { get; set; }
    }
}
