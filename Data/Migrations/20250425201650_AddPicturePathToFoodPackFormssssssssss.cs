using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SocialWelfarre.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddPicturePathToFoodPackFormssssssssss : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PicturePath",
                table: "FoodPackForms");

            migrationBuilder.AddColumn<byte[]>(
                name: "PictureData",
                table: "FoodPackForms",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PictureData",
                table: "FoodPackForms");

            migrationBuilder.AddColumn<string>(
                name: "PicturePath",
                table: "FoodPackForms",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
