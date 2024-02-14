using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Exercice04_ContactsAPI.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "contact",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    firstname = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    lastname = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    birthdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    gender = table.Column<int>(type: "int", nullable: false),
                    avatarURL = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_contact", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "contacts_list",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_contacts_list", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "contact_contacts_list",
                columns: table => new
                {
                    contact_id = table.Column<int>(type: "int", nullable: false),
                    contacts_list_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_contact_contacts_list", x => new { x.contact_id, x.contacts_list_id });
                    table.ForeignKey(
                        name: "FK_contact_contacts_list_contact_contact_id",
                        column: x => x.contact_id,
                        principalTable: "contact",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_contact_contacts_list_contacts_list_contacts_list_id",
                        column: x => x.contacts_list_id,
                        principalTable: "contacts_list",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ContactContactsList",
                columns: table => new
                {
                    ContactsId = table.Column<int>(type: "int", nullable: false),
                    ContactsListsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactContactsList", x => new { x.ContactsId, x.ContactsListsId });
                    table.ForeignKey(
                        name: "FK_ContactContactsList_contact_ContactsId",
                        column: x => x.ContactsId,
                        principalTable: "contact",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ContactContactsList_contacts_list_ContactsListsId",
                        column: x => x.ContactsListsId,
                        principalTable: "contacts_list",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "contact",
                columns: new[] { "id", "avatarURL", "birthdate", "firstname", "gender", "lastname" },
                values: new object[,]
                {
                    { 1, "", new DateTime(1981, 1, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jean", 1, "DUPONT" },
                    { 2, "", new DateTime(1993, 7, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jane", 2, "SMITH" }
                });

            migrationBuilder.InsertData(
                table: "contacts_list",
                columns: new[] { "id", "name" },
                values: new object[,]
                {
                    { 1, "Mes amis" },
                    { 2, "Mes collègues" }
                });

            migrationBuilder.InsertData(
                table: "contact_contacts_list",
                columns: new[] { "contact_id", "contacts_list_id" },
                values: new object[] { 1, 1 });

            migrationBuilder.InsertData(
                table: "contact_contacts_list",
                columns: new[] { "contact_id", "contacts_list_id" },
                values: new object[] { 1, 2 });

            migrationBuilder.InsertData(
                table: "contact_contacts_list",
                columns: new[] { "contact_id", "contacts_list_id" },
                values: new object[] { 2, 2 });

            migrationBuilder.CreateIndex(
                name: "IX_contact_contacts_list_contacts_list_id",
                table: "contact_contacts_list",
                column: "contacts_list_id");

            migrationBuilder.CreateIndex(
                name: "IX_ContactContactsList_ContactsListsId",
                table: "ContactContactsList",
                column: "ContactsListsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "contact_contacts_list");

            migrationBuilder.DropTable(
                name: "ContactContactsList");

            migrationBuilder.DropTable(
                name: "contact");

            migrationBuilder.DropTable(
                name: "contacts_list");
        }
    }
}
