using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace XCart.DAL.Migrations
{
    public partial class FOURMIGRATION : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PLACEDORDERADDRESS",
                columns: table => new
                {
                    AddressId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    State = table.Column<string>(maxLength: 50, nullable: true),
                    City = table.Column<string>(maxLength: 50, nullable: true),
                    PostalCode = table.Column<string>(maxLength: 20, nullable: true),
                    AddressLine = table.Column<string>(maxLength: 100, nullable: true),
                    OderId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PLACEDORDERADDRESS", x => x.AddressId);
                    table.ForeignKey(
                        name: "FK_PLACEDORDERADDRESS_ORDERPLACED_OderId",
                        column: x => x.OderId,
                        principalTable: "ORDERPLACED",
                        principalColumn: "OderId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PLACEDORDERADDRESS_OderId",
                table: "PLACEDORDERADDRESS",
                column: "OderId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PLACEDORDERADDRESS");
        }
    }
}
