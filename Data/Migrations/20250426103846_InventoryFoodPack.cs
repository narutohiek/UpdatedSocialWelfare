using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SocialWelfarre.Data.Migrations
{
    /// <inheritdoc />
    public partial class InventoryFoodPack : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FoodPacksInventories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicationFoodPackId = table.Column<int>(type: "int", nullable: false),
                    AvailableStocks = table.Column<int>(type: "int", nullable: false),
                    StockOut = table.Column<int>(type: "int", nullable: false),
                    TotalAvailableStocks = table.Column<int>(type: "int", nullable: false),
                    TransactionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TransactionTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodPacksInventories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FoodPacksInventories_ApplicationFoodPack_ApplicationFoodPackId",
                        column: x => x.ApplicationFoodPackId,
                        principalTable: "ApplicationFoodPack",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FoodPacksInventories_ApplicationFoodPackId",
                table: "FoodPacksInventories",
                column: "ApplicationFoodPackId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FoodPacksInventories");
        }
    }
}
