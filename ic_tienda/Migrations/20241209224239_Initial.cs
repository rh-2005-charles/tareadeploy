using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ic_tienda_presentation.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false),
                    Description = table.Column<string>(type: "longtext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    TotalAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Status = table.Column<string>(type: "longtext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Stock = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "longtext", nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "OrderProducts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderProducts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderProducts_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderProducts_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Teléfonos avanzados.", "Smartphones" },
                    { 2, "Computadoras portátiles.", "Laptops" },
                    { 3, "Dispositivos de audio.", "Auriculares" },
                    { 4, "Pantallas táctiles.", "Tablets" },
                    { 5, "Relojes con funciones smart.", "Relojes inteligentes" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Description", "Name", "Price", "Stock" },
                values: new object[,]
                {
                    { 1, 1, "Cámara 12MP.", "iPhone 13", 799.99m, 50 },
                    { 2, 1, "Pantalla 120Hz.", "Samsung Galaxy S21", 699.99m, 60 },
                    { 3, 1, "Cámara 48MP.", "OnePlus 9", 729.99m, 45 },
                    { 4, 1, "Cámara avanzada.", "Google Pixel 6", 599.99m, 30 },
                    { 5, 2, "i7 ultradelgada.", "Dell XPS 13", 999.99m, 40 },
                    { 6, 2, "Batería de 15 horas.", "MacBook Air M1", 999.00m, 35 },
                    { 7, 2, "Pantalla 4K.", "HP Spectre x360", 1299.99m, 20 },
                    { 8, 2, "Teclado retroiluminado.", "Lenovo ThinkPad X1", 1499.99m, 15 },
                    { 9, 3, "Cancelación de ruido.", "Bose QC35", 299.99m, 80 },
                    { 10, 3, "Cancelación activa.", "Sony WH-1000XM4", 349.99m, 70 },
                    { 11, 3, "Sonido claro.", "JBL 650BT", 129.99m, 100 },
                    { 12, 3, "Audio de alta calidad.", "Sennheiser Momentum", 299.99m, 60 },
                    { 13, 4, "Pantalla Retina.", "iPad Pro 11", 799.99m, 40 },
                    { 14, 4, "Pantalla 120Hz.", "Samsung Galaxy Tab S7", 649.99m, 50 },
                    { 15, 4, "Con pantalla táctil.", "Microsoft Surface Pro 7", 899.99m, 30 },
                    { 16, 5, "GPS integrado.", "Garmin Venu 2", 249.99m, 100 },
                    { 17, 5, "Pantalla siempre encendida.", "Apple Watch Series 7", 399.99m, 50 },
                    { 18, 5, "Monitoreo de salud.", "Fitbit Sense", 299.99m, 60 },
                    { 19, 5, "Pantalla AMOLED.", "Amazfit GTR 3", 179.99m, 80 },
                    { 20, 5, "Cámara de acción.", "GoPro Hero 9", 399.99m, 60 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderProducts_OrderId",
                table: "OrderProducts",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderProducts_ProductId",
                table: "OrderProducts",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderProducts");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
