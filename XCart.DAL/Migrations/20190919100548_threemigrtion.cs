using Microsoft.EntityFrameworkCore.Migrations;

namespace XCart.DAL.Migrations
{
    public partial class threemigrtion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ORDERPLACED_ADDRESSES_AddressId",
                table: "ORDERPLACED");

            migrationBuilder.DropIndex(
                name: "IX_ORDERPLACED_AddressId",
                table: "ORDERPLACED");

            migrationBuilder.DropColumn(
                name: "AddressId",
                table: "ORDERPLACED");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AddressId",
                table: "ORDERPLACED",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ORDERPLACED_AddressId",
                table: "ORDERPLACED",
                column: "AddressId");

            migrationBuilder.AddForeignKey(
                name: "FK_ORDERPLACED_ADDRESSES_AddressId",
                table: "ORDERPLACED",
                column: "AddressId",
                principalTable: "ADDRESSES",
                principalColumn: "AddressId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
