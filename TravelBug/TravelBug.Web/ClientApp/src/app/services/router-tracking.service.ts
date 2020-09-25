import { Injectable } from "@angular/core";
import { Router, RoutesRecognized } from "@angular/router";
import { Subject } from "rxjs";
import { filter, pairwise } from "rxjs/operators";

@Injectable({
  providedIn: "root",
})
export class RouterTrackingService {
  prevUrl : string;
  urlSubject = new Subject<RoutesRecognized[]>();

  constructor(private router: Router) {
    router.events
      .pipe(
        filter((evt: any) => evt instanceof RoutesRecognized),
        pairwise()
      )
      .subscribe((events: RoutesRecognized[]) => {
        this.urlSubject.next(events);
        this.prevUrl = events[0].url;
      });
  }
}
