using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BurglerContextLib.Migrations
{
    public partial class Addedpriceandcaloriestoorder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FurtherDescription",
                table: "Orders");

            migrationBuilder.AddColumn<double>(
                name: "Calories",
                table: "Orders",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastEditedAt",
                table: "Orders",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "OrderDescription",
                table: "Orders",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Price",
                table: "Orders",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Calories",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "LastEditedAt",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "OrderDescription",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Orders");

            migrationBuilder.AddColumn<string>(
                name: "FurtherDescription",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
