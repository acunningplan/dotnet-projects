import { Component, OnInit, OnDestroy } from "@angular/core";
import { LoginStatusService } from "../account/login-status-service.service";
import { Subscription } from "rxjs";

@Component({
  selector: "app-home",
  templateUrl: "./home.component.html",
  styleUrls: ["./home.component.css"],
})
export class HomeComponent implements OnInit, OnDestroy {
  loggedIn: boolean;
  userName: string;
  loginStatusSub: Subscription;

  constructor(private loginStatusService: LoginStatusService) {}

  ngOnInit() {
    this.loggedIn = this.loginStatusService.getLoginData().loggedIn;
    this.loginStatusSub = this.loginStatusService.loggedInStatus.subscribe(
      () => {
        this.loggedIn = this.loginStatusService.getLoginData().loggedIn;
        // console.log(`Home login status = ${this.loggedIn}`);
      }
    );
  }

  ngOnDestroy() {
    this.loginStatusSub.unsubscribe();
  }
}
