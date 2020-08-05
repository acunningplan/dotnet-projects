import { Component, OnInit } from "@angular/core";
import { OrderService } from "../orders/order.service";
import { MenuService } from "./menu.service";
import { Menu, BurgerItem } from "./menu";
import { Food } from "./ingredients";
import { BurgerModalService } from "./burger-modal/burger-modal.service";
import { LoadingService } from "../loading/loading.service";

@Component({
  selector: "app-menu",
  templateUrl: "./menu.component.html",
  styleUrls: ["./menu.component.css"],
})
export class MenuComponent implements OnInit {
  menu: Menu;
  foodsToDisplay: Food[];
  foodType: string;
  showBurgerModal = false;

  customisedBurger: BurgerItem;

  constructor(
    private menuService: MenuService,
    private orderService: OrderService,
    private burgerModalService: BurgerModalService,
    private loadingService: LoadingService
  ) {}

  ngOnInit() {
    this.menu = this.menuService.getMenu();
    this.loadingService.loadingSubject.next({ loading: false });
  }

  preserveOrder = (a) => a;

  addBurgerToOrder(
    burger: BurgerItem,
    option: { size: string; calories: number; price: number }
  ) {
    this.orderService.addToPendingOrder(burger, "burgers", option).subscribe();
  }

  clickSubcategory(e: { foods: Food[]; category: string }) {
    this.foodsToDisplay = e.foods;
    this.foodType = e.category;
  }

  addFoodToOrder(
    name: string,
    option: { size: string; calories: number; price: number }
  ) {
    const food = this.foodsToDisplay.find((bi) => bi.name === name);
    this.orderService
      .addToPendingOrder(food, this.foodType, option)
      .subscribe();
  }

  updateBurgerModal(
    burger: BurgerItem,
    option: { size: string; calories: number; price: number }
  ) {
    const newBurger = new BurgerItem(
      this.menu.burgerItems.find((b) => b.name === burger.name)
    );
    this.burgerModalService.burgerModalSubject.next({
      burger: newBurger,
      option,
      editMode: false,
    });
  }
}
