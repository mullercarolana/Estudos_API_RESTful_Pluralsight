using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BebidasStore.Entidades
{
    public class Marca
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(60)]
        public string Nome { get; set; }

        [Required]
        [MaxLength(100)]
        public string Industria { get; set; }

        public ICollection<Bebida> Bebidas { get; set; } = new List<Bebida>();
    }
}
