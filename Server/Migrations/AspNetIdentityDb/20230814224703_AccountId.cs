using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Server.Migrations.AspNetIdentityDb
{
    public partial class AccountIdMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "AccountId",
                table: "AspNetUsers",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AccountId",
                table: "AspNetUsers");
        }
    }
}
