using Microsoft.EntityFrameworkCore.Migrations;

namespace XCart.DAL.Migrations
{
    public partial class fourteen : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ORDERSHISTORY_ORDERPLACED_ORDERPLACEDOderId",
                table: "ORDERSHISTORY");

            migrationBuilder.DropIndex(
                name: "IX_ORDERSHISTORY_ORDERPLACEDOderId",
                table: "ORDERSHISTORY");

            migrationBuilder.DropColumn(
                name: "ORDERPLACEDOderId",
                table: "ORDERSHISTORY");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ORDERPLACEDOderId",
                table: "ORDERSHISTORY",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ORDERSHISTORY_ORDERPLACEDOderId",
                table: "ORDERSHISTORY",
                column: "ORDERPLACEDOderId");

            migrationBuilder.AddForeignKey(
                name: "FK_ORDERSHISTORY_ORDERPLACED_ORDERPLACEDOderId",
                table: "ORDERSHISTORY",
                column: "ORDERPLACEDOderId",
                principalTable: "ORDERPLACED",
                principalColumn: "OderId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
