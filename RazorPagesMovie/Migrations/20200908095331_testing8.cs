using Microsoft.EntityFrameworkCore.Migrations;

namespace RazorPagesMovie.Migrations
{
    public partial class testing8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "seitenWagen",
                table: "Fahrzeug_1",
                newName: "SeitenWagen");

            migrationBuilder.RenameColumn(
                name: "verfuegbar",
                table: "Fahrzeug_1",
                newName: "Verfuegbar");

            migrationBuilder.RenameColumn(
                name: "ausleihzeit",
                table: "Fahrzeug_1",
                newName: "Ausleihzeit");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SeitenWagen",
                table: "Fahrzeug_1",
                newName: "seitenWagen");

            migrationBuilder.RenameColumn(
                name: "Verfuegbar",
                table: "Fahrzeug_1",
                newName: "verfuegbar");

            migrationBuilder.RenameColumn(
                name: "Ausleihzeit",
                table: "Fahrzeug_1",
                newName: "ausleihzeit");
        }
    }
}
