using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace XCart.DAL.Migrations
{
    public partial class thirteen : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserName",
                table: "ORDERSHISTORY",
                newName: "CustomerName");

            migrationBuilder.RenameColumn(
                name: "PurchaceProductDate",
                table: "ORDERSHISTORY",
                newName: "OrderDate");

            migrationBuilder.RenameColumn(
                name: "OrderId",
                table: "ORDERSHISTORY",
                newName: "ProductId");

            migrationBuilder.AddColumn<DateTime>(
                name: "DeliveryDate",
                table: "ORDERSHISTORY",
                type: "date",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OrderNo",
                table: "ORDERSHISTORY",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OrderStatus",
                table: "ORDERSHISTORY",
                maxLength: 50,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeliveryDate",
                table: "ORDERSHISTORY");

            migrationBuilder.DropColumn(
                name: "OrderNo",
                table: "ORDERSHISTORY");

            migrationBuilder.DropColumn(
                name: "OrderStatus",
                table: "ORDERSHISTORY");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "ORDERSHISTORY",
                newName: "OrderId");

            migrationBuilder.RenameColumn(
                name: "OrderDate",
                table: "ORDERSHISTORY",
                newName: "PurchaceProductDate");

            migrationBuilder.RenameColumn(
                name: "CustomerName",
                table: "ORDERSHISTORY",
                newName: "UserName");
        }
    }
}
