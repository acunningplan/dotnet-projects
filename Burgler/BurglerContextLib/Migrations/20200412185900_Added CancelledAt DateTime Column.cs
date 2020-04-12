using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BurglerContextLib.Migrations
{
    public partial class AddedCancelledAtDateTimeColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cancelled",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Volume",
                table: "DrinkItems");

            migrationBuilder.AddColumn<DateTime>(
                name: "CancelledAt",
                table: "Orders",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Size",
                table: "DrinkItems",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BurgerPattySize",
                table: "BurgerItems",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Size",
                table: "BurgerItems",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CancelledAt",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Size",
                table: "DrinkItems");

            migrationBuilder.DropColumn(
                name: "BurgerPattySize",
                table: "BurgerItems");

            migrationBuilder.DropColumn(
                name: "Size",
                table: "BurgerItems");

            migrationBuilder.AddColumn<bool>(
                name: "Cancelled",
                table: "Orders",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<double>(
                name: "Volume",
                table: "DrinkItems",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
