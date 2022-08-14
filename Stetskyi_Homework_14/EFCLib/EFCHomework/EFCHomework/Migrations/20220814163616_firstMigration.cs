using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EFCHomework.Migrations
{
    public partial class firstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Weight = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Height = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Width = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Length = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "Height", "Length", "Weight", "Width" },
                values: new object[,]
                {
                    { 1, "Description 1", 1m, 1m, 1m, 1m },
                    { 2, "Description 2", 2m, 2m, 2m, 2m },
                    { 3, "Description 3", 3m, 3m, 3m, 3m },
                    { 4, "Description 4", 4m, 4m, 4m, 4m },
                    { 5, "Description 5", 5m, 5m, 5m, 5m }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CreatedDate", "ProductId", "Status", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2010, 5, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "NotStarted", new DateTime(2010, 5, 9, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, new DateTime(2011, 5, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Loading", new DateTime(2011, 5, 9, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, new DateTime(2015, 5, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Cancelled", new DateTime(2015, 5, 9, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7, new DateTime(2016, 5, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Done", new DateTime(2016, 5, 9, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, new DateTime(2012, 5, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "InProgress", new DateTime(2012, 5, 9, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, new DateTime(2013, 5, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "Arrived", new DateTime(2013, 5, 9, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, new DateTime(2014, 5, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, "Unloading", new DateTime(2014, 5, 9, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ProductId",
                table: "Products",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
