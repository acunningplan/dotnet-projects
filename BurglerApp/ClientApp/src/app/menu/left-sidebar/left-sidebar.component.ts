import { Component, OnInit, EventEmitter, Output } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { environment } from "src/environments/environment";
import { MenuService } from "../menu.service";
import { Menu, BurgerItem } from "../menu";
import { Food } from "../ingredients";

@Component({
  selector: "app-left-sidebar",
  templateUrl: "./left-sidebar.component.html",
  styleUrls: ["./left-sidebar.component.css"],
})
export class LeftSidebarComponent implements OnInit {
  menu = new Menu();
  foodTypes = ["burgers", "sides", "drinks"];
  @Output() clickSubcategory = new EventEmitter<{
    category: string;
    foods: Food[];
  }>();

  constructor(private http: HttpClient, private menuService: MenuService) {}

  ngOnInit() {
    this.menu = this.menuService.getMenu();
  }

  preserveOrder = (a: object, b: object): object => a;

  onClickSubcategory(category: string, subCateogory: string) {
    const foods: Food[] = this.menu[category][subCateogory];
    this.clickSubcategory.emit({ category, foods });
  }
}
