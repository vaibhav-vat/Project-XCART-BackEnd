using Microsoft.EntityFrameworkCore.Migrations;

namespace XCart.DAL.Migrations
{
    public partial class twelve : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ProductShortDiscription",
                table: "PRODUCTS",
                maxLength: 50000,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 550,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TagLine",
                table: "PRODUCTS",
                maxLength: 1500,
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AddressLine",
                table: "ADDRESSES",
                maxLength: 10000,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 100,
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TagLine",
                table: "PRODUCTS");

            migrationBuilder.AlterColumn<string>(
                name: "ProductShortDiscription",
                table: "PRODUCTS",
                maxLength: 550,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 50000,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AddressLine",
                table: "ADDRESSES",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 10000,
                oldNullable: true);
        }
    }
}
