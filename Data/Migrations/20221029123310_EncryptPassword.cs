using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyBlazorVault.Data.Migrations
{
    public partial class EncryptPassword : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "HashedPassword",
                table: "Secrets",
                newName: "EncryptedPassword");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "EncryptedPassword",
                table: "Secrets",
                newName: "HashedPassword");
        }
    }
}
