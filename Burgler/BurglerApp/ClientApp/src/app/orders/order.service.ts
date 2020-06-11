import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { environment } from "src/environments/environment";
import { map, tap } from "rxjs/operators";
import {
  Order,
  FoodItem,
  BurgerItemJson,
  SideItemJson,
  DrinkItemJson,
} from "./order";
import { OrderJson } from "./orderJson";
import { Food } from "../menu/ingredients";
import { BurgerItem } from "../menu/menu";
import { MenuService } from "../menu/menu.service";

@Injectable({ providedIn: "root" })
export class OrderService {
  private pendingOrder: Order;
  private pastOrders: Order[];
  constructor(private http: HttpClient, private menuService: MenuService) {}

  // Fetch and pre-load pending order
  fetchPendingOrder() {
    return this.http.get<OrderJson[]>(`${environment.serverUrl}/order`).pipe(
      map((orderJson) => {
        this.pendingOrder = new Order(orderJson[0]);
        console.log(`Pending order:`);
        console.log(orderJson);
      })
    );
  }

  fetchPastOrders() {
    return this.http
      .get<OrderJson[]>(`${environment.serverUrl}/order/placed`)
      .pipe(
        map((orderJson) => {
          this.pastOrders = orderJson.map((o) => new Order(o));
          console.log("Logging past orders:");
          console.log(`Past order: ${this.pastOrders}`);
        })
      );
  }

  getPendingOrder(): Order {
    return this.pendingOrder;
  }

  getPastOrders(): Order[] {
    return this.pastOrders;
  }

  updatePendingOrder(pendingOrder: Order) {
    this.pendingOrder = pendingOrder;
    return this.http.patch(`${environment.serverUrl}/order/edit`, pendingOrder);
  }

  addCustomBurgerToPendingOrder(b: BurgerItemJson) {
    this.pendingOrder.customItemCount += 1;
    b.customId = this.pendingOrder.customItemCount;

    this.pendingOrder.burgerItems.push(b);
    return this.updatePendingOrder(this.pendingOrder);
  }

  editCustomBurger(b: BurgerItemJson) {
    const index: number = this.pendingOrder.burgerItems.findIndex(
      (burger) => burger.customId === b.customId
    );

    if (!b.customId) {
      this.pendingOrder.customItemCount += 1;
      b.customId = this.pendingOrder.customItemCount;
    }

    this.pendingOrder.burgerItems[index] = b;
    return this.updatePendingOrder(this.pendingOrder);
  }

  addToPendingOrder(
    food: Food,
    foodType: string,
    option: { size: string; calories: number; price: number }
  ) {
    let foodItemList: FoodItem[];
    let newFoodItem: FoodItem;
    if (foodType === "burgers") {
      foodItemList = this.pendingOrder.burgerItems;
      newFoodItem = new BurgerItemJson(food as BurgerItem, option);
    } else if (foodType === "sides") {
      foodItemList = this.pendingOrder.sideItems;
      newFoodItem = new SideItemJson(food, option);
    } else if (foodType === "drinks") {
      foodItemList = this.pendingOrder.drinkItems;
      newFoodItem = new DrinkItemJson(food, option);
    }
    const foodItem = foodItemList.find(
      (fi) => fi.name === food.name && fi.size === option.size && !fi.customId
    );
    if (!foodItem) {
      foodItemList.push(newFoodItem);
    } else {
      foodItem.quantity += 1;
    }
    return this.updatePendingOrder(this.pendingOrder);
  }

  changeQuantity(
    name: string,
    size: string,
    customId: number = null,
    qty: number
  ) {
    const foodItemTypes = ["burgerItems", "sideItems", "drinkItems"];

    if (!!customId) {
      const bi = this.pendingOrder.burgerItems.find(
        (bi) => bi.customId === customId
      );
      bi.quantity += qty;
    } else {
      for (const foodItemType of foodItemTypes) {
        const food = this.pendingOrder[foodItemType].find(
          (f) => f.name == name && f.size == size
        );
        if (!!food) food.quantity += qty;
      }
    }
    return this.updatePendingOrder(this.pendingOrder);
  }

  deleteFromOrder(name: string, size: string) {
    const foodItemTypes = ["burgerItems", "sideItems", "drinkItems"];
    for (const foodItemType of foodItemTypes) {
      this.pendingOrder[foodItemType] = this.pendingOrder[foodItemType].filter(
        (f) => f.name !== name || f.size !== size
      );
    }
    return this.updatePendingOrder(this.pendingOrder);
  }

  deleteCustomBurgerFromOrder(customId: number) {
    this.pendingOrder.burgerItems = this.pendingOrder.burgerItems.filter(
      (bi) => !bi.customId || (!!bi.customId && bi.customId !== customId)
    );
    return this.updatePendingOrder(this.pendingOrder);
  }

  changeOrderStatus(orderId: string, action: string) {
    let statusChange: number;
    if (action === "placeOrder") {
      statusChange = 0;
    } else if (action === "cancel") {
      statusChange = 1;
    }
    return this.http.patch(
      `${environment.serverUrl}/order/change/${orderId}`,
      {
        statusChange,
      },
      { observe: "response" }
    );
  }

  findBurgerItemPrice(bi: BurgerItemJson) {
    return this.menuService.calculateBurgerPrice(
      {
        bun: bi.burgerBun,
        patty: bi.burgerPatty,
        toppings: bi.burgerToppings.split("+"),
      },
      bi.size
    );
  }

  findSideItemPrice(si: SideItemJson) {
    const menu = this.menuService.getMenu();
    return menu.sideItems.find((s) => s.name === si.name && s.size === si.size)
      .price;
  }

  findDrinkItemPrice(di: DrinkItemJson) {
    const menu = this.menuService.getMenu();
    return menu.drinkItems.find((d) => d.name === di.name && d.size === di.size)
      .price;
  }

  calculateOrderPrice() {
    let total = 0;

    total += this.pendingOrder.burgerItems
      .map((bi) => this.findBurgerItemPrice(bi) * bi.quantity)
      .reduce((a, b) => a + b, 0);
    total += this.pendingOrder.sideItems
      .map((si) => this.findSideItemPrice(si) * si.quantity)
      .reduce((a, b) => a + b, 0);
    total += this.pendingOrder.drinkItems
      .map((di) => this.findDrinkItemPrice(di) * di.quantity)
      .reduce((a, b) => a + b, 0);

    return total;
  }
}
