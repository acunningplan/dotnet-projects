import { Component, OnInit, OnDestroy, NgZone } from "@angular/core";
import { AccountService } from "../services/account.service";
import { Subscription } from "rxjs";
import { ActivatedRoute } from "@angular/router";

@Component({
  selector: "app-home",
  templateUrl: "./home.component.html",
  styleUrls: ["./home.component.css"],
})
export class HomeComponent implements OnInit, OnDestroy {
  isLoggedIn: boolean;
  loginSub: Subscription;

  constructor(
    private accountService: AccountService,
    private route: ActivatedRoute,
    private ngZone: NgZone
  ) {
    this.loginSub = this.accountService.loginStatus.subscribe((loginStatus) => {
      this.ngZone.run(() => {
        this.isLoggedIn = loginStatus;
      });
    });
  }

  ngOnInit() {
    this.isLoggedIn = this.accountService.hasToken;
  }

  ngOnDestroy() {
    this.loginSub.unsubscribe();
  }
}
