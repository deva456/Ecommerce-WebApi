using Microsoft.EntityFrameworkCore.Migrations;

namespace ECOM.Migrations
{
    public partial class addingaddress : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "panCard",
                table: "AspNetUsers",
                newName: "Address");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Address",
                table: "AspNetUsers",
                newName: "panCard");
        }
    }
}
