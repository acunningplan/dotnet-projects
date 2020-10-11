import { Component, OnInit } from "@angular/core";
import { ActivatedRoute } from "@angular/router";
import { RouterTrackingService } from "./services/router-tracking.service";
import { ProfileService } from "./services/profile.service";

@Component({
  selector: "app-root",
  templateUrl: "./app.component.html",
  styleUrls: ["./app.component.css"],
})
export class AppComponent implements OnInit {
  title = "app";
  prevUrl: string;

  constructor(
    private userService: ProfileService,
    private activatedRoute: ActivatedRoute
  ) {}

  ngOnInit() {
    if (window.localStorage.getItem("travelBug:Token"))
      this.userService.fetchUserProfile().subscribe();
  }

  ngOnDestroy() {}
}
