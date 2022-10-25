using Microsoft.EntityFrameworkCore.Migrations;

namespace ECOM.Migrations
{
    public partial class addingfieldstoOrder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "productBrand",
                table: "orders",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "productImage",
                table: "orders",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "productPrice",
                table: "orders",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "productQuantity",
                table: "orders",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "productBrand",
                table: "orders");

            migrationBuilder.DropColumn(
                name: "productImage",
                table: "orders");

            migrationBuilder.DropColumn(
                name: "productPrice",
                table: "orders");

            migrationBuilder.DropColumn(
                name: "productQuantity",
                table: "orders");
        }
    }
}
