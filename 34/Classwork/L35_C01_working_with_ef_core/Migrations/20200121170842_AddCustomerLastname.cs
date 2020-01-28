using Microsoft.EntityFrameworkCore.Migrations;

namespace L35_C01_working_with_ef_core.Migrations
{
    public partial class AddCustomerLastname : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Lastname",
                table: "Customers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Lastname",
                table: "Customers");
        }
    }
}
