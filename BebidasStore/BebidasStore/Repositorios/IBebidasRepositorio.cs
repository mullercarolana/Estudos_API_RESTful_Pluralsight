using System;
using System.Collections.Generic;
using BebidasStore.Entidades;

namespace BebidasStore.Repositorios
{
    public interface IBebidasRepositorio
    {
        void AdicionarBebida(Guid marcaId, Bebida bebida);
        IEnumerable<Bebida> ObterBebidas(Guid marcaId);
        Bebida ObterBebidaPorId(Guid bebidaId, Guid marcaId);
        void AtualizarBebida(Bebida bebida);
        void RemoverBebida(Bebida bebida);
        bool Salvar();
    }
}
