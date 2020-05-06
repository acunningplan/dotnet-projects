import { Component, OnInit } from "@angular/core";
import { OrderService } from "../orders/order.service";
import {
  Order,
  BurgerItem,
  SideItem,
  DrinkItem,
  FoodItem,
} from "../orders/order";
import { MenuService } from "./menu.service";
import { Menu } from "./menu";
import { Food } from "./ingredients";

@Component({
  selector: "app-menu",
  templateUrl: "./menu.component.html",
  styleUrls: ["./menu.component.css"],
})
export class MenuComponent implements OnInit {
  menu: Menu;
  order: Order;
  foodsToDisplay: Food[];
  foodType: string;
  constructor(menuService: MenuService, private orderService: OrderService) {
    this.menu = menuService.getMenu();
    this.order = orderService.getPendingOrder();
  }

  ngOnInit() {}

  preserveOrder = (a, b) => a;

  onClick() {}

  clickSubcategory({ foods, category }) {
    this.foodsToDisplay = foods;
    this.foodType = category;
  }

  addFoodToOrder(name: string, size: string) {
    const food = this.foodsToDisplay.find((bi) => bi.name === name);
    const option = food.options.find((option) => option.size === size);
    let foodItemList: FoodItem[];
    let newFoodItem: FoodItem;
    if (this.foodType === "burgers") {
      foodItemList = this.order.burgerItems;
      newFoodItem = new BurgerItem(food, option);
    } else if (this.foodType === "sides") {
      foodItemList = this.order.sideItems;
      newFoodItem = new SideItem(food, option);
    } else if (this.foodType === "drinks") {
      foodItemList = this.order.drinkItems;
      newFoodItem = new DrinkItem(food, option);
    }
    const foodItem = foodItemList.find(
      (fi) => fi.name === food.name && fi.size === option.size
    );
    if (!foodItem) {
      foodItemList.push(newFoodItem);
    } else {
      foodItem.quantity += 1;
    }
    this.orderService.updatePendingOrder(this.order);
  }

  deleteItem() {
    this.order.sideItems = this.order.sideItems.filter(
      (si) => si.name !== "Hot Chips"
    );
    this.orderService.updatePendingOrder(this.order);
  }
}
