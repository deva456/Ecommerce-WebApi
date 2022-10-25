using Microsoft.EntityFrameworkCore.Migrations;

namespace ECOM.Migrations
{
    public partial class addingsubcatId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "subCategoryId",
                table: "ProductInfo",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ProductInfo_subCategoryId",
                table: "ProductInfo",
                column: "subCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductInfo_SubCategories_subCategoryId",
                table: "ProductInfo",
                column: "subCategoryId",
                principalTable: "SubCategories",
                principalColumn: "subCategoryId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductInfo_SubCategories_subCategoryId",
                table: "ProductInfo");

            migrationBuilder.DropIndex(
                name: "IX_ProductInfo_subCategoryId",
                table: "ProductInfo");

            migrationBuilder.DropColumn(
                name: "subCategoryId",
                table: "ProductInfo");
        }
    }
}
