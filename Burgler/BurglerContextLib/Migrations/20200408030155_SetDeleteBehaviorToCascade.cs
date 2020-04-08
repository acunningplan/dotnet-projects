using Microsoft.EntityFrameworkCore.Migrations;

namespace BurglerContextLib.Migrations
{
    public partial class SetDeleteBehaviorToCascade : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BurgerItems_Orders_OrderID",
                table: "BurgerItems");

            migrationBuilder.DropForeignKey(
                name: "FK_BurgerToppings_BurgerItems_BurgerItemId",
                table: "BurgerToppings");

            migrationBuilder.DropForeignKey(
                name: "FK_DrinkItems_Orders_OrderID",
                table: "DrinkItems");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_AspNetUsers_UserId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_SideItems_Orders_OrderID",
                table: "SideItems");

            migrationBuilder.AddForeignKey(
                name: "FK_BurgerItems_Orders_OrderID",
                table: "BurgerItems",
                column: "OrderID",
                principalTable: "Orders",
                principalColumn: "OrderID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BurgerToppings_BurgerItems_BurgerItemId",
                table: "BurgerToppings",
                column: "BurgerItemId",
                principalTable: "BurgerItems",
                principalColumn: "BurgerItemId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DrinkItems_Orders_OrderID",
                table: "DrinkItems",
                column: "OrderID",
                principalTable: "Orders",
                principalColumn: "OrderID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_AspNetUsers_UserId",
                table: "Orders",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SideItems_Orders_OrderID",
                table: "SideItems",
                column: "OrderID",
                principalTable: "Orders",
                principalColumn: "OrderID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BurgerItems_Orders_OrderID",
                table: "BurgerItems");

            migrationBuilder.DropForeignKey(
                name: "FK_BurgerToppings_BurgerItems_BurgerItemId",
                table: "BurgerToppings");

            migrationBuilder.DropForeignKey(
                name: "FK_DrinkItems_Orders_OrderID",
                table: "DrinkItems");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_AspNetUsers_UserId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_SideItems_Orders_OrderID",
                table: "SideItems");

            migrationBuilder.AddForeignKey(
                name: "FK_BurgerItems_Orders_OrderID",
                table: "BurgerItems",
                column: "OrderID",
                principalTable: "Orders",
                principalColumn: "OrderID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BurgerToppings_BurgerItems_BurgerItemId",
                table: "BurgerToppings",
                column: "BurgerItemId",
                principalTable: "BurgerItems",
                principalColumn: "BurgerItemId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DrinkItems_Orders_OrderID",
                table: "DrinkItems",
                column: "OrderID",
                principalTable: "Orders",
                principalColumn: "OrderID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_AspNetUsers_UserId",
                table: "Orders",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SideItems_Orders_OrderID",
                table: "SideItems",
                column: "OrderID",
                principalTable: "Orders",
                principalColumn: "OrderID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
