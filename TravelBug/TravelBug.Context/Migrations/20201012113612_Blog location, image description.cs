using Microsoft.EntityFrameworkCore.Migrations;

namespace TravelBug.Context.Migrations
{
    public partial class Bloglocationimagedescription : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Alt",
                table: "Images");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Images",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Coordinates",
                table: "Blogs",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "Blogs",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "Coordinates",
                table: "Blogs");

            migrationBuilder.DropColumn(
                name: "Location",
                table: "Blogs");

            migrationBuilder.AddColumn<string>(
                name: "Alt",
                table: "Images",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
