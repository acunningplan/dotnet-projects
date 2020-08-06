import { Component, OnInit, OnDestroy } from "@angular/core";
import { Subscription } from "rxjs";
import { LoadingService } from "./loading/loading.service";
import { Router } from "@angular/router";

@Component({
  selector: "app-root",
  templateUrl: "./app.component.html",
  styleUrls: ["./app.component.css"],
})
export class AppComponent implements OnInit, OnDestroy {
  loadingSub: Subscription;
  loading = false;
  loadingText = "Loading...";
  url = "";

  constructor(private loadingService: LoadingService, private router: Router) {
    router.events.subscribe(() => (this.url = this.router.url));
  }

  ngOnInit() {
    this.loadingSub = this.loadingService.loadingSubject.subscribe(
      (loadingData) => {
        this.loading = loadingData.loading;
        this.loadingText = loadingData.loadingText;
      }
    );
  }

  ngOnDestroy() {
    this.loadingSub.unsubscribe();
  }
}
