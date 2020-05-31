import { Component, OnInit, Input, OnDestroy } from "@angular/core";
import { Ingredients } from "../ingredients";
import { BurgerItem, Menu } from "../menu";
import { OrderService } from "src/app/orders/order.service";
import { Order, BurgerItemJson } from "src/app/orders/order";
import { MenuService } from "../menu.service";
import { BurgerModalService } from "./burger-modal.service";
import { Subject, Subscription } from "rxjs";

@Component({
  selector: "app-burger-modal",
  templateUrl: "./burger-modal.component.html",
  styleUrls: ["./burger-modal.component.css"],
})
export class BurgerModalComponent implements OnInit, OnDestroy {
  burger: BurgerItem;
  option: { size: string; calories: number; price: number };
  editMode: boolean;
  customId: number;

  customBurgerOrder: BurgerItemJson;
  order: Order;
  menu: Menu;
  ingredients: Ingredients;

  burgerModalSubscription: Subscription;

  constructor(
    private menuService: MenuService,
    private orderService: OrderService,
    private burgerModalService: BurgerModalService
  ) {}

  ngOnInit() {
    this.order = this.orderService.getPendingOrder();
    this.menu = this.menuService.getMenu();
    this.ingredients = this.menuService.getIngredients();

    this.burgerModalSubscription = this.burgerModalService.burgerModalSubject.subscribe(
      ({ burger, option, editMode, customId }) => {
        this.burger = burger;
        this.customBurgerOrder = new BurgerItemJson(burger, option);
        this.customBurgerOrder.customId = customId;
        this.editMode = editMode;
      }
    );
  }

  ngOnDestroy() {
    this.burgerModalSubscription.unsubscribe();
  }

  checkIfIngredientIsIncluded(ing: string) {
    return !!this.burger.toppings.find((i) => i === ing);
  }

  chooseIng(ing: string, type: string) {
    if (type === "burgerBun") {
      this.customBurgerOrder.burgerBun = ing;
    } else if (type === "burgerToppings") {
      this.customBurgerOrder.addOrRemoveTopping(ing);
    } else if (type === "burgerPatty") {
      this.customBurgerOrder.burgerPatty = ing;
    } else if (type === "burgerPattyCooked") {
      this.customBurgerOrder.burgerPattyCooked = ing;
    }
  }

  addOrEditCustomBurgerToOrder() {
    this.customBurgerOrder.price = this.calculateBurgerPrice();

    if (!this.editMode) {
      this.orderService
        .addCustomBurgerToPendingOrder(this.customBurgerOrder)
        .subscribe((res) => {
          // console.log(this.orderService.getPendingOrder());
        });
    } else {
      this.orderService
        .editCustomBurger(this.customBurgerOrder)
        .subscribe((res) => {
          // console.log(this.orderService.getPendingOrder());
        });
    }
  }

  calculateBurgerPrice(): number {
    if (!this.customBurgerOrder) return 0;
    const { burgerBun, burgerPatty, burgerToppings } = this.customBurgerOrder;

    let totalPrice = 1;
    totalPrice += this.ingredients.buns.find((b) => b.name === burgerBun).price;
    totalPrice += this.ingredients.patties.find((p) => p.name === burgerPatty)
      .price;
    for (const topping of burgerToppings.split("+")) {
      totalPrice += this.ingredients.toppings.find((t) => t.name === topping)
        .price;
    }
    return totalPrice;
  }

  calculateBurgerCalories(): number {
    if (!this.customBurgerOrder) return 0;
    const { burgerBun, burgerPatty, burgerToppings } = this.customBurgerOrder;

    let totalCalories = 0;
    totalCalories += this.ingredients.buns.find((b) => b.name === burgerBun)
      .calories;
    totalCalories += this.ingredients.patties.find(
      (p) => p.name === burgerPatty
    ).calories;

    for (const topping of burgerToppings.split("+")) {
      totalCalories += this.ingredients.toppings.find((t) => t.name === topping)
        .calories;
    }
    return totalCalories;
  }
}
