import { Component, OnInit, Input, OnDestroy } from "@angular/core";
import { Ingredients } from "../ingredients";
import { BurgerItem, Menu } from "../menu";
import { OrderService } from "src/app/orders/order.service";
import { Order, BurgerItemJson } from "src/app/orders/order";
import { MenuService } from "../menu.service";
import { BurgerModalService } from "./burger-modal.service";
import { Subscription } from "rxjs";
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
  calories: number;
  price: number;

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
        this.calories = this.menuService.calculateBurgerCalories(
          burger,
          option.size
        );
        this.price = this.menuService.calculateBurgerPrice(burger, option.size);
        this.editMode = editMode;

        this.formGroup.valueChanges.subscribe(() => {
          const bp = this.getBurgerProps();
          this.calories = this.menuService.calculateBurgerCalories(
            bp,
            option.size
          );
          this.price = this.menuService.calculateBurgerPrice(bp, option.size);
        });
      }
    );
  }

  ngOnDestroy() {
    this.burgerModalSubscription.unsubscribe();
  }

  getBurgerProps() {
    const burgerProps = {
      bun: "",
      patty: "",
      toppings: [""],
      pattyCooked: "",
    };

    burgerProps.bun = this.formGroup.get("burgerBun").value;
    burgerProps.patty = this.formGroup.get("burgerPatty").value;
    burgerProps.pattyCooked = this.formGroup.get("burgerPattyCooked").value;

    const pickedToppings: boolean[] = this.formGroup.get("burgerToppings")
      .value;

    burgerProps.toppings = this.ingredients.toppings
      .filter((ing, index) => pickedToppings[index])
      .map((ing) => ing.name);

    return burgerProps;
  }

  calculateBurgerCalories(): number {
    const bp = this.getBurgerProps();

    let totalCalories = 0;
    totalCalories += this.ingredients.buns.find((b) => b.name === bp.bun)
      .calories;
    totalCalories += this.ingredients.patties.find((p) => p.name === bp.patty)
      .calories;

    for (const topping of bp.toppings) {
      totalCalories += this.ingredients.toppings.find((t) => t.name === topping)
        .calories;
    }
    return totalCalories;
  }

  calculateBurgerPrice(): number {
    const bp = this.getBurgerProps();

    let totalPrice = 1;
    totalPrice += this.ingredients.buns.find((b) => b.name === bp.bun).price;
    totalPrice += this.ingredients.patties.find((p) => p.name === bp.patty)
      .price;
    for (const topping of bp.toppings) {
      totalPrice += this.ingredients.toppings.find((t) => t.name === topping)
        .price;
    }
    return totalPrice;
  }

  addOrEditCustomBurgerToOrder() {
    const { bun, patty, toppings, pattyCooked } = this.getBurgerProps();
    this.customBurgerOrder.burgerBun = bun;
    this.customBurgerOrder.burgerPatty = patty;
    this.customBurgerOrder.burgerToppings = toppings.join("+");
    this.customBurgerOrder.burgerPattyCooked = pattyCooked;

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
