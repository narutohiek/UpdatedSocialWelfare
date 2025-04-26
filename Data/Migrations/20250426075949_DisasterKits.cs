using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SocialWelfarre.Data.Migrations
{
    /// <inheritdoc />
    public partial class DisasterKits : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "First_Name",
                table: "DisasterKits");

            migrationBuilder.DropColumn(
                name: "Last_Name",
                table: "DisasterKits");

            migrationBuilder.DropColumn(
                name: "Middle_Name",
                table: "DisasterKits");

            migrationBuilder.DropColumn(
                name: "Validate",
                table: "DisasterKits");

            migrationBuilder.RenameColumn(
                name: "Date_Issued",
                table: "DisasterKits",
                newName: "LastUpdated");

            migrationBuilder.RenameColumn(
                name: "BarangayId",
                table: "DisasterKits",
                newName: "Stock_InsId");

            migrationBuilder.AddColumn<int>(
                name: "StockIn_Boxes",
                table: "DisasterKits",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StockIn_BoxesId",
                table: "DisasterKits",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StockOutById",
                table: "DisasterKits",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StockOut_Boxes",
                table: "DisasterKits",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "StockOut_ById",
                table: "DisasterKits",
                type: "nvarchar(450)",
                nullable: true);

      

            migrationBuilder.CreateIndex(
                name: "IX_DisasterKits_Stock_InsId",
                table: "DisasterKits",
                column: "Stock_InsId");

            migrationBuilder.CreateIndex(
                name: "IX_DisasterKits_StockOut_ById",
                table: "DisasterKits",
                column: "StockOut_ById");

            migrationBuilder.AddForeignKey(
                name: "FK_DisasterKits_AspNetUsers_StockOut_ById",
                table: "DisasterKits",
                column: "StockOut_ById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DisasterKits_StockIn_Stock_InsId",
                table: "DisasterKits",
                column: "Stock_InsId",
                principalTable: "StockIn",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DisasterKits_AspNetUsers_StockOut_ById",
                table: "DisasterKits");

            migrationBuilder.DropForeignKey(
                name: "FK_DisasterKits_StockIn_Stock_InsId",
                table: "DisasterKits");


            migrationBuilder.DropIndex(
                name: "IX_DisasterKits_Stock_InsId",
                table: "DisasterKits");

            migrationBuilder.DropIndex(
                name: "IX_DisasterKits_StockOut_ById",
                table: "DisasterKits");

            migrationBuilder.DropColumn(
                name: "StockIn_Boxes",
                table: "DisasterKits");

            migrationBuilder.DropColumn(
                name: "StockIn_BoxesId",
                table: "DisasterKits");

            migrationBuilder.DropColumn(
                name: "StockOutById",
                table: "DisasterKits");

            migrationBuilder.DropColumn(
                name: "StockOut_Boxes",
                table: "DisasterKits");

            migrationBuilder.DropColumn(
                name: "StockOut_ById",
                table: "DisasterKits");

            migrationBuilder.RenameColumn(
                name: "Stock_InsId",
                table: "DisasterKits",
                newName: "BarangayId");

            migrationBuilder.RenameColumn(
                name: "LastUpdated",
                table: "DisasterKits",
                newName: "Date_Issued");

            migrationBuilder.AddColumn<string>(
                name: "First_Name",
                table: "DisasterKits",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Last_Name",
                table: "DisasterKits",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Middle_Name",
                table: "DisasterKits",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Validate",
                table: "DisasterKits",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
