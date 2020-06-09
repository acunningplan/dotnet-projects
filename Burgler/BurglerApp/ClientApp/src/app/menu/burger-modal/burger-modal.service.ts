import { Injectable } from "@angular/core";
import { Subject } from "rxjs";
import { BurgerItem } from "../menu";

@Injectable({ providedIn: "root" })
export class BurgerModalService {
  burgerModalSubject = new Subject<{
    burger: BurgerItem;
    option: { size: string; calories: number; price: number };
    editMode: boolean;
    customId?: number;
    quantity?: number;
  }>();
}
