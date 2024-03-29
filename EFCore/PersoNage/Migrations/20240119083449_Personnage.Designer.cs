﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PersoNage.Classes;

#nullable disable

namespace PersoNage.Migrations
{
    [DbContext(typeof(PersoNageDbContext))]
    [Migration("20240119083449_Personnage")]
    partial class Personnage
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.26")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("PersoNage.Entities.Personnage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("DateCreation")
                        .HasColumnType("datetime2");

                    b.Property<int>("Degats")
                        .HasColumnType("int");

                    b.Property<int>("NombrePersonnagesTues")
                        .HasColumnType("int");

                    b.Property<int>("PointsArmure")
                        .HasColumnType("int");

                    b.Property<int>("PointsVie")
                        .HasColumnType("int");

                    b.Property<string>("Pseudo")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("VARCHAR(50)");

                    b.HasKey("Id");

                    b.ToTable("Personnages");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DateCreation = new DateTime(2024, 1, 19, 9, 34, 49, 458, DateTimeKind.Local).AddTicks(6588),
                            Degats = 10,
                            NombrePersonnagesTues = 0,
                            PointsArmure = 20,
                            PointsVie = 50,
                            Pseudo = "Guillausaure"
                        },
                        new
                        {
                            Id = 2,
                            DateCreation = new DateTime(2024, 1, 19, 9, 34, 49, 458, DateTimeKind.Local).AddTicks(6647),
                            Degats = 5,
                            NombrePersonnagesTues = 0,
                            PointsArmure = 10,
                            PointsVie = 30,
                            Pseudo = "Uno"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
