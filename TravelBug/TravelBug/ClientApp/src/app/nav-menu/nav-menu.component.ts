import { Component, OnInit } from "@angular/core";
import { AccountService } from "../services/account.service";
import { Subscription } from "rxjs";

@Component({
  selector: "app-nav-menu",
  templateUrl: "./nav-menu.component.html",
  styleUrls: ["./nav-menu.component.css"],
})
export class NavMenuComponent implements OnInit {
  isExpanded = false;
  isLoggedIn: boolean;
  loginSub: Subscription;

  constructor(private accountService: AccountService) {}

  ngOnInit() {
    this.isLoggedIn = this.accountService.hasToken;
    this.loginSub = this.accountService.loginStatus.subscribe((loginStatus) => {
      this.isLoggedIn = loginStatus;
    });
  }

  collapse() {
    this.isExpanded = false;
  }

  toggle() {
    this.isExpanded = !this.isExpanded;
  }

  ngOnDestroy() {
    this.loginSub.unsubscribe();
  }
}
