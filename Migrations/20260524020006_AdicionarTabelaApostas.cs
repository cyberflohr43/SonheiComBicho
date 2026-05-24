using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SonheiComBicho.Migrations
{
    /// <inheritdoc />
    public partial class AdicionarTabelaApostas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Aposta_Jogadores_JogadorId",
                table: "Aposta");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Aposta",
                table: "Aposta");

            migrationBuilder.RenameTable(
                name: "Aposta",
                newName: "Apostas");

            migrationBuilder.RenameIndex(
                name: "IX_Aposta_JogadorId",
                table: "Apostas",
                newName: "IX_Apostas_JogadorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Apostas",
                table: "Apostas",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Apostas_Jogadores_JogadorId",
                table: "Apostas",
                column: "JogadorId",
                principalTable: "Jogadores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Apostas_Jogadores_JogadorId",
                table: "Apostas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Apostas",
                table: "Apostas");

            migrationBuilder.RenameTable(
                name: "Apostas",
                newName: "Aposta");

            migrationBuilder.RenameIndex(
                name: "IX_Apostas_JogadorId",
                table: "Aposta",
                newName: "IX_Aposta_JogadorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Aposta",
                table: "Aposta",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Aposta_Jogadores_JogadorId",
                table: "Aposta",
                column: "JogadorId",
                principalTable: "Jogadores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
