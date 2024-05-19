using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InventoryManager_Data.Migrations
{
    public partial class _ : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_ProductManagers_ProductManagerId",
                table: "Products");

            migrationBuilder.DropTable(
                name: "ProductManagers");

            migrationBuilder.DropIndex(
                name: "IX_Products_ProductManagerId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ProductManagerId",
                table: "Products");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ProductManagerId",
                table: "Products",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ProductManagers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductManagers", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductManagerId",
                table: "Products",
                column: "ProductManagerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ProductManagers_ProductManagerId",
                table: "Products",
                column: "ProductManagerId",
                principalTable: "ProductManagers",
                principalColumn: "Id");
        }
    }
}
