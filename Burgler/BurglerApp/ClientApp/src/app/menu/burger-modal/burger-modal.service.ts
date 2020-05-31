import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { environment } from "src/environments/environment";
import { map } from "rxjs/operators";
import { Subject } from "rxjs";
import { BurgerItem } from "../menu";

@Injectable({ providedIn: "root" })
export class BurgerModalService {
  burgerModalSubject = new Subject<{
    burger: BurgerItem;
    option: { size: string; calories: number; price: number };
    editMode: boolean;
    customId?: number;
  }>();
}
