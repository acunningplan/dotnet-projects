import { Component, OnInit, Input } from "@angular/core";
import { OrderService } from "src/app/orders/order.service";
import { Order, FoodItem, BurgerItemJson } from "src/app/orders/order";
import { MenuService } from "../menu.service";
import { Menu, BurgerItem } from "../menu";
import { Burger } from "../menuJson";

@Component({
  selector: "app-right-sidebar",
  templateUrl: "./right-sidebar.component.html",
  styleUrls: ["./right-sidebar.component.css"],
})
export class RightSidebarComponent implements OnInit {
  @Input() order: Order;
  menu: Menu;
  constructor(
    private orderService: OrderService,
    private menuService: MenuService
  ) {}

  ngOnInit() {
    this.menu = this.menuService.getMenu();
  }

  getModalId(foodItem: FoodItem) {
    return "#" + foodItem.name.split(" ").join("") + "-edit";
  }

  getFoodItems() {
    let foodItems: FoodItem[] = [];
    const { burgerItems, sideItems, drinkItems } = this.order;
    foodItems = foodItems
      .concat(burgerItems)
      .concat(sideItems)
      .concat(drinkItems);
    return foodItems;
  }

  getBurgerItem(fi: FoodItem) {
    const bi = fi as BurgerItemJson;

    const burger = new Burger();
    burger.name = bi.name;
    burger.burgerBun = bi.burgerBun;
    burger.burgerPatty = bi.burgerPatty;
    burger.burgerToppings = bi.burgerToppings;

    const burgerItem = new BurgerItem(burger);
    burgerItem.pattyCooked = bi.burgerPattyCooked;

    return burgerItem;
  }

  getBurgerItemOption(burgerItemOrder: FoodItem) {
    const { size, price, calories } = burgerItemOrder;
    return { size, price, calories };
  }

  onDeleteItem(name: string, size: string, customId: number = null) {
    console.log(`Deleting item with id ${customId}`);
    if (!!customId) {
      this.orderService.deleteCustomBurgerFromOrder(customId).subscribe();
    } else {
      this.orderService.deleteFromOrder(name, size).subscribe();
    }
  }

  checkBurgerItem(foodItem: FoodItem): boolean {
    return foodItem.hasOwnProperty("burgerBun");
  }
}
