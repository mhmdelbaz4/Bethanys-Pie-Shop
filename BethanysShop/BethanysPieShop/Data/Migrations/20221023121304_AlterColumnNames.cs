using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BethanysPieShop.Data.Migrations
{
    public partial class AlterColumnNames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ImageURL",
                table: "Pies",
                newName: "ImageUrl");

            migrationBuilder.RenameColumn(
                name: "ImageThumbnailURL",
                table: "Pies",
                newName: "ImageThumbnailUrl");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Categories",
                newName: "CategoryName");

            migrationBuilder.AlterColumn<string>(
                name: "LongDescription",
                table: "Pies",
                type: "nvarchar(3000)",
                maxLength: 3000,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500);

            migrationBuilder.AddColumn<string>(
                name: "AllergyInformation",
                table: "Pies",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AllergyInformation",
                table: "Pies");

            migrationBuilder.RenameColumn(
                name: "ImageUrl",
                table: "Pies",
                newName: "ImageURL");

            migrationBuilder.RenameColumn(
                name: "ImageThumbnailUrl",
                table: "Pies",
                newName: "ImageThumbnailURL");

            migrationBuilder.RenameColumn(
                name: "CategoryName",
                table: "Categories",
                newName: "Name");

            migrationBuilder.AlterColumn<string>(
                name: "LongDescription",
                table: "Pies",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(3000)",
                oldMaxLength: 3000);
        }
    }
}
