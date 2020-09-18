import { Component, OnInit } from "@angular/core";
import { environment } from "src/environments/environment";
import { UserService } from "./services/user.service";

@Component({
  selector: "app-root",
  templateUrl: "./app.component.html",
})
export class AppComponent implements OnInit {
  title = "app";

  constructor(private userService: UserService) {}

  ngOnInit() {
    this.userService.fetchUserProfile().subscribe();
  }
}
