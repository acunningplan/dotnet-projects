import { Component, OnInit, Input } from "@angular/core";
import { Ingredients } from "../ingredients";
import { BurgerItem, Menu } from "../menu";
import { OrderService } from "src/app/orders/order.service";
import { Order, BurgerItemJson } from "src/app/orders/order";
import { MenuService } from "../menu.service";

@Component({
  selector: "app-burger-modal",
  templateUrl: "./burger-modal.component.html",
  styleUrls: ["./burger-modal.component.css"],
})
export class BurgerModalComponent implements OnInit {
  @Input() burger: BurgerItem;
  @Input() option: { size: string; calories: number; price: number };
  @Input() editMode: boolean;
  customBurgerOrder: BurgerItemJson;
  order: Order;
  menu: Menu;
  ingredients: Ingredients;

  constructor(
    private menuService: MenuService,
    private orderService: OrderService
  ) {}

  ngOnInit() {
    this.order = this.orderService.getPendingOrder();
    this.menu = this.menuService.getMenu();
    this.ingredients = this.menuService.getIngredients();
    this.customBurgerOrder = new BurgerItemJson(this.burger, this.option);
  }

  getModalId() {
    if (!this.editMode) {
      return this.burger.name.split(" ").join("");
    } else {
      return this.burger.name.split(" ").join("") + "-edit";
    }
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
      this.customBurgerOrder.burgerPattyCooked = +ing;
    }
  }

  addCustomBurgerToOrder(editMode: boolean) {
    this.customBurgerOrder.price = this.calculateBurgerPrice();

    if (!editMode) {
      this.orderService
        .addCustomBurgerToPendingOrder(this.customBurgerOrder)
        .subscribe((res) => {
          console.log(this.orderService.getPendingOrder());
        });
    } else {
      this.orderService
        .editCustomBurger(this.customBurgerOrder)
        .subscribe((res) => {
          console.log(this.orderService.getPendingOrder());
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

    console.log(burgerToppings.split("+"));
    for (const topping of burgerToppings.split("+")) {
      totalCalories += this.ingredients.toppings.find((t) => t.name === topping)
        .calories;
    }
    return totalCalories;
  }
}
