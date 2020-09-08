using Microsoft.EntityFrameworkCore.Migrations;

namespace RazorPagesMovie.Migrations
{
    public partial class testingregistration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ConfirmPassword",
                table: "Kunde",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Kunde",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Kunde",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ConfirmPassword",
                table: "Kunde");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Kunde");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "Kunde");
        }
    }
}
