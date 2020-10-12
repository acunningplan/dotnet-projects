import { Component, OnInit } from "@angular/core";
import { ActivatedRoute } from "@angular/router";
import { Subscription } from "rxjs";
import { LoadingService } from "./services/loading.service";
import { ProfileService } from "./services/profile.service";

@Component({
  selector: "app-root",
  templateUrl: "./app.component.html",
  styleUrls: ["./app.component.css"],
})
export class AppComponent implements OnInit {
  title = "app";
  prevUrl: string;
  loading = false;
  loadingServiceSub: Subscription;

  constructor(
    private userService: ProfileService,
    private loadingService: LoadingService
  ) {
    // this.loadingServiceSub = this.loadingService.loading.subscribe(l => this.loading = l)
  }

  ngOnInit() {
    this.loading = false;
    if (window.localStorage.getItem("travelBug:Token"))
      this.userService.fetchUserProfile().subscribe();

    // this.loadingServiceSub = this.loadingService.loading.subscribe(l => this.loading = l)
  }

  ngOnDestroy() {
    this.loadingServiceSub.unsubscribe();
  }
}
