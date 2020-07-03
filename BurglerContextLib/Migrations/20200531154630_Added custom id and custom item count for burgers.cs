using Microsoft.EntityFrameworkCore.Migrations;

namespace BurglerContextLib.Migrations
{
    public partial class Addedcustomidandcustomitemcountforburgers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CustomItemCount",
                table: "Orders",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CustomId",
                table: "BurgerItems",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CustomItemCount",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "CustomId",
                table: "BurgerItems");
        }
    }
}
