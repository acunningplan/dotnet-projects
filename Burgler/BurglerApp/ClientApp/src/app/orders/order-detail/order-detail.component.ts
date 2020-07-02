import { Component, OnInit, Input, OnDestroy } from "@angular/core";
import { Order, FoodItem } from "../order";
import { OrderService } from "../order.service";
import { OrderConfirmationService } from "../order-confirmation/order-confirmation.service";
import { Subscription } from "rxjs";
import * as moment from "moment";

@Component({
  selector: "app-order-detail",
  templateUrl: "./order-detail.component.html",
  styleUrls: ["./order-detail.component.css"],
})
export class OrderDetailComponent implements OnInit, OnDestroy {
  @Input() order: Order;
  @Input() status: string;
  pendingOrderSubscription: Subscription;
  foodItems: FoodItem[];
  orderEmpty = true;
  price: number;
  allowedPickupTimes = [...Array(12).keys()].map((t) => (t + 1) * 15);
  pickupTime = this.allowedPickupTimes[0];

  constructor(
    private orderService: OrderService,
    private orderConfirmationService: OrderConfirmationService
  ) {}

  ngOnInit(): void {
    this.updateProps(this.order);
    if (this.status === "pending")
      this.pendingOrderSubscription = this.orderService.pendingOrderSubject.subscribe(
        (order: Order) => this.updateProps(order)
      );
  }

  ngOnDestroy() {
    this.pendingOrderSubscription?.unsubscribe();
  }

  private updateProps(order: Order) {
    this.order = order;
    this.order.totalPrice = this.orderService.calculateOrderPrice(order);
    this.price = +this.order.totalPrice;
    this.orderEmpty = this.checkOrderEmpty(order);
    this.foodItems = this.getFoodItems(order);
  }

  private getFoodItems(order: Order): FoodItem[] {
    return [].concat(order.burgerItems, order.sideItems, order.drinkItems);
  }

  private checkOrderEmpty(order: Order): boolean {
    return !order.burgerItems[0] && !order.sideItems[0] && !order.drinkItems[0];
  }

  confirmOrder(mode: string) {
    if (this.status === "pending") {
      const pickupDateTime = moment(Date.now())
        .add(this.pickupTime, "m")
        .toDate();
      this.order.pickupTime = pickupDateTime;
    }

    console.log(this.order);

    this.orderConfirmationService.orderConfirmationSubject.next({
      order: this.order,
      mode,
    });
  }
}
