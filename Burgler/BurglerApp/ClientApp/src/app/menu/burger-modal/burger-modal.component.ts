import { Component, OnInit, Input, OnDestroy } from "@angular/core";
import { Ingredients } from "../ingredients";
import { BurgerItem, Menu } from "../menu";
import { OrderService } from "src/app/orders/order.service";
import { Order, BurgerItemJson } from "src/app/orders/order";
import { MenuService } from "../menu.service";
import { BurgerModalService } from "./burger-modal.service";
import { Subject, Subscription } from "rxjs";
import { FormGroup, FormControl, FormArray } from "@angular/forms";

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

  formGroup: FormGroup;

  customBurgerOrder: BurgerItemJson;
  // calories: number;
  // price: number;

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
        this.formGroup = new FormGroup({
          burgerBun: new FormControl(burger.bun),
          burgerToppings: new FormArray(
            this.ingredients.toppings.map(
              (t) =>
                new FormControl(!!burger.toppings.find((bt) => bt === t.name))
            )
          ),
          burgerPatty: new FormControl(burger.patty),
          burgerPattyCooked: new FormControl(burger.pattyCooked),
        });

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

  onSubmit() {
    console.log("Submitting");
    console.log(this.formGroup);
  }
  // checkIfIngredientIsIncluded(ing: string, type: string): boolean {
  //   if (type === "burgerBun") {
  //     console.log(this.burger.bun);
  //     return ing === this.burger.bun;
  //   } else if (type === "burgerToppings") {
  //     return !!this.burger.toppings.find((i) => i === ing);
  //   } else if (type === "burgerPatty") {
  //     return ing === this.burger.patty;
  //   } else if (type === "burgerPattyCooked") {
  //     return ing === this.burger.pattyCooked;
  //   }
  //   return false;
  // }

  // chooseIng(ing: string, type: string) {
  //   if (type === "burgerBun") {
  //     this.customBurgerOrder.burgerBun = ing;
  //   } else if (type === "burgerToppings") {
  //     this.customBurgerOrder.addOrRemoveTopping(ing);
  //   } else if (type === "burgerPatty") {
  //     this.customBurgerOrder.burgerPatty = ing;
  //   } else if (type === "burgerPattyCooked") {
  //     this.customBurgerOrder.burgerPattyCooked = ing;
  //   }
  // }

  getBurgerProps() {
    const burgerProps = {
      burgerBun: "",
      burgerPatty: "",
      burgerToppings: "",
      burgerPattyCooked: "",
    };

    burgerProps.burgerBun = this.formGroup.get("burgerBun").value;
    burgerProps.burgerPatty = this.formGroup.get("burgerPatty").value;
    burgerProps.burgerPattyCooked = this.formGroup.get(
      "burgerPattyCooked"
    ).value;

    const pickedToppings: boolean[] = this.formGroup.get("burgerToppings")
      .value;

    burgerProps.burgerToppings = this.ingredients.toppings
      .filter((ing, index) => pickedToppings[index])
      .map((ing) => ing.name)
      .join("+");

    return burgerProps;
  }

  calculateBurgerCalories(): number {
    if (!this.customBurgerOrder || !this.getBurgerProps().burgerBun) return 0;
    const { burgerBun, burgerPatty, burgerToppings } = this.getBurgerProps();

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

  calculateBurgerPrice(): number {
    if (!this.customBurgerOrder || !this.getBurgerProps().burgerBun) return 0;
    const { burgerBun, burgerPatty, burgerToppings } = this.getBurgerProps();

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

  addOrEditCustomBurgerToOrder() {
    const burgerProps = this.getBurgerProps();
    for (const prop in burgerProps) {
      this.customBurgerOrder[prop] = burgerProps[prop];
    }

    this.customBurgerOrder.price = this.calculateBurgerPrice();

    if (!this.editMode) {
      this.orderService
        .addCustomBurgerToPendingOrder(this.customBurgerOrder)
        .subscribe();
    } else {
      this.orderService.editCustomBurger(this.customBurgerOrder).subscribe();
    }
  }
}
