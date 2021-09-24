using System;
using System.Collections.Generic;

namespace BebidasStore.DTO
{
    public class MarcaParaManipulacaoDTO
    {
        public string Nome { get; set; }
        public string Industria { get; set; }

        public ICollection<BebidaParaCriacaoDTO> Bebidas { get; set; } = new List<BebidaParaCriacaoDTO>();
    }
}
