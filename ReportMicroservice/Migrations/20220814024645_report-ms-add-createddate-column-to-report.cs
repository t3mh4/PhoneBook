﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReportMicroservice.Migrations
{
    public partial class reportmsaddcreateddatecolumntoreport : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                schema: "public",
                table: "Report",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedDate",
                schema: "public",
                table: "Report");
        }
    }
}
