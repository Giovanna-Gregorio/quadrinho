using Microsoft.EntityFrameworkCore.Migrations;

namespace Quadrinhos.Repository.Migrations
{
    public partial class ajusteVenda : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "valor_total",
                table: "venda",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "valor_total",
                table: "venda");
        }
    }
}
