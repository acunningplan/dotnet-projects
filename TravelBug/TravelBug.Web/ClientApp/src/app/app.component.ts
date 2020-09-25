import { Component, OnInit } from "@angular/core";
import { RouterTrackingService } from "./services/router-tracking.service";
import { UserService } from "./services/user.service";

@Component({
  selector: "app-root",
  templateUrl: "./app.component.html",
  styleUrls: ["./app.component.css"],
})
export class AppComponent implements OnInit {
  title = "app";
  prevUrl: string;

  constructor(
    private userService: UserService,
    private routerTrackingService: RouterTrackingService
  ) {}

  ngOnInit() {
    this.userService.fetchUserProfile().subscribe();
  }

  ngOnDestroy() {}
}
