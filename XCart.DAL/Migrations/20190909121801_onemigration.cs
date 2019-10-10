using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace XCart.DAL.Migrations
{
    public partial class onemigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ADMINS",
                columns: table => new
                {
                    AdminEmailId = table.Column<string>(maxLength: 100, nullable: false),
                    Phone = table.Column<string>(maxLength: 15, nullable: true),
                    Name = table.Column<string>(maxLength: 100, nullable: true),
                    UserName = table.Column<string>(maxLength: 50, nullable: true),
                    Password = table.Column<string>(maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ADMINS", x => x.AdminEmailId);
                });

            migrationBuilder.CreateTable(
                name: "STATES",
                columns: table => new
                {
                    StateId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    StateName = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_STATES", x => x.StateId);
                });

            migrationBuilder.CreateTable(
                name: "SUPPLIERS",
                columns: table => new
                {
                    SupplierId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SupplierName = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SUPPLIERS", x => x.SupplierId);
                });

            migrationBuilder.CreateTable(
                name: "USERS",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EmailId = table.Column<string>(maxLength: 50, nullable: true),
                    Password = table.Column<string>(maxLength: 1000, nullable: true),
                    PhoneNo = table.Column<string>(maxLength: 15, nullable: true),
                    TimeStamp = table.Column<DateTime>(type: "date", nullable: true),
                    FirstName = table.Column<string>(maxLength: 50, nullable: true),
                    LastName = table.Column<string>(maxLength: 50, nullable: true),
                    Gender = table.Column<string>(maxLength: 10, nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "date", nullable: true),
                    Question = table.Column<string>(maxLength: 200, nullable: true),
                    Answer = table.Column<string>(maxLength: 200, nullable: true),
                    Role = table.Column<string>(maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USERS", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "CITIES",
                columns: table => new
                {
                    CityId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    StateId = table.Column<int>(nullable: true),
                    CityName = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CITIES", x => x.CityId);
                    table.ForeignKey(
                        name: "FK_CITIES_STATES_StateId",
                        column: x => x.StateId,
                        principalTable: "STATES",
                        principalColumn: "StateId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PRODUCTS",
                columns: table => new
                {
                    ProductId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ProductName = table.Column<string>(maxLength: 50, nullable: true),
                    Price = table.Column<int>(nullable: true),
                    ProductShortDiscription = table.Column<string>(maxLength: 550, nullable: true),
                    Stock = table.Column<int>(nullable: true),
                    SupplierId = table.Column<int>(nullable: true),
                    ProductDiscount = table.Column<int>(nullable: true),
                    Path = table.Column<string>(maxLength: 1500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PRODUCTS", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_PRODUCTS_SUPPLIERS_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "SUPPLIERS",
                        principalColumn: "SupplierId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ADDRESSES",
                columns: table => new
                {
                    AddressId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    State = table.Column<string>(maxLength: 50, nullable: true),
                    City = table.Column<string>(maxLength: 50, nullable: true),
                    PostalCode = table.Column<string>(maxLength: 20, nullable: true),
                    AddressLine = table.Column<string>(maxLength: 100, nullable: true),
                    UserId = table.Column<int>(nullable: true),
                    SupplierId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ADDRESSES", x => x.AddressId);
                    table.ForeignKey(
                        name: "FK_ADDRESSES_SUPPLIERS_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "SUPPLIERS",
                        principalColumn: "SupplierId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ADDRESSES_USERS_UserId",
                        column: x => x.UserId,
                        principalTable: "USERS",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SEARCHHISTORY",
                columns: table => new
                {
                    SearchId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<int>(nullable: true),
                    SearchTag = table.Column<string>(maxLength: 50, nullable: true),
                    SearchDate = table.Column<DateTime>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SEARCHHISTORY", x => x.SearchId);
                    table.ForeignKey(
                        name: "FK_SEARCHHISTORY_USERS_UserId",
                        column: x => x.UserId,
                        principalTable: "USERS",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CART",
                columns: table => new
                {
                    CartId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<int>(nullable: true),
                    ProductId = table.Column<int>(nullable: true),
                    ItemQuantity = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CART", x => x.CartId);
                    table.ForeignKey(
                        name: "FK_CART_PRODUCTS_ProductId",
                        column: x => x.ProductId,
                        principalTable: "PRODUCTS",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CART_USERS_UserId",
                        column: x => x.UserId,
                        principalTable: "USERS",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FEEDBACKS",
                columns: table => new
                {
                    FeedbackId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ProductId = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: true),
                    Rating = table.Column<int>(nullable: true),
                    ReviewComment = table.Column<string>(maxLength: 550, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FEEDBACKS", x => x.FeedbackId);
                    table.ForeignKey(
                        name: "FK_FEEDBACKS_PRODUCTS_ProductId",
                        column: x => x.ProductId,
                        principalTable: "PRODUCTS",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FEEDBACKS_USERS_UserId",
                        column: x => x.UserId,
                        principalTable: "USERS",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PREVISIT",
                columns: table => new
                {
                    PreVisitId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ProductId = table.Column<int>(nullable: true),
                    UserId = table.Column<int>(nullable: true),
                    PreVisitDate = table.Column<DateTime>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PREVISIT", x => x.PreVisitId);
                    table.ForeignKey(
                        name: "FK_PREVISIT_PRODUCTS_ProductId",
                        column: x => x.ProductId,
                        principalTable: "PRODUCTS",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PREVISIT_USERS_UserId",
                        column: x => x.UserId,
                        principalTable: "USERS",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PRODUCTDESCRIPTION",
                columns: table => new
                {
                    DescriptionId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ProductId = table.Column<int>(nullable: true),
                    ProductCategory = table.Column<string>(maxLength: 50, nullable: true),
                    ProductGenderType = table.Column<string>(maxLength: 10, nullable: true),
                    ProductBrand = table.Column<string>(maxLength: 50, nullable: true),
                    ProductSubCategory = table.Column<string>(maxLength: 50, nullable: true),
                    ProductDescription = table.Column<string>(maxLength: 2000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PRODUCTDESCRIPTION", x => x.DescriptionId);
                    table.ForeignKey(
                        name: "FK_PRODUCTDESCRIPTION_PRODUCTS_ProductId",
                        column: x => x.ProductId,
                        principalTable: "PRODUCTS",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "WISHLISTS",
                columns: table => new
                {
                    WishListId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<int>(nullable: true),
                    ProductId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WISHLISTS", x => x.WishListId);
                    table.ForeignKey(
                        name: "FK_WISHLISTS_PRODUCTS_ProductId",
                        column: x => x.ProductId,
                        principalTable: "PRODUCTS",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WISHLISTS_USERS_UserId",
                        column: x => x.UserId,
                        principalTable: "USERS",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ORDERPLACED",
                columns: table => new
                {
                    OderId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<int>(nullable: true),
                    OrderNo = table.Column<int>(nullable: true),
                    ProductId = table.Column<int>(nullable: true),
                    Price = table.Column<int>(nullable: true),
                    OrderDate = table.Column<DateTime>(type: "date", nullable: true),
                    OrderedQuantity = table.Column<int>(nullable: true),
                    TotalAmount = table.Column<int>(nullable: true),
                    OrderStatus = table.Column<string>(maxLength: 50, nullable: true),
                    ModeOfPayment = table.Column<string>(maxLength: 50, nullable: true),
                    AddressId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ORDERPLACED", x => x.OderId);
                    table.ForeignKey(
                        name: "FK_ORDERPLACED_ADDRESSES_AddressId",
                        column: x => x.AddressId,
                        principalTable: "ADDRESSES",
                        principalColumn: "AddressId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ORDERPLACED_PRODUCTS_ProductId",
                        column: x => x.ProductId,
                        principalTable: "PRODUCTS",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ORDERPLACED_USERS_UserId",
                        column: x => x.UserId,
                        principalTable: "USERS",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ORDERSHISTORY",
                columns: table => new
                {
                    OrderHistoryId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ProductName = table.Column<string>(maxLength: 110, nullable: true),
                    Price = table.Column<int>(nullable: true),
                    UserId = table.Column<int>(nullable: true),
                    UserName = table.Column<string>(maxLength: 110, nullable: true),
                    TotalAmount = table.Column<int>(nullable: true),
                    Quantity = table.Column<int>(nullable: true),
                    PurchaceProductDate = table.Column<DateTime>(type: "date", nullable: true),
                    DiliveryAddress = table.Column<string>(maxLength: 500, nullable: true),
                    ModeOfPayment = table.Column<string>(maxLength: 50, nullable: true),
                    OrderId = table.Column<int>(nullable: true),
                    ORDERPLACEDOderId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ORDERSHISTORY", x => x.OrderHistoryId);
                    table.ForeignKey(
                        name: "FK_ORDERSHISTORY_ORDERPLACED_ORDERPLACEDOderId",
                        column: x => x.ORDERPLACEDOderId,
                        principalTable: "ORDERPLACED",
                        principalColumn: "OderId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ADDRESSES_SupplierId",
                table: "ADDRESSES",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_ADDRESSES_UserId",
                table: "ADDRESSES",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_CART_ProductId",
                table: "CART",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_CART_UserId",
                table: "CART",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_CITIES_StateId",
                table: "CITIES",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_FEEDBACKS_ProductId",
                table: "FEEDBACKS",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_FEEDBACKS_UserId",
                table: "FEEDBACKS",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ORDERPLACED_AddressId",
                table: "ORDERPLACED",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_ORDERPLACED_ProductId",
                table: "ORDERPLACED",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ORDERPLACED_UserId",
                table: "ORDERPLACED",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ORDERSHISTORY_ORDERPLACEDOderId",
                table: "ORDERSHISTORY",
                column: "ORDERPLACEDOderId");

            migrationBuilder.CreateIndex(
                name: "IX_PREVISIT_ProductId",
                table: "PREVISIT",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_PREVISIT_UserId",
                table: "PREVISIT",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_PRODUCTDESCRIPTION_ProductId",
                table: "PRODUCTDESCRIPTION",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_PRODUCTS_SupplierId",
                table: "PRODUCTS",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_SEARCHHISTORY_UserId",
                table: "SEARCHHISTORY",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_WISHLISTS_ProductId",
                table: "WISHLISTS",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_WISHLISTS_UserId",
                table: "WISHLISTS",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ADMINS");

            migrationBuilder.DropTable(
                name: "CART");

            migrationBuilder.DropTable(
                name: "CITIES");

            migrationBuilder.DropTable(
                name: "FEEDBACKS");

            migrationBuilder.DropTable(
                name: "ORDERSHISTORY");

            migrationBuilder.DropTable(
                name: "PREVISIT");

            migrationBuilder.DropTable(
                name: "PRODUCTDESCRIPTION");

            migrationBuilder.DropTable(
                name: "SEARCHHISTORY");

            migrationBuilder.DropTable(
                name: "WISHLISTS");

            migrationBuilder.DropTable(
                name: "STATES");

            migrationBuilder.DropTable(
                name: "ORDERPLACED");

            migrationBuilder.DropTable(
                name: "ADDRESSES");

            migrationBuilder.DropTable(
                name: "PRODUCTS");

            migrationBuilder.DropTable(
                name: "USERS");

            migrationBuilder.DropTable(
                name: "SUPPLIERS");
        }
    }
}
