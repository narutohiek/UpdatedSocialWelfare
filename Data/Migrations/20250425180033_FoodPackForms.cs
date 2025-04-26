using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SocialWelfarre.Data.Migrations
{
    /// <inheritdoc />
    public partial class FoodPackForms : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BarangayCertificateFileName",
                table: "FoodPackForms");

            migrationBuilder.DropColumn(
                name: "BrgyID",
                table: "FoodPackForms");

            migrationBuilder.DropColumn(
                name: "ReasonID",
                table: "FoodPackForms");

            migrationBuilder.RenameColumn(
                name: "ValidIdFileName",
                table: "FoodPackForms",
                newName: "ValidIdPath");

            migrationBuilder.RenameColumn(
                name: "Reason",
                table: "FoodPackForms",
                newName: "BarangayCertificatePath");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ValidIdPath",
                table: "FoodPackForms",
                newName: "ValidIdFileName");

            migrationBuilder.RenameColumn(
                name: "BarangayCertificatePath",
                table: "FoodPackForms",
                newName: "Reason");

            migrationBuilder.AddColumn<string>(
                name: "BarangayCertificateFileName",
                table: "FoodPackForms",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "BrgyID",
                table: "FoodPackForms",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ReasonID",
                table: "FoodPackForms",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
