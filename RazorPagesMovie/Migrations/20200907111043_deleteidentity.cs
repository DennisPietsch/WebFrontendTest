using Microsoft.EntityFrameworkCore.Migrations;

namespace RazorPagesMovie.Migrations
{
    public partial class deleteidentity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Movie");

            migrationBuilder.AddColumn<bool>(
                name: "verfuegbar",
                table: "Fahrzeug_1",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "verfuegbar",
                table: "Fahrzeug_1");

            migrationBuilder.CreateTable(
                name: "Movie",
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
                    table.PrimaryKey("PK_Movie", x => x.ID);
                });
        }
    }
}
