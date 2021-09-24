using System;
using BebidasStore.Entidades;
using Microsoft.EntityFrameworkCore;

namespace BebidasStore.DbContextos
{
    public class BebidasStoreContexto : DbContext
    {
        public BebidasStoreContexto(DbContextOptions<BebidasStoreContexto> options)
            : base(options)
        { 
        }

        public DbSet<Bebida> Bebidas { get; set; }
        public DbSet<Marca> Marcas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Marca>().HasData(
                new Marca()
                {
                    Id = Guid.Parse("d28888e9-2ba9-473a-a40f-e38cb54f9b35"),
                    Nome = "Guaraná Antarctica",
                    Industria = "Pepsico"
                },
                new Marca()
                {
                    Id = Guid.Parse("da2fd609-d754-4feb-8acd-c4f9ff13ba96"),
                    Nome = "H20",
                    Industria = "Pepsico"
                },
                new Marca()
                {
                    Id = Guid.Parse("dea22bcd-a2fa-40a0-b559-d4adcc981620"),
                    Nome = "Pepsi",
                    Industria = "Pepsico"
                },
                new Marca()
                {
                    Id = Guid.Parse("738ab439-da32-4ac5-9fc1-d614ecb0a3a5"),
                    Nome = "Gatorade",
                    Industria = "Pepsico"
                });

            modelBuilder.Entity<Bebida>().HasData(
                new Bebida()
                {
                    Id = Guid.Parse("375c6026-2679-40e3-aa95-141745dcd409"),
                    MarcaId = Guid.Parse("d28888e9-2ba9-473a-a40f-e38cb54f9b35"),
                    Nome = "Guaraná Zero Açúcar",
                    Descricao = "Bebida gasificada sabor fruta guaraná sem adição de açúcar."
                },
                new Bebida()
                {
                    Id = Guid.Parse("1cfce5f9-c095-4bc7-9bb8-f0f7d81a5909"),
                    MarcaId = Guid.Parse("d28888e9-2ba9-473a-a40f-e38cb54f9b35"),
                    Nome = "Guaraná",
                    Descricao = "Bebida gasificada sabor fruta guaraná."
                },
                new Bebida()
                {
                    Id = Guid.Parse("abeb730f-3d6c-441c-85c5-480b85b960c5"),
                    MarcaId = Guid.Parse("da2fd609-d754-4feb-8acd-c4f9ff13ba96"),
                    Nome = "H20 Laranja & Limão",
                    Descricao = "Água gasificada sabor laranja & limão com baixa caloria."
                },
                new Bebida()
                {
                    Id = Guid.Parse("5dbdf830-9194-40df-a859-0d9289bed798"),
                    MarcaId = Guid.Parse("da2fd609-d754-4feb-8acd-c4f9ff13ba96"),
                    Nome = "H20 Uva",
                    Descricao = "Água gasificada sabor uva com baixa caloria."
                },
                new Bebida()
                {
                    Id = Guid.Parse("eb1b5d4f-5990-4015-bc48-98c0a322490c"),
                    MarcaId = Guid.Parse("dea22bcd-a2fa-40a0-b559-d4adcc981620"),
                    Nome = "Pepsi Zero Açúcar",
                    Descricao = "Bebida gasificada sem adição de açúcar."
                },
                new Bebida()
                {
                    Id = Guid.Parse("79e2aa60-4cc8-46d7-bac6-cf303251a981"),
                    MarcaId = Guid.Parse("dea22bcd-a2fa-40a0-b559-d4adcc981620"),
                    Nome = "Pepsi",
                    Descricao = "Bebida gasificada."
                },
                new Bebida()
                {
                    Id = Guid.Parse("18c1cf49-3de2-44c1-8a7e-0d54fd7aade0"),
                    MarcaId = Guid.Parse("738ab439-da32-4ac5-9fc1-d614ecb0a3a5"),
                    Nome = "Gatorade Limão",
                    Descricao = "Isotonico sabor limão."
                },
                new Bebida()
                {
                    Id = Guid.Parse("ad005f9d-a407-4015-a07b-78242a9d0a25"),
                    MarcaId = Guid.Parse("738ab439-da32-4ac5-9fc1-d614ecb0a3a5"),
                    Nome = "Gatorade Maracujá",
                    Descricao = "Isotonico sabor maracujá."
                });

            base.OnModelCreating(modelBuilder);
        }
    }
}
