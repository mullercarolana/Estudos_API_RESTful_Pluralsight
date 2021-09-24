using System;

namespace BebidasStore.DTO
{
    public class BebidaDTO
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public Guid MarcaId { get; set; }
    }
}
