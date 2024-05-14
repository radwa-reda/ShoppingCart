using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ShoppingCart.DAL.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_orders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "cartItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cartItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_cartItems_orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "orders",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_cartItems_products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "orders",
                columns: new[] { "Id", "CreationDateTime", "TotalPrice" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 4, 28, 23, 1, 5, 163, DateTimeKind.Local).AddTicks(2178), 1000m },
                    { 2, new DateTime(2024, 4, 28, 23, 1, 5, 163, DateTimeKind.Local).AddTicks(2244), 2000m },
                    { 3, new DateTime(2024, 4, 28, 23, 1, 5, 163, DateTimeKind.Local).AddTicks(2247), 3000m },
                    { 4, new DateTime(2024, 4, 28, 23, 1, 5, 163, DateTimeKind.Local).AddTicks(2250), 4000m },
                    { 5, new DateTime(2024, 4, 28, 23, 1, 5, 163, DateTimeKind.Local).AddTicks(2252), 5000m }
                });

            migrationBuilder.InsertData(
                table: "products",
                columns: new[] { "Id", "Category", "Name", "Price", "Quantity" },
                values: new object[,]
                {
                    { 1, "computers", "product1", 2000m, 10 },
                    { 2, "TV", "product2", 4000m, 20 },
                    { 3, "Watches", "product3", 2000m, 10 },
                    { 4, "Smart Watches", "product4", 2890m, 50 },
                    { 5, "Laptops", "product5", 2900m, 90 }
                });

            migrationBuilder.InsertData(
                table: "cartItems",
                columns: new[] { "Id", "OrderId", "ProductId", "Quantity" },
                values: new object[,]
                {
                    { 1, null, 1, 2 },
                    { 2, null, 2, 3 },
                    { 3, null, 2, 4 },
                    { 4, null, 4, 1 },
                    { 5, null, 3, 4 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_cartItems_OrderId",
                table: "cartItems",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_cartItems_ProductId",
                table: "cartItems",
                column: "ProductId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "cartItems");

            migrationBuilder.DropTable(
                name: "orders");

            migrationBuilder.DropTable(
                name: "products");
        }
    }
}
