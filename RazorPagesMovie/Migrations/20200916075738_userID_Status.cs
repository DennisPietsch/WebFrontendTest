using Microsoft.EntityFrameworkCore.Migrations;

namespace RazorPagesMovie.Migrations
{
    public partial class userID_Status : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "OwnerID",
                table: "Kunde",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Kunde",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OwnerID",
                table: "Kunde");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Kunde");
        }
    }
}
