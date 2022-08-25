using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Infrastructure.Data.Migrations
{
    public partial class InitialCreatePostGres : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Country",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Country", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DeliveryMethod",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ShortName = table.Column<string>(type: "text", nullable: true),
                    DeliveryTime = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Price = table.Column<decimal>(type: "numeric(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeliveryMethod", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TokenMessage",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TokenUid = table.Column<string>(type: "char(38)", maxLength: 38, nullable: true),
                    MessageText = table.Column<string>(type: "text", nullable: true),
                    MessageType = table.Column<string>(type: "text", nullable: true),
                    EmailAddress = table.Column<string>(type: "text", nullable: true),
                    EmailText = table.Column<string>(type: "text", nullable: true),
                    DateSent = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    IsSent = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TokenMessage", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Transaction",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DonatorUid = table.Column<string>(type: "char(38)", maxLength: 38, nullable: true),
                    DonatorId = table.Column<int>(type: "integer", nullable: false),
                    StoreUid = table.Column<string>(type: "char(38)", maxLength: 38, nullable: true),
                    StoreId = table.Column<int>(type: "integer", nullable: false),
                    EmployeeUid = table.Column<string>(type: "char(38)", maxLength: 38, nullable: true),
                    EmployeeId = table.Column<int>(type: "integer", nullable: false),
                    CostPrice = table.Column<decimal>(type: "numeric", nullable: false),
                    DatePurchased = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    MealsPerWeek = table.Column<int>(type: "integer", nullable: false),
                    MealsPerMonth = table.Column<int>(type: "integer", nullable: false),
                    Recurring = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transaction", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Donator",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DonatorUid = table.Column<string>(type: "char(38)", maxLength: 38, nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    ImageUrl = table.Column<string>(type: "text", nullable: true),
                    FirstName = table.Column<string>(type: "text", nullable: true),
                    Surname = table.Column<string>(type: "text", nullable: true),
                    FullName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Nickname = table.Column<string>(type: "text", nullable: true),
                    MobileNumber = table.Column<string>(type: "text", nullable: true),
                    EmailAddress = table.Column<string>(type: "text", nullable: true),
                    Address = table.Column<string>(type: "text", nullable: true),
                    Address2 = table.Column<string>(type: "text", nullable: true),
                    Suburb = table.Column<string>(type: "text", nullable: true),
                    City = table.Column<string>(type: "text", nullable: true),
                    PostalCode = table.Column<string>(type: "text", nullable: true),
                    CountryId = table.Column<int>(type: "integer", nullable: false),
                    DefaultToken = table.Column<string>(type: "text", nullable: true),
                    PortalUser = table.Column<string>(type: "text", nullable: true),
                    PortalPassword = table.Column<string>(type: "text", nullable: true),
                    Latitude = table.Column<decimal>(type: "numeric", nullable: false),
                    Longitude = table.Column<decimal>(type: "numeric", nullable: false),
                    EmployeeId = table.Column<int>(type: "integer", nullable: false),
                    EmployeeUid = table.Column<string>(type: "char(38)", maxLength: 38, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Donator", x => x.Id);
                    table.UniqueConstraint("AK_Donator_DonatorUid", x => x.DonatorUid);
                    table.ForeignKey(
                        name: "FK_Donator_Country_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Country",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    EmployeeUid = table.Column<string>(type: "char(38)", maxLength: 38, nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    ImageUrl = table.Column<string>(type: "text", nullable: true),
                    FirstName = table.Column<string>(type: "text", nullable: true),
                    Surname = table.Column<string>(type: "text", nullable: true),
                    FullName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Nickname = table.Column<string>(type: "text", nullable: true),
                    MobileNumber = table.Column<string>(type: "text", nullable: true),
                    EmailAddress = table.Column<string>(type: "text", nullable: true),
                    Address = table.Column<string>(type: "text", nullable: true),
                    Address2 = table.Column<string>(type: "text", nullable: true),
                    Suburb = table.Column<string>(type: "text", nullable: true),
                    City = table.Column<string>(type: "text", nullable: true),
                    PostalCode = table.Column<string>(type: "text", nullable: true),
                    CountryId = table.Column<int>(type: "integer", nullable: false),
                    DefaultToken = table.Column<string>(type: "text", nullable: true),
                    PortalUser = table.Column<string>(type: "text", nullable: true),
                    PortalPassword = table.Column<string>(type: "text", nullable: true),
                    Latitude = table.Column<decimal>(type: "numeric", nullable: false),
                    Longitude = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employee_Country_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Country",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Recipient",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RecipientUid = table.Column<string>(type: "char(38)", maxLength: 38, nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    ImageUrl = table.Column<string>(type: "text", nullable: true),
                    FirstName = table.Column<string>(type: "text", nullable: true),
                    Surname = table.Column<string>(type: "text", nullable: true),
                    FullName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Nickname = table.Column<string>(type: "text", nullable: true),
                    MobileNumber = table.Column<string>(type: "text", nullable: true),
                    EmailAddress = table.Column<string>(type: "text", nullable: true),
                    Address = table.Column<string>(type: "text", nullable: true),
                    Address2 = table.Column<string>(type: "text", nullable: true),
                    Suburb = table.Column<string>(type: "text", nullable: true),
                    City = table.Column<string>(type: "text", nullable: true),
                    PostalCode = table.Column<string>(type: "text", nullable: true),
                    CountryId = table.Column<int>(type: "integer", nullable: false),
                    DefaultToken = table.Column<string>(type: "text", nullable: true),
                    PortalUser = table.Column<string>(type: "text", nullable: true),
                    PortalPassword = table.Column<string>(type: "text", nullable: true),
                    Latitude = table.Column<decimal>(type: "numeric", nullable: false),
                    Longitude = table.Column<decimal>(type: "numeric", nullable: false),
                    EmployeeId = table.Column<int>(type: "integer", nullable: false),
                    EmployeeUid = table.Column<string>(type: "char(38)", maxLength: 38, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recipient", x => x.Id);
                    table.UniqueConstraint("AK_Recipient_RecipientUid", x => x.RecipientUid);
                    table.ForeignKey(
                        name: "FK_Recipient_Country_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Country",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Store",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    StoreUid = table.Column<string>(type: "char(38)", maxLength: 38, nullable: false),
                    StoreName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    ImageUrl = table.Column<string>(type: "text", nullable: true),
                    FirstName = table.Column<string>(type: "text", nullable: true),
                    Surname = table.Column<string>(type: "text", nullable: true),
                    FullName = table.Column<string>(type: "text", nullable: true),
                    Nickname = table.Column<string>(type: "text", nullable: true),
                    MobileNumber = table.Column<string>(type: "text", nullable: true),
                    EmailAddress = table.Column<string>(type: "text", nullable: true),
                    Address = table.Column<string>(type: "text", nullable: true),
                    Address2 = table.Column<string>(type: "text", nullable: true),
                    Suburb = table.Column<string>(type: "text", nullable: true),
                    City = table.Column<string>(type: "text", nullable: true),
                    PostalCode = table.Column<string>(type: "text", nullable: true),
                    CountryId = table.Column<int>(type: "integer", nullable: false),
                    DefaultToken = table.Column<string>(type: "text", nullable: true),
                    PortalUser = table.Column<string>(type: "text", nullable: true),
                    PortalPassword = table.Column<string>(type: "text", nullable: true),
                    Latitude = table.Column<decimal>(type: "numeric", nullable: false),
                    Longitude = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Store", x => x.Id);
                    table.UniqueConstraint("AK_Store_StoreUid", x => x.StoreUid);
                    table.ForeignKey(
                        name: "FK_Store_Country_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Country",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    BuyerEmail = table.Column<string>(type: "text", nullable: true),
                    OrderDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    DeliveryMethodId = table.Column<int>(type: "integer", nullable: true),
                    Subtotal = table.Column<decimal>(type: "numeric", nullable: false),
                    Status = table.Column<string>(type: "text", nullable: false),
                    PaymentIntentId = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Order_DeliveryMethod_DeliveryMethodId",
                        column: x => x.DeliveryMethodId,
                        principalTable: "DeliveryMethod",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Price = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    ImageUrl = table.Column<string>(type: "text", nullable: true),
                    ProductTypeId = table.Column<int>(type: "integer", nullable: false),
                    StoreId = table.Column<int>(type: "integer", nullable: false),
                    StoreUid = table.Column<string>(type: "char(38)", maxLength: 38, nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Product_ProductType_ProductTypeId",
                        column: x => x.ProductTypeId,
                        principalTable: "ProductType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Product_Store_StoreUid",
                        column: x => x.StoreUid,
                        principalTable: "Store",
                        principalColumn: "StoreUid",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StoreRecipient",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    StoreRecipientUid = table.Column<string>(type: "char(38)", maxLength: 38, nullable: true),
                    StoreUid = table.Column<string>(type: "char(38)", maxLength: 38, nullable: true),
                    StoreId = table.Column<int>(type: "integer", nullable: false),
                    RecipientUid = table.Column<string>(type: "char(38)", maxLength: 38, nullable: true),
                    RecipientId = table.Column<int>(type: "integer", nullable: false),
                    EmployeeUid = table.Column<string>(type: "char(38)", maxLength: 38, nullable: true),
                    EmployeeId = table.Column<int>(type: "integer", nullable: false),
                    DateRegistered = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StoreRecipient", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StoreRecipient_Recipient_RecipientUid",
                        column: x => x.RecipientUid,
                        principalTable: "Recipient",
                        principalColumn: "RecipientUid",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StoreRecipient_Store_StoreUid",
                        column: x => x.StoreUid,
                        principalTable: "Store",
                        principalColumn: "StoreUid",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "integer", nullable: false),
                    FirstName = table.Column<string>(type: "text", nullable: true),
                    LastName = table.Column<string>(type: "text", nullable: true),
                    Street = table.Column<string>(type: "text", nullable: true),
                    City = table.Column<string>(type: "text", nullable: true),
                    State = table.Column<string>(type: "text", nullable: true),
                    ZipCode = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.OrderId);
                    table.ForeignKey(
                        name: "FK_Address_Order_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Order",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderItem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Price = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false),
                    OrderId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderItem_Order_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Order",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Token",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TokenUid = table.Column<string>(type: "char(38)", maxLength: 38, nullable: true),
                    TokenName = table.Column<string>(type: "character varying(25)", maxLength: 25, nullable: false),
                    DonatorUid = table.Column<string>(type: "char(38)", maxLength: 38, nullable: true),
                    DonatorId = table.Column<int>(type: "integer", nullable: false),
                    BuyerEmail = table.Column<string>(type: "text", nullable: true),
                    StoreUid = table.Column<string>(type: "char(38)", maxLength: 38, nullable: true),
                    StoreId = table.Column<int>(type: "integer", nullable: false),
                    ProductId = table.Column<int>(type: "integer", nullable: false),
                    StoreMealUid = table.Column<string>(type: "char(38)", maxLength: 38, nullable: true),
                    RecipientUid = table.Column<string>(type: "char(38)", maxLength: 38, nullable: true),
                    RecipientId = table.Column<int>(type: "integer", nullable: false),
                    CostPrice = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    SalesPrice = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    DateStoreAssigned = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    DateAssigned = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    DateCollected = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    DateRelease = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    DateExpire = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    FoodCollected = table.Column<bool>(type: "boolean", nullable: false),
                    Valid = table.Column<bool>(type: "boolean", nullable: false),
                    ImageUrl = table.Column<string>(type: "text", nullable: true),
                    ShortUrl = table.Column<string>(type: "text", nullable: true),
                    RecipientName = table.Column<string>(type: "text", nullable: true),
                    DonatorName = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Token", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Token_Donator_DonatorUid",
                        column: x => x.DonatorUid,
                        principalTable: "Donator",
                        principalColumn: "DonatorUid",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Token_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Token_Recipient_RecipientUid",
                        column: x => x.RecipientUid,
                        principalTable: "Recipient",
                        principalColumn: "RecipientUid",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Token_Store_StoreUid",
                        column: x => x.StoreUid,
                        principalTable: "Store",
                        principalColumn: "StoreUid",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductItemOrdered",
                columns: table => new
                {
                    OrderItemId = table.Column<int>(type: "integer", nullable: false),
                    ProductItemId = table.Column<int>(type: "integer", nullable: false),
                    ProductName = table.Column<string>(type: "text", nullable: true),
                    ImageUrl = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductItemOrdered", x => x.OrderItemId);
                    table.ForeignKey(
                        name: "FK_ProductItemOrdered_OrderItem_OrderItemId",
                        column: x => x.OrderItemId,
                        principalTable: "OrderItem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Donator_CountryId",
                table: "Donator",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_CountryId",
                table: "Employee",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_DeliveryMethodId",
                table: "Order",
                column: "DeliveryMethodId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItem_OrderId",
                table: "OrderItem",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_ProductTypeId",
                table: "Product",
                column: "ProductTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_StoreUid",
                table: "Product",
                column: "StoreUid");

            migrationBuilder.CreateIndex(
                name: "IX_Recipient_CountryId",
                table: "Recipient",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Store_CountryId",
                table: "Store",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_StoreRecipient_RecipientUid",
                table: "StoreRecipient",
                column: "RecipientUid");

            migrationBuilder.CreateIndex(
                name: "IX_StoreRecipient_StoreUid",
                table: "StoreRecipient",
                column: "StoreUid");

            migrationBuilder.CreateIndex(
                name: "IX_Token_DonatorUid",
                table: "Token",
                column: "DonatorUid");

            migrationBuilder.CreateIndex(
                name: "IX_Token_ProductId",
                table: "Token",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Token_RecipientUid",
                table: "Token",
                column: "RecipientUid");

            migrationBuilder.CreateIndex(
                name: "IX_Token_StoreUid",
                table: "Token",
                column: "StoreUid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropTable(
                name: "ProductItemOrdered");

            migrationBuilder.DropTable(
                name: "StoreRecipient");

            migrationBuilder.DropTable(
                name: "Token");

            migrationBuilder.DropTable(
                name: "TokenMessage");

            migrationBuilder.DropTable(
                name: "Transaction");

            migrationBuilder.DropTable(
                name: "OrderItem");

            migrationBuilder.DropTable(
                name: "Donator");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "Recipient");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "ProductType");

            migrationBuilder.DropTable(
                name: "Store");

            migrationBuilder.DropTable(
                name: "DeliveryMethod");

            migrationBuilder.DropTable(
                name: "Country");
        }
    }
}
