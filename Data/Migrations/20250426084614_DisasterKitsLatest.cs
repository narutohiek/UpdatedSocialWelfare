using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SocialWelfarre.Data.Migrations
{
    /// <inheritdoc />
    public partial class DisasterKitsLatest : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DisasterKits");

            migrationBuilder.CreateTable(
                name: "DisasterKitTransactions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Barangay = table.Column<int>(type: "int", nullable: false),
                    Reason = table.Column<int>(type: "int", nullable: false),
                    TransactionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TransactionTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    NumberOfPacks = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DisasterKitTransactions", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DisasterKitTransactions");

            migrationBuilder.CreateTable(
                name: "DisasterKits",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StockOut_ById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Barangay = table.Column<int>(type: "int", nullable: false),
                    LastUpdated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StockIn_Boxes = table.Column<int>(type: "int", nullable: false),
                    StockOutById = table.Column<int>(type: "int", nullable: false),
                    StockOut_Boxes = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DisasterKits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DisasterKits_AspNetUsers_StockOut_ById",
                        column: x => x.StockOut_ById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_DisasterKits_StockOut_ById",
                table: "DisasterKits",
                column: "StockOut_ById");
        }
    }
}
