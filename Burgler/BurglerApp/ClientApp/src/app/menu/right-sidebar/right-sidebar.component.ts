import { Component, OnInit, OnDestroy } from "@angular/core";
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
export class RightSidebarComponent implements OnInit, OnDestroy {
  pendingOrder: Order;
  menu: Menu;
  foodItems: FoodItem[];
  totalPrice: string;
  orderSub: Subscription;
  constructor(
    private orderService: OrderService,
    private menuService: MenuService,
    private burgerModalService: BurgerModalService
  ) {}

  ngOnInit() {
    this.menu = this.menuService.getMenu();
    this.pendingOrder = this.orderService.getPendingOrder();
    this.loadFoodItems(this.pendingOrder);
    this.totalPrice = this.orderService.calculateOrderPrice();
    this.orderSub = this.orderService.pendingOrderSubject.subscribe((order) => {
      this.loadFoodItems(order);
      this.totalPrice = this.orderService.calculateOrderPrice();
    });
  }

  ngOnDestroy() {
    this.orderSub.unsubscribe();
  }

  loadFoodItems(order: Order) {
    const { burgerItems, sideItems, drinkItems } = order;
    this.foodItems = []
      .concat(burgerItems)
      .concat(sideItems)
      .concat(drinkItems);
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
      quantity: bi.quantity,
    });
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
