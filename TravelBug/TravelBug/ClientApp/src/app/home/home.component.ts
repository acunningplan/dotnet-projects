import { Component, OnInit, OnDestroy } from "@angular/core";
import { AccountService } from "../services/account.service";
import { UserService } from "../services/user.service";
import { Subscription } from "rxjs";

@Component({
  selector: "app-home",
  templateUrl: "./home.component.html",
  styleUrls: ["./home.component.css"],
})
export class HomeComponent implements OnInit, OnDestroy {
  isLoggedIn: boolean;
  loginSub: Subscription;

  constructor(private accountService: AccountService) {}

  ngOnInit() {
    this.isLoggedIn = this.accountService.hasToken;
    this.loginSub = this.accountService.loginStatus.subscribe((loginStatus) => {
      this.isLoggedIn = loginStatus;
    });
  }

  ngOnDestroy() {
    this.loginSub.unsubscribe();
  }
}
