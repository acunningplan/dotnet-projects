import { Component, OnInit, OnDestroy } from "@angular/core";
import { LoginStatusService } from "../account/login-status-service.service";
import { Subscription } from "rxjs";

@Component({
  selector: "app-nav-menu",
  templateUrl: "./nav-menu.component.html",
  styleUrls: ["./nav-menu.component.css"],
})
export class NavMenuComponent implements OnInit, OnDestroy {
  isExpanded = false;
  loggedIn: boolean;
  userName: string;
  loginStatusSub: Subscription;

  constructor(private loginStatusService: LoginStatusService) {}

  ngOnInit() {
    this.loggedIn = this.loginStatusService.getLoginData().loggedIn;
    this.loginStatusSub = this.loginStatusService.loggedInStatus.subscribe(
      () => {
        this.loggedIn = this.loginStatusService.getLoginData().loggedIn;
        // console.log(`Navbar login status = ${this.loggedIn}`);
      }
    );
  }

  collapse() {
    this.isExpanded = false;
  }

  toggle() {
    this.isExpanded = !this.isExpanded;
  }

  ngOnDestroy() {
    this.loginStatusSub.unsubscribe();
  }
}
