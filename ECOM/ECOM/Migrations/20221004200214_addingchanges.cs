using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ECOM.Migrations
{
    public partial class addingchanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProductCategory",
                columns: table => new
                {
                    categoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCategory", x => x.categoryId);
                });

            migrationBuilder.CreateTable(
                name: "ProductInfo",
                columns: table => new
                {
                    productId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    productBrand = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    productName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    productPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    productDetails = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    productImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    productImage1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    productImage2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    productImage3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    productQuantity = table.Column<int>(type: "int", nullable: false),
                    addedToWishList = table.Column<bool>(type: "bit", nullable: false),
                    productExpiryDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    categoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductInfo", x => x.productId);
                    table.ForeignKey(
                        name: "FK_ProductInfo_ProductCategory_categoryId",
                        column: x => x.categoryId,
                        principalTable: "ProductCategory",
                        principalColumn: "categoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductInfo_categoryId",
                table: "ProductInfo",
                column: "categoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductInfo");

            migrationBuilder.DropTable(
                name: "ProductCategory");
        }
    }
}
