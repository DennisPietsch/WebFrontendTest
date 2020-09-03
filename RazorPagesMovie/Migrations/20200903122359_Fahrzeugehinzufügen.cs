using Microsoft.EntityFrameworkCore.Migrations;

namespace RazorPagesMovie.Migrations
{
    public partial class Fahrzeugehinzufügen : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Fahrzeug_1",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Hersteller = table.Column<string>(maxLength: 60, nullable: false),
                    Preis = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    SitzPlaetze = table.Column<int>(nullable: false),
                    Raeder = table.Column<int>(nullable: false),
                    Leistung = table.Column<int>(nullable: false),
                    Bauhjahr = table.Column<int>(nullable: false),
                    kundenname = table.Column<string>(maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fahrzeug_1", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Fahrzeug_1");
        }
    }
}
