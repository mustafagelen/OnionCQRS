using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace OnionApi.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Brands",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brands", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ParentId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Priorty = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BrandId = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Discount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Products_Brands_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Brands",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Details",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Details", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Details_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CategoryProduct",
                columns: table => new
                {
                    CategoriesID = table.Column<int>(type: "int", nullable: false),
                    ProductsID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryProduct", x => new { x.CategoriesID, x.ProductsID });
                    table.ForeignKey(
                        name: "FK_CategoryProduct_Categories_CategoriesID",
                        column: x => x.CategoriesID,
                        principalTable: "Categories",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategoryProduct_Products_ProductsID",
                        column: x => x.ProductsID,
                        principalTable: "Products",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Brands",
                columns: new[] { "ID", "CreatedDate", "IsDeleted", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 11, 24, 20, 27, 50, 369, DateTimeKind.Local).AddTicks(3494), false, "Movies" },
                    { 2, new DateTime(2025, 11, 24, 20, 27, 50, 369, DateTimeKind.Local).AddTicks(3546), false, "Electronics, Garden & Garden" },
                    { 3, new DateTime(2025, 11, 24, 20, 27, 50, 369, DateTimeKind.Local).AddTicks(3617), true, "Automotive" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "ID", "CreatedDate", "IsDeleted", "Name", "ParentId", "Priorty" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 11, 24, 20, 27, 50, 369, DateTimeKind.Local).AddTicks(4628), false, "Elektronik", 0, 1 },
                    { 2, new DateTime(2025, 11, 24, 20, 27, 50, 369, DateTimeKind.Local).AddTicks(4632), false, "Elektronik", 0, 1 },
                    { 3, new DateTime(2025, 11, 24, 20, 27, 50, 369, DateTimeKind.Local).AddTicks(4633), false, "Bilgisayar", 1, 1 },
                    { 4, new DateTime(2025, 11, 24, 20, 27, 50, 369, DateTimeKind.Local).AddTicks(4634), false, "Kadın", 0, 1 }
                });

            migrationBuilder.InsertData(
                table: "Details",
                columns: new[] { "ID", "CategoryId", "CreatedDate", "Description", "IsDeleted", "Title" },
                values: new object[,]
                {
                    { 1, 3, new DateTime(2025, 11, 24, 20, 27, 50, 371, DateTimeKind.Local).AddTicks(395), "The automobile layout consists of a front-engine design, with transaxle-type transmissions mounted at the rear of the engine and four wheel drive", false, "Handmade Rubber Mouse" },
                    { 2, 4, new DateTime(2025, 11, 24, 20, 27, 50, 371, DateTimeKind.Local).AddTicks(418), "The Football Is Good For Training And Recreational Purposes", false, "Refined Steel Bike" },
                    { 3, 3, new DateTime(2025, 11, 24, 20, 27, 50, 371, DateTimeKind.Local).AddTicks(435), "Carbonite web goalkeeper gloves are ergonomically designed to give easy fit", true, "Small Plastic Soap" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ID", "BrandId", "CreatedDate", "Description", "Discount", "IsDeleted", "Price", "Title" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2025, 11, 24, 20, 27, 50, 372, DateTimeKind.Local).AddTicks(4206), "The Apollotech B340 is an affordable wireless mouse with reliable connectivity, 12 months battery life and modern design", 65.35794409705332m, false, 90.34m, "Sleek Fresh Bike" },
                    { 2, 3, new DateTime(2025, 11, 24, 20, 27, 50, 372, DateTimeKind.Local).AddTicks(4239), "New ABC 13 9370, 13.3, 5th Gen CoreA5-8250U, 8GB RAM, 256GB SSD, power UHD Graphics, OS 10 Home, OS Office A & J 2016", 105.380401695661912m, false, 22.50m, "Handcrafted Cotton Shirt" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CategoryProduct_ProductsID",
                table: "CategoryProduct",
                column: "ProductsID");

            migrationBuilder.CreateIndex(
                name: "IX_Details_CategoryId",
                table: "Details",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_BrandId",
                table: "Products",
                column: "BrandId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CategoryProduct");

            migrationBuilder.DropTable(
                name: "Details");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Brands");
        }
    }
}
