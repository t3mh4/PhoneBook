using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReportMicroservice.Migrations
{
    public partial class reportmsaddcolumntoreport : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FullPath",
                schema: "public",
                table: "Report",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FullPath",
                schema: "public",
                table: "Report");
        }
    }
}
