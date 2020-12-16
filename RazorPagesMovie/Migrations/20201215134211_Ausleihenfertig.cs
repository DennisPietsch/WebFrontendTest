using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RazorPagesMovie.Migrations
{
    public partial class Ausleihenfertig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Ausleihzeit",
                table: "Fahrzeug",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<DateTime>(
                name: "AusgeliehenBIS",
                table: "Fahrzeug",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AusgeliehenBIS",
                table: "Fahrzeug");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Ausleihzeit",
                table: "Fahrzeug",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(int));
        }
    }
}
