using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SocialWelfarre.Data.Migrations
{
    /// <inheritdoc />
    public partial class newsss : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BarangayCertificatePath",
                table: "FoodPackForms");

            migrationBuilder.DropColumn(
                name: "ValidIdPath",
                table: "FoodPackForms");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BarangayCertificatePath",
                table: "FoodPackForms",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ValidIdPath",
                table: "FoodPackForms",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
