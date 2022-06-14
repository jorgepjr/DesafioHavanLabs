using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace WebApi.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(nullable: true),
                    Documento = table.Column<string>(nullable: true),
                    Cep = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Produtos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(nullable: true),
                    Codigo = table.Column<string>(nullable: true),
                    Preco = table.Column<decimal>(nullable: false),
                    Estoque = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produtos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PreVendas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ClienteId = table.Column<int>(nullable: false),
                    DataDeRegistro = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PreVendas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PreVendas_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ItensPreVenda",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ProdutoId = table.Column<int>(nullable: false),
                    Quantidade = table.Column<int>(nullable: false),
                    PrecoUnitario = table.Column<decimal>(nullable: false),
                    PreVendaId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItensPreVenda", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItensPreVenda_PreVendas_PreVendaId",
                        column: x => x.PreVendaId,
                        principalTable: "PreVendas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ItensPreVenda_Produtos_ProdutoId",
                        column: x => x.ProdutoId,
                        principalTable: "Produtos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ItensPreVenda_PreVendaId",
                table: "ItensPreVenda",
                column: "PreVendaId");

            migrationBuilder.CreateIndex(
                name: "IX_ItensPreVenda_ProdutoId",
                table: "ItensPreVenda",
                column: "ProdutoId");

            migrationBuilder.CreateIndex(
                name: "IX_PreVendas_ClienteId",
                table: "PreVendas",
                column: "ClienteId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ItensPreVenda");

            migrationBuilder.DropTable(
                name: "PreVendas");

            migrationBuilder.DropTable(
                name: "Produtos");

            migrationBuilder.DropTable(
                name: "Clientes");
        }
    }
}
