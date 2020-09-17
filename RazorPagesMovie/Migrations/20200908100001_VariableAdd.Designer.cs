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
    [Migration("20200908100001_VariableAdd")]
    partial class VariableAdd
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("RazorPagesMovie.Models.Fahrzeug", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Ausleihzeit")
                        .HasColumnType("int");

                    b.Property<int>("Bauhjahr")
                        .HasColumnType("int");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Hersteller")
                        .HasColumnType("nvarchar(60)")
                        .HasMaxLength(60);

                    b.Property<string>("Kundenname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Leistung")
                        .HasColumnType("int");

                    b.Property<decimal>("Preis")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<int>("Raeder")
                        .HasColumnType("int");

                    b.Property<int>("SitzPlaetze")
                        .HasColumnType("int");

                    b.Property<bool>("Verfuegbar")
                        .HasColumnType("bit");

                    b.HasKey("ID");

                    b.ToTable("Fahrzeug_1");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Fahrzeug");
                });

            modelBuilder.Entity("RazorPagesMovie.Models.Kunde", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Alter")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("Stadt")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Vorname")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("ID");

                    b.ToTable("Kunde");
                });

            modelBuilder.Entity("RazorPagesMovie.Models.Auto", b =>
                {
                    b.HasBaseType("RazorPagesMovie.Models.Fahrzeug");

                    b.Property<bool>("Anhängerkupplung")
                        .HasColumnType("bit");

                    b.HasDiscriminator().HasValue("Auto");
                });

            modelBuilder.Entity("RazorPagesMovie.Models.LKW", b =>
                {
                    b.HasBaseType("RazorPagesMovie.Models.Fahrzeug");

                    b.Property<decimal>("Ladevolumen")
                        .HasColumnType("decimal(18,2)");

                    b.HasDiscriminator().HasValue("LKW");
                });

            modelBuilder.Entity("RazorPagesMovie.Models.Motorrad", b =>
                {
                    b.HasBaseType("RazorPagesMovie.Models.Fahrzeug");

                    b.Property<bool>("SeitenWagen")
                        .HasColumnType("bit");

                    b.HasDiscriminator().HasValue("Motorrad");
                });
#pragma warning restore 612, 618
        }
    }
}