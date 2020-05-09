import { DrinkItem, SideItem, BurgerItem } from "./order";

export class OrderJson {
  orderId: string;
  orderedAt: Date;
  status: string;
  // readyAt: string;
  // foodTakenAt: string;
  // cancelledAt: string;
  burgerItems: BurgerItem[];
  sideItems: SideItem[];
  drinkItems: DrinkItem[];
}
