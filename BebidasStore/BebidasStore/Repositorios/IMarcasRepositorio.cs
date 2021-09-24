using System;
using System.Collections.Generic;
using BebidasStore.Entidades;

namespace BebidasStore.Repositorios
{
    public interface IMarcasRepositorio
    {
        void AdicionarMarca(Marca marca);
        IEnumerable<Marca> ObterMarcas();
        Marca ObterMarcaPorId(Guid marcaId);
        void AtualizarMarca(Marca marca);
        void RemoverMarca(Marca marca);
        bool MarcaExiste(Guid marcaId);
        bool Salvar();
    }
}