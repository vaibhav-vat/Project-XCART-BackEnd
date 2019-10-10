using Microsoft.EntityFrameworkCore.Migrations;

namespace XCart.DAL.Migrations
{
    public partial class eleven : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "USERS",
                maxLength: 10,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "PRODUCTS",
                maxLength: 10,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "USERS");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "PRODUCTS");
        }
    }
}
