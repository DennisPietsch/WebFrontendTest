using Microsoft.EntityFrameworkCore.Migrations;

namespace RazorPagesMovie.Migrations
{
    public partial class RazorPagesFahrzeuge : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "alter",
                table: "Kunde",
                newName: "Alter");

            migrationBuilder.RenameColumn(
                name: "VorName",
                table: "Kunde",
                newName: "Vorname");

            migrationBuilder.CreateTable(
                name: "Auto",
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
                    kundenname = table.Column<string>(maxLength: 30, nullable: false),
                    Anhängerkupplung = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Auto", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "LKW",
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
                    kundenname = table.Column<string>(maxLength: 30, nullable: false),
                    Ladevolumen = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LKW", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Motorrad",
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
                    table.PrimaryKey("PK_Motorrad", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Auto");

            migrationBuilder.DropTable(
                name: "LKW");

            migrationBuilder.DropTable(
                name: "Motorrad");

            migrationBuilder.RenameColumn(
                name: "Vorname",
                table: "Kunde",
                newName: "VorName");

            migrationBuilder.RenameColumn(
                name: "Alter",
                table: "Kunde",
                newName: "alter");
        }
    }
}
