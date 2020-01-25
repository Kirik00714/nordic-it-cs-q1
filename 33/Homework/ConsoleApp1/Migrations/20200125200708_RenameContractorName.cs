using Microsoft.EntityFrameworkCore.Migrations;

namespace ConsoleApp1.Migrations
{
    public partial class RenameContractorName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FullName",
                table: "Contractors");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Contractors",
                maxLength: 128,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Contractors");

            migrationBuilder.AddColumn<string>(
                name: "FullName",
                table: "Contractors",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: true);
        }
    }
}
