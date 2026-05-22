using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SonheiComBicho.Migrations
{
    /// <inheritdoc />
    public partial class CriarTabelaAposta : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Aposta",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    JogadorId = table.Column<int>(type: "int", nullable: false),
                    BichoId = table.Column<int>(type: "int", nullable: false),
                    Tipo = table.Column<int>(type: "int", nullable: false),
                    ValorApostado = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    ValorGanho = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    Ganhou = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    DataAposta = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aposta", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Aposta_Jogadores_JogadorId",
                        column: x => x.JogadorId,
                        principalTable: "Jogadores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Aposta_JogadorId",
                table: "Aposta",
                column: "JogadorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Aposta");
        }
    }
}
