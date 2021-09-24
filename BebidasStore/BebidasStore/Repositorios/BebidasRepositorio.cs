using System;
using System.Collections.Generic;
using System.Linq;
using BebidasStore.DbContextos;
using BebidasStore.Entidades;

namespace BebidasStore.Repositorios
{
    public class BebidasRepositorio : IBebidasRepositorio
    {
        private readonly BebidasStoreContexto _contexto;

        public BebidasRepositorio(BebidasStoreContexto contexto)
        {
            _contexto = contexto ?? throw new ArgumentNullException(nameof(contexto));
        }

        public void AdicionarBebida(Guid marcaId, Bebida bebida)
        {
            if (marcaId == Guid.Empty)
                throw new ArgumentNullException(nameof(marcaId));

            if (bebida == null)
                throw new ArgumentNullException(nameof(bebida));

            bebida.MarcaId = marcaId;
            _contexto.Add(bebida);
        }

        public Bebida ObterBebidaPorId(Guid marcaId, Guid bebidaId)
        {
            if (marcaId == Guid.Empty)
                throw new ArgumentNullException(nameof(marcaId));

            if (bebidaId == Guid.Empty)
                throw new ArgumentNullException(nameof(bebidaId));

            return _contexto.Bebidas.Where(b => b.MarcaId == marcaId && b.Id == bebidaId).FirstOrDefault();
        }

        public IEnumerable<Bebida> ObterBebidas(Guid marcaId)
        {
            if (marcaId == Guid.Empty)
                throw new ArgumentNullException(nameof(marcaId));
            return _contexto.Bebidas
                .Where(b => b.MarcaId == marcaId)
                .OrderBy(b => b.Nome).ToList();
        }

        public void AtualizarBebida(Bebida bebida)
        {
            //implementar código
        }

        public void RemoverBebida(Bebida bebida)
        {
            _contexto.Bebidas.Remove(bebida);
        }

        public bool Salvar()
        {
            return (_contexto.SaveChanges() >= 0);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                //descarta recursos quando necessário
            }
        }
    }
}
