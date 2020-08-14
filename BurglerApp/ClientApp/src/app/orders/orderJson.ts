import { DrinkItemJson, SideItemJson, BurgerItemJson } from "./order";

export class OrderJson {
  orderId: string;
  orderedAt: Date;
  status: string;
  // readyAt: string;
  // foodTakenAt: string;
  // cancelledAt: string;
  burgerItems: BurgerItemJson[];
  sideItems: SideItemJson[];
  drinkItems: DrinkItemJson[];

  customItemCount: number;
}
