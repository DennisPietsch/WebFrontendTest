using Microsoft.EntityFrameworkCore.Migrations;

namespace RazorPagesMovie.Migrations
{
    public partial class FahrzeugVariable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Fahrzeug",
                table: "Fahrzeug");


            migrationBuilder.AddPrimaryKey(
                name: "PK_Fahrzeug",
                table: "Fahrzeug",
                column: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Fahrzeug",
                table: "Fahrzeug");


            migrationBuilder.AddPrimaryKey(
                name: "PK_Fahrzeug",
                table: "Fahrzeug",
                column: "ID");
        }
    }
}
