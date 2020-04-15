using Microsoft.EntityFrameworkCore.Migrations;

namespace BurglerContextLib.Migrations
{
    public partial class AddedStaffcolumntoAppUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BurgerPattySize",
                table: "BurgerItems");

            migrationBuilder.AddColumn<string>(
                name: "Staff",
                table: "AspNetUsers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Staff",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<string>(
                name: "BurgerPattySize",
                table: "BurgerItems",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
