import { Component, OnInit, Input, OnDestroy } from "@angular/core";
import { OrderService } from "src/app/orders/order.service";
import { Order, FoodItem, BurgerItemJson } from "src/app/orders/order";
import { MenuService } from "../menu.service";
import { Menu, BurgerItem } from "../menu";
import { Burger } from "../menuJson";
import { BurgerModalService } from "../burger-modal/burger-modal.service";
import { Subscription } from "rxjs";

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
    private menuService: MenuService,
    private burgerModalService: BurgerModalService
  ) {}

  ngOnInit() {
    this.menu = this.menuService.getMenu();
  }

  useModalForBurger(foodItem: FoodItem) {
    if (foodItem.hasOwnProperty("burgerBun")) {
      return "modal";
    }
    return "";
  }

  updateBurgerModal(fi: FoodItem) {
    if (!fi.hasOwnProperty("burgerBun")) return;

    const bi = fi as BurgerItemJson;

    const burger = new Burger();
    burger.name = bi.name;
    burger.burgerBun = bi.burgerBun;
    burger.burgerPatty = bi.burgerPatty;
    burger.burgerToppings = bi.burgerToppings;

    const burgerItem = new BurgerItem(burger);
    burgerItem.pattyCooked = bi.burgerPattyCooked;

    const { size, calories, price } = bi;

    this.burgerModalService.burgerModalSubject.next({
      burger: burgerItem,
      option: { size, calories, price },
      editMode: true,
      customId: bi.customId,
      quantity: bi.quantity
    });
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

  checkOneSize(foodItem: FoodItem) {
    if (
      this.menu.burgerItems.filter((b) => b.name === foodItem.name).length >
        1 ||
      this.menu.sideItems.filter((s) => s.name === foodItem.name).length > 1 ||
      this.menu.drinkItems.filter((d) => d.name === foodItem.name).length > 1
    ) {
      return false;
    }
    return true;
  }

  onChangeQuantity(
    name: string,
    size: string,
    customId: number = null,
    qty: number
  ) {
    this.orderService.changeQuantity(name, size, customId, qty).subscribe();
  }

  onDeleteItem(name: string, size: string, customId: number = null) {
    if (!!customId) {
      this.orderService.deleteCustomBurgerFromOrder(customId).subscribe();
    } else {
      this.orderService.deleteFromOrder(name, size).subscribe();
    }
  }
}
