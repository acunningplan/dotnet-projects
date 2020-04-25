import { Component, OnInit } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { environment } from "src/environments/environment";
import { MenuService } from "../menu.service";
import { Menu } from "../menu";

@Component({
  selector: "app-left-sidebar",
  templateUrl: "./left-sidebar.component.html",
  styleUrls: ["./left-sidebar.component.css"],
})
export class LeftSidebarComponent implements OnInit {
  menu: Menu;

  constructor(private http: HttpClient, private menuService: MenuService) {}

  ngOnInit() {
    this.menu = this.menuService.getMenu();
  }

  preserveOrder = (a: object, b: object): object => a;

  onClickSubcategory(subcategory: MenuItem[]) {}
}

interface MenuItem {
  description: string;
  calories: number;
  price: number;
  image: string;
}
