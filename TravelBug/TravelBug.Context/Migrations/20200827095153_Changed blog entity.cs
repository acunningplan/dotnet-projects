using Microsoft.EntityFrameworkCore.Migrations;

namespace TravelBug.Context.Migrations
{
    public partial class Changedblogentity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImgurId",
                table: "Images",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImgurId",
                table: "Images");
        }
    }
}
