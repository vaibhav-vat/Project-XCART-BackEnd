using Microsoft.EntityFrameworkCore.Migrations;

namespace XCart.DAL.Migrations
{
    public partial class threemigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ProductSubCategory",
                table: "PRODUCTDESCRIPTION",
                newName: "ProductSubCategory2");

            migrationBuilder.RenameColumn(
                name: "ProductCategory",
                table: "PRODUCTDESCRIPTION",
                newName: "ProductSubCategory1");

            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "PRODUCTS",
                maxLength: 1500,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Category",
                table: "PRODUCTS");

            migrationBuilder.RenameColumn(
                name: "ProductSubCategory2",
                table: "PRODUCTDESCRIPTION",
                newName: "ProductSubCategory");

            migrationBuilder.RenameColumn(
                name: "ProductSubCategory1",
                table: "PRODUCTDESCRIPTION",
                newName: "ProductCategory");
        }
    }
}
