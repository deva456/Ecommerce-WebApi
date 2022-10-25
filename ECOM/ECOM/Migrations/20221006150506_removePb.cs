using Microsoft.EntityFrameworkCore.Migrations;

namespace ECOM.Migrations
{
    public partial class removePb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "productBrand",
                table: "orders");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "productBrand",
                table: "orders",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
