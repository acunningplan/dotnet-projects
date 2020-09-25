import { Injectable } from "@angular/core";
import { Router, RoutesRecognized } from "@angular/router";
import { filter } from "rxjs/operators";

@Injectable({
  providedIn: "root",
})
export class RouterTrackingService {
  constructor(private router: Router) {
    router.events
      .pipe(filter((event) => event instanceof RoutesRecognized))
      .subscribe((val) => {
        // see also
        console.log("Subscribing to router events:");
        console.log(val);
        // console.log(val instanceof RoutesRecognized);
      });
  }
}
