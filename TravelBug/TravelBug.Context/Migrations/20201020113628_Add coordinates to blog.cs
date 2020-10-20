using Microsoft.EntityFrameworkCore.Migrations;

namespace TravelBug.Context.Migrations
{
    public partial class Addcoordinatestoblog : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Coordinates",
                table: "Blogs",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Coordinates",
                table: "Blogs");
        }
    }
}
