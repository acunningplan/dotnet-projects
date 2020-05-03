import { DrinkItem, SideItem, BurgerItem } from "./order";

export class OrderJson {
  orderId: string;
  burgerItems: BurgerItem[];
  sideItems: SideItem[];
  drinkItems: DrinkItem[];
}
