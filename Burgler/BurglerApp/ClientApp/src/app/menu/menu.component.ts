import { Component, OnInit } from "@angular/core";
import { OrderService } from "../orders/order.service";
import { Order, SideItem } from "../orders/order";
import { MenuService } from "./menu.service";
import { Menu } from "./menu";

@Component({
  selector: "app-menu",
  templateUrl: "./menu.component.html",
  styleUrls: ["./menu.component.css"],
})
export class MenuComponent implements OnInit {
  menu: Menu;
  constructor(menuService: MenuService, private orderService: OrderService) {
    this.menu = menuService.getMenu()
  }

  ngOnInit() {}
  onClick() {}
  addToOrder() {
    const order = this.orderService.getPendingOrder()
    const sideItem = new SideItem();
    sideItem.name = "Hot Chips"
    sideItem.size = "Large"
    order.sideItems.push(sideItem)
    this.orderService.updatePendingOrder(order)
  }
}
