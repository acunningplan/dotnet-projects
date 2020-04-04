using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BurglerContextLib.Migrations
{
    public partial class SetEntityRelationships : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FoodOrder");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Orders",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "BurgerItems",
                columns: table => new
                {
                    BurgerItemId = table.Column<Guid>(nullable: false),
                    Quantity = table.Column<double>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    BurgerBun = table.Column<string>(nullable: true),
                    BurgerPatty = table.Column<string>(nullable: true),
                    BurgerPattyCooked = table.Column<int>(nullable: false),
                    OrderID = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BurgerItems", x => x.BurgerItemId);
                    table.ForeignKey(
                        name: "FK_BurgerItems_Orders_OrderID",
                        column: x => x.OrderID,
                        principalTable: "Orders",
                        principalColumn: "OrderID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DrinkItems",
                columns: table => new
                {
                    DrinkItemId = table.Column<Guid>(nullable: false),
                    Quantity = table.Column<double>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Volume = table.Column<double>(nullable: false),
                    OrderID = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DrinkItems", x => x.DrinkItemId);
                    table.ForeignKey(
                        name: "FK_DrinkItems_Orders_OrderID",
                        column: x => x.OrderID,
                        principalTable: "Orders",
                        principalColumn: "OrderID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SideItems",
                columns: table => new
                {
                    SideItemId = table.Column<Guid>(nullable: false),
                    Quantity = table.Column<double>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Size = table.Column<string>(nullable: true),
                    OrderID = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SideItems", x => x.SideItemId);
                    table.ForeignKey(
                        name: "FK_SideItems_Orders_OrderID",
                        column: x => x.OrderID,
                        principalTable: "Orders",
                        principalColumn: "OrderID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BurgerToppings",
                columns: table => new
                {
                    BurgerToppingId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    BurgerItemId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BurgerToppings", x => x.BurgerToppingId);
                    table.ForeignKey(
                        name: "FK_BurgerToppings_BurgerItems_BurgerItemId",
                        column: x => x.BurgerItemId,
                        principalTable: "BurgerItems",
                        principalColumn: "BurgerItemId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserId",
                table: "Orders",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_BurgerItems_OrderID",
                table: "BurgerItems",
                column: "OrderID");

            migrationBuilder.CreateIndex(
                name: "IX_BurgerToppings_BurgerItemId",
                table: "BurgerToppings",
                column: "BurgerItemId");

            migrationBuilder.CreateIndex(
                name: "IX_DrinkItems_OrderID",
                table: "DrinkItems",
                column: "OrderID");

            migrationBuilder.CreateIndex(
                name: "IX_SideItems_OrderID",
                table: "SideItems",
                column: "OrderID");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_AspNetUsers_UserId",
                table: "Orders",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_AspNetUsers_UserId",
                table: "Orders");

            migrationBuilder.DropTable(
                name: "BurgerToppings");

            migrationBuilder.DropTable(
                name: "DrinkItems");

            migrationBuilder.DropTable(
                name: "SideItems");

            migrationBuilder.DropTable(
                name: "BurgerItems");

            migrationBuilder.DropIndex(
                name: "IX_Orders_UserId",
                table: "Orders");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "FoodOrder",
                columns: table => new
                {
                    FoodOrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrderID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodOrder", x => x.FoodOrderId);
                    table.ForeignKey(
                        name: "FK_FoodOrder_Orders_OrderID",
                        column: x => x.OrderID,
                        principalTable: "Orders",
                        principalColumn: "OrderID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FoodOrder_OrderID",
                table: "FoodOrder",
                column: "OrderID");
        }
    }
}
