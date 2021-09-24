using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BebidasStore.Migrations
{
    public partial class PrimeiraMigracao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Marcas",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>(maxLength: 60, nullable: false),
                    Industria = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Marcas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Bebidas",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>(maxLength: 50, nullable: false),
                    Descricao = table.Column<string>(maxLength: 100, nullable: false),
                    MarcaId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bebidas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bebidas_Marcas_MarcaId",
                        column: x => x.MarcaId,
                        principalTable: "Marcas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Marcas",
                columns: new[] { "Id", "Industria", "Nome" },
                values: new object[,]
                {
                    { new Guid("d28888e9-2ba9-473a-a40f-e38cb54f9b35"), "Pepsico", "Guaraná Antarctica" },
                    { new Guid("da2fd609-d754-4feb-8acd-c4f9ff13ba96"), "Pepsico", "H20" },
                    { new Guid("dea22bcd-a2fa-40a0-b559-d4adcc981620"), "Pepsico", "Pepsi" },
                    { new Guid("738ab439-da32-4ac5-9fc1-d614ecb0a3a5"), "Pepsico", "Gatorade" }
                });

            migrationBuilder.InsertData(
                table: "Bebidas",
                columns: new[] { "Id", "Descricao", "MarcaId", "Nome" },
                values: new object[,]
                {
                    { new Guid("375c6026-2679-40e3-aa95-141745dcd409"), "Bebida gasificada sabor fruta guaraná sem adição de açúcar.", new Guid("d28888e9-2ba9-473a-a40f-e38cb54f9b35"), "Guaraná Zero Açúcar" },
                    { new Guid("1cfce5f9-c095-4bc7-9bb8-f0f7d81a5909"), "Bebida gasificada sabor fruta guaraná.", new Guid("d28888e9-2ba9-473a-a40f-e38cb54f9b35"), "Guaraná" },
                    { new Guid("abeb730f-3d6c-441c-85c5-480b85b960c5"), "Água gasificada sabor laranja & limão com baixa caloria.", new Guid("da2fd609-d754-4feb-8acd-c4f9ff13ba96"), "H20 Laranja & Limão" },
                    { new Guid("5dbdf830-9194-40df-a859-0d9289bed798"), "Água gasificada sabor uva com baixa caloria.", new Guid("da2fd609-d754-4feb-8acd-c4f9ff13ba96"), "H20 Uva" },
                    { new Guid("eb1b5d4f-5990-4015-bc48-98c0a322490c"), "Bebida gasificada sem adição de açúcar.", new Guid("dea22bcd-a2fa-40a0-b559-d4adcc981620"), "Pepsi Zero Açúcar" },
                    { new Guid("79e2aa60-4cc8-46d7-bac6-cf303251a981"), "Bebida gasificada.", new Guid("dea22bcd-a2fa-40a0-b559-d4adcc981620"), "Pepsi" },
                    { new Guid("18c1cf49-3de2-44c1-8a7e-0d54fd7aade0"), "Isotonico sabor limão.", new Guid("738ab439-da32-4ac5-9fc1-d614ecb0a3a5"), "Gatorade Limão" },
                    { new Guid("ad005f9d-a407-4015-a07b-78242a9d0a25"), "Isotonico sabor maracujá.", new Guid("738ab439-da32-4ac5-9fc1-d614ecb0a3a5"), "Gatorade Maracujá" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bebidas_MarcaId",
                table: "Bebidas",
                column: "MarcaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bebidas");

            migrationBuilder.DropTable(
                name: "Marcas");
        }
    }
}
