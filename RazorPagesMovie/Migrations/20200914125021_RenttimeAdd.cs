using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RazorPagesMovie.Migrations
{
    public partial class RenttimeAdd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AktueleZeit",
                table: "Fahrzeug_1");

            migrationBuilder.AddColumn<DateTime>(
                name: "AusgeliehenUM",
                table: "Fahrzeug_1",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AusgeliehenUM",
                table: "Fahrzeug_1");

            migrationBuilder.AddColumn<DateTime>(
                name: "AktueleZeit",
                table: "Fahrzeug_1",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
