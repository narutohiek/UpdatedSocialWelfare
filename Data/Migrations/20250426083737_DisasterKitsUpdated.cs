using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SocialWelfarre.Data.Migrations
{
    /// <inheritdoc />
    public partial class DisasterKitsUpdated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DisasterKits_StockIn_Stock_InsId",
                table: "DisasterKits");

            migrationBuilder.DropTable(
                name: "StockIn");

            migrationBuilder.DropIndex(
                name: "IX_DisasterKits_Stock_InsId",
                table: "DisasterKits");

            migrationBuilder.DropColumn(
                name: "StockIn_BoxesId",
                table: "DisasterKits");

            migrationBuilder.DropColumn(
                name: "Stock_InsId",
                table: "DisasterKits");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StockIn_BoxesId",
                table: "DisasterKits",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Stock_InsId",
                table: "DisasterKits",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "StockIn",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quanitity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StockIn", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DisasterKits_Stock_InsId",
                table: "DisasterKits",
                column: "Stock_InsId");

            migrationBuilder.AddForeignKey(
                name: "FK_DisasterKits_StockIn_Stock_InsId",
                table: "DisasterKits",
                column: "Stock_InsId",
                principalTable: "StockIn",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
