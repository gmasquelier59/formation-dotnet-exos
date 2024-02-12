﻿// <auto-generated />
using System;
using Exercice04_ContactsAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Exercice04_ContactsAPI.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.26")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Exercice04_ContactsAPI.Models.ContactModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("AvatarURL")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)")
                        .HasColumnName("avatarURL");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("birthdate");

                    b.Property<string>("Firstname")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)")
                        .HasColumnName("firstname");

                    b.Property<int>("Gender")
                        .HasColumnType("int")
                        .HasColumnName("gender");

                    b.Property<string>("Lastname")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)")
                        .HasColumnName("lastname");

                    b.HasKey("Id");

                    b.ToTable("contact");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AvatarURL = "",
                            BirthDate = new DateTime(1981, 1, 23, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Firstname = "Jean",
                            Gender = 1,
                            Lastname = "DUPONT"
                        },
                        new
                        {
                            Id = 2,
                            AvatarURL = "",
                            BirthDate = new DateTime(1993, 7, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Firstname = "Jane",
                            Gender = 2,
                            Lastname = "SMITH"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}