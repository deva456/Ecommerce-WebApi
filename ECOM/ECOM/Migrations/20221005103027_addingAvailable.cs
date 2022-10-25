using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ECOM.Migrations
{
    public partial class addingAvailable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "productExpiryDate",
                table: "ProductInfo");

            migrationBuilder.AddColumn<bool>(
                name: "Available",
                table: "ProductInfo",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Available",
                table: "ProductInfo");

            migrationBuilder.AddColumn<DateTime>(
                name: "productExpiryDate",
                table: "ProductInfo",
                type: "datetime2",
                nullable: true);
        }
    }
}
