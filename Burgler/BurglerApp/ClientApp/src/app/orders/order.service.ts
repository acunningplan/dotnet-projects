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

@Injectable({ providedIn: "root" })
export class OrderService {
  private pendingOrder: Order;
  private pastOrders: Order[];
  constructor(private http: HttpClient) {}

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

  addToOrder(food: Food, foodType: string, size: string) {
    const option = food.options.find((option) => option.size === size);
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
      (fi) => fi.name === food.name && fi.size === size
    );
    if (!foodItem) {
      foodItemList.push(newFoodItem);
    } else {
      foodItem.quantity += 1;
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
}
