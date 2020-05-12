using Microsoft.EntityFrameworkCore.Migrations;

namespace BurglerContextLib.Migrations
{
    public partial class DefaultCaloriesandPriceinBurger : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Calories",
                table: "Burgers",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Price",
                table: "Burgers",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Calories",
                table: "Burgers");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Burgers");
        }
    }
}
