﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RazorPagesMovie.Data;

namespace RazorPagesMovie.Migrations
{
    [DbContext(typeof(RazorPagesMovieContext))]
    [Migration("20200903095410_FahrzeugInfo")]
    partial class FahrzeugInfo
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("RazorPagesMovie.Models.Movie", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Bauhjahr")
                        .HasColumnType("int");

                    b.Property<string>("Hersteller")
                        .IsRequired()
                        .HasColumnType("nvarchar(60)")
                        .HasMaxLength(60);

                    b.Property<int>("Leistung")
                        .HasColumnType("int");

                    b.Property<decimal>("Preis")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<int>("Raeder")
                        .HasColumnType("int");

                    b.Property<int>("SitzPlaetze")
                        .HasColumnType("int");

                    b.Property<string>("kundenname")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)")
                        .HasMaxLength(30);

                    b.HasKey("ID");

                    b.ToTable("Movie");
                });
#pragma warning restore 612, 618
        }
    }
}
