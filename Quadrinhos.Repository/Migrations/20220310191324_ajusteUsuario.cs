using Microsoft.EntityFrameworkCore.Migrations;

namespace Quadrinhos.Repository.Migrations
{
    public partial class ajusteUsuario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "role",
                table: "usuario",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "role",
                table: "usuario");
        }
    }
}
