import { Directive, TemplateRef, ViewContainerRef, Input } from "@angular/core";
import { MenuService } from "./menu.service";
import { FoodItem } from "../orders/order";

@Directive({
  selector: "[checkOneSize]",
})
export class CheckOneSizeDirective {
  @Input() set checkOneSize(foodItem: FoodItem) {
    const condition =
      !this.menuService.checkOneSize(foodItem.name) && !foodItem.customId;

    if (condition) {
      this.vcRef.createEmbeddedView(this.tempRef);
    } else {
      this.vcRef.clear();
    }
  }

  constructor(
    private tempRef: TemplateRef<any>,
    private vcRef: ViewContainerRef,
    private menuService: MenuService
  ) {}
}
