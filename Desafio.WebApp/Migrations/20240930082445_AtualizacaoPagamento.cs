using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Desafio.WebApp.Migrations
{
    /// <inheritdoc />
    public partial class AtualizacaoPagamento : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Estornado",
                table: "Pedidos",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "Parcelas",
                table: "Pedidos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TipoPagamento",
                table: "Pedidos",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Estornado",
                table: "Pedidos");

            migrationBuilder.DropColumn(
                name: "Parcelas",
                table: "Pedidos");

            migrationBuilder.DropColumn(
                name: "TipoPagamento",
                table: "Pedidos");
        }
    }
}
