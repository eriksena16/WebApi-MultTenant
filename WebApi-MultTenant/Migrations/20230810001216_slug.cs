using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi_MultTenant.Migrations
{
    public partial class slug : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Slug",
                table: "Clientes",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Slug",
                table: "Clientes");
        }
    }
}
