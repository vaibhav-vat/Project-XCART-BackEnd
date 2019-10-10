using Microsoft.EntityFrameworkCore.Migrations;

namespace XCart.DAL.Migrations
{
    public partial class fifthteen : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Path",
                table: "ORDERSHISTORY",
                maxLength: 1500,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Path",
                table: "ORDERSHISTORY");
        }
    }
}
