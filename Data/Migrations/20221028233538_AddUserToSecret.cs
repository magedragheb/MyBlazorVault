using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyBlazorVault.Data.Migrations
{
    public partial class AddUserToSecret : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Secrets",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Secrets_UserId",
                table: "Secrets",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Secrets_AspNetUsers_UserId",
                table: "Secrets",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Secrets_AspNetUsers_UserId",
                table: "Secrets");

            migrationBuilder.DropIndex(
                name: "IX_Secrets_UserId",
                table: "Secrets");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Secrets");
        }
    }
}
