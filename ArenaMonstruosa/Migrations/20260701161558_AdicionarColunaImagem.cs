using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ArenaMonstruosa.Migrations
{
    public partial class AdicionarColunaImagem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Batalhas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Jogador1Id = table.Column<int>(nullable: false),
                    Jogador2Id = table.Column<int>(nullable: false),
                    VencedorId = table.Column<int>(nullable: false),
                    DataDaBatalha = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Batalhas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Jogadores",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(nullable: true),
                    Vida = table.Column<int>(nullable: false),
                    Ataque = table.Column<int>(nullable: false),
                    Defesa = table.Column<int>(nullable: false),
                    Imagem = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jogadores", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Batalhas");

            migrationBuilder.DropTable(
                name: "Jogadores");
        }
    }
}
