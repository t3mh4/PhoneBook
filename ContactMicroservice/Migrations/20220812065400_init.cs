using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ContactMicroservice.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "public");

            migrationBuilder.CreateTable(
                name: "Contact",
                schema: "public",
                columns: table => new
                {
                    UUID = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Surname = table.Column<string>(type: "text", nullable: false),
                    Company = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contact", x => x.UUID);
                });

            migrationBuilder.CreateTable(
                name: "ContactInfo",
                schema: "public",
                columns: table => new
                {
                    UUID = table.Column<Guid>(type: "uuid", nullable: false),
                    PhoneNumber = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: false),
                    EMail = table.Column<string>(type: "text", nullable: false),
                    Location = table.Column<string>(type: "text", nullable: false),
                    ContactUUID = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactInfo", x => x.UUID);
                    table.ForeignKey(
                        name: "FK_ContactInfo_Contact_ContactUUID",
                        column: x => x.ContactUUID,
                        principalSchema: "public",
                        principalTable: "Contact",
                        principalColumn: "UUID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ContactInfo_ContactUUID",
                schema: "public",
                table: "ContactInfo",
                column: "ContactUUID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContactInfo",
                schema: "public");

            migrationBuilder.DropTable(
                name: "Contact",
                schema: "public");
        }
    }
}
