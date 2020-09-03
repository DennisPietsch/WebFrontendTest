using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RazorPagesMovie.Migrations
{
    public partial class FahrzeugInfo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Genre",
                table: "Movie");

            migrationBuilder.DropColumn(
                name: "Rating",
                table: "Movie");

            migrationBuilder.DropColumn(
                name: "ReleaseDate",
                table: "Movie");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "Movie");

            migrationBuilder.RenameColumn(
                name: "Price",
                table: "Movie",
                newName: "Preis");

            migrationBuilder.AddColumn<int>(
                name: "Bauhjahr",
                table: "Movie",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Hersteller",
                table: "Movie",
                maxLength: 60,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Leistung",
                table: "Movie",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Raeder",
                table: "Movie",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SitzPlaetze",
                table: "Movie",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "kundenname",
                table: "Movie",
                maxLength: 30,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Bauhjahr",
                table: "Movie");

            migrationBuilder.DropColumn(
                name: "Hersteller",
                table: "Movie");

            migrationBuilder.DropColumn(
                name: "Leistung",
                table: "Movie");

            migrationBuilder.DropColumn(
                name: "Raeder",
                table: "Movie");

            migrationBuilder.DropColumn(
                name: "SitzPlaetze",
                table: "Movie");

            migrationBuilder.DropColumn(
                name: "kundenname",
                table: "Movie");

            migrationBuilder.RenameColumn(
                name: "Preis",
                table: "Movie",
                newName: "Price");

            migrationBuilder.AddColumn<string>(
                name: "Genre",
                table: "Movie",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Rating",
                table: "Movie",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ReleaseDate",
                table: "Movie",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Movie",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
