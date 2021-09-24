using System;
using System.Collections.Generic;
using System.Linq;
using BebidasStore.DbContextos;
using BebidasStore.Entidades;

namespace BebidasStore.Repositorios
{
    public class MarcasRepositorio : IMarcasRepositorio
    {
        private readonly BebidasStoreContexto _contexto;

        public MarcasRepositorio(BebidasStoreContexto contexto)
        {
            _contexto = contexto ?? throw new ArgumentNullException(nameof(contexto));
        }

        public void AdicionarMarca(Marca marca)
        {
            if (marca == null)
                throw new ArgumentNullException(nameof(marca));

            marca.Id = Guid.NewGuid();

            foreach (var bebida in marca.Bebidas)
            {
                bebida.Id = Guid.NewGuid();
            }

            _contexto.Marcas.Add(marca);
        }

        public Marca ObterMarcaPorId(Guid marcaId)
        {
            if (marcaId == Guid.Empty)
                throw new ArgumentNullException(nameof(marcaId));

            return _contexto.Marcas.FirstOrDefault(m => m.Id == marcaId);
        }

        public IEnumerable<Marca> ObterMarcas()
        {
            return _contexto.Marcas.ToList<Marca>();
        }

        public void AtualizarMarca(Marca marca)
        {
            //implementar código
        }

        public void RemoverMarca(Marca marca)
        {
            if (marca == null)
                throw new ArgumentNullException(nameof(marca));

            _contexto.Marcas.Remove(marca);
        }

        public bool MarcaExiste(Guid marcaId)
        {
            if (marcaId == Guid.Empty)
                throw new ArgumentNullException(nameof(marcaId));
            return _contexto.Marcas.Any(m => m.Id == marcaId);
        }

        public bool Salvar()
        {
            return (_contexto.SaveChanges() >= 0);
        }
    }
}
