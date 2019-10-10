using Microsoft.EntityFrameworkCore.Migrations;

namespace XCart.DAL.Migrations
{
    public partial class eightmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PLACEDORDERADDRESS_ORDERPLACED_OderId",
                table: "PLACEDORDERADDRESS");

            migrationBuilder.DropIndex(
                name: "IX_PLACEDORDERADDRESS_OderId",
                table: "PLACEDORDERADDRESS");

            migrationBuilder.RenameColumn(
                name: "OderId",
                table: "PLACEDORDERADDRESS",
                newName: "OrderNo");

            migrationBuilder.AddColumn<int>(
                name: "ORDERPLACEDOderId",
                table: "PLACEDORDERADDRESS",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PLACEDORDERADDRESS_ORDERPLACEDOderId",
                table: "PLACEDORDERADDRESS",
                column: "ORDERPLACEDOderId");

            migrationBuilder.AddForeignKey(
                name: "FK_PLACEDORDERADDRESS_ORDERPLACED_ORDERPLACEDOderId",
                table: "PLACEDORDERADDRESS",
                column: "ORDERPLACEDOderId",
                principalTable: "ORDERPLACED",
                principalColumn: "OderId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PLACEDORDERADDRESS_ORDERPLACED_ORDERPLACEDOderId",
                table: "PLACEDORDERADDRESS");

            migrationBuilder.DropIndex(
                name: "IX_PLACEDORDERADDRESS_ORDERPLACEDOderId",
                table: "PLACEDORDERADDRESS");

            migrationBuilder.DropColumn(
                name: "ORDERPLACEDOderId",
                table: "PLACEDORDERADDRESS");

            migrationBuilder.RenameColumn(
                name: "OrderNo",
                table: "PLACEDORDERADDRESS",
                newName: "OderId");

            migrationBuilder.CreateIndex(
                name: "IX_PLACEDORDERADDRESS_OderId",
                table: "PLACEDORDERADDRESS",
                column: "OderId");

            migrationBuilder.AddForeignKey(
                name: "FK_PLACEDORDERADDRESS_ORDERPLACED_OderId",
                table: "PLACEDORDERADDRESS",
                column: "OderId",
                principalTable: "ORDERPLACED",
                principalColumn: "OderId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
