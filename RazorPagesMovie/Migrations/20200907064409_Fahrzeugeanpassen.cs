using Microsoft.EntityFrameworkCore.Migrations;

namespace RazorPagesMovie.Migrations
{
    public partial class Fahrzeugeanpassen : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Auto");

            migrationBuilder.DropTable(
                name: "LKW");

            migrationBuilder.DropTable(
                name: "Motorrad");

            migrationBuilder.AddColumn<bool>(
                name: "Anhängerkupplung",
                table: "Fahrzeug_1",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Fahrzeug_1",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "Ladevolumen",
                table: "Fahrzeug_1",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "seitenWagen",
                table: "Fahrzeug_1",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Anhängerkupplung",
                table: "Fahrzeug_1");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Fahrzeug_1");

            migrationBuilder.DropColumn(
                name: "Ladevolumen",
                table: "Fahrzeug_1");

            migrationBuilder.DropColumn(
                name: "seitenWagen",
                table: "Fahrzeug_1");

            migrationBuilder.CreateTable(
                name: "Auto",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Anhängerkupplung = table.Column<bool>(type: "bit", nullable: false),
                    Bauhjahr = table.Column<int>(type: "int", nullable: false),
                    Hersteller = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Leistung = table.Column<int>(type: "int", nullable: false),
                    Preis = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    Raeder = table.Column<int>(type: "int", nullable: false),
                    SitzPlaetze = table.Column<int>(type: "int", nullable: false),
                    kundenname = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Auto", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "LKW",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Bauhjahr = table.Column<int>(type: "int", nullable: false),
                    Hersteller = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Ladevolumen = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Leistung = table.Column<int>(type: "int", nullable: false),
                    Preis = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    Raeder = table.Column<int>(type: "int", nullable: false),
                    SitzPlaetze = table.Column<int>(type: "int", nullable: false),
                    kundenname = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LKW", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Motorrad",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Bauhjahr = table.Column<int>(type: "int", nullable: false),
                    Hersteller = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Leistung = table.Column<int>(type: "int", nullable: false),
                    Preis = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    Raeder = table.Column<int>(type: "int", nullable: false),
                    SitzPlaetze = table.Column<int>(type: "int", nullable: false),
                    kundenname = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Motorrad", x => x.ID);
                });
        }
    }
}
