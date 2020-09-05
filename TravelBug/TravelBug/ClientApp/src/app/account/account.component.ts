import { Component, OnInit } from "@angular/core";
import { AccountService } from "../services/account.service";
import { Subscription } from "rxjs";

@Component({
  selector: "app-account",
  templateUrl: "./account.component.html",
  styleUrls: ["./account.component.css"],
})
export class AccountComponent implements OnInit {
  profileSub: Subscription;
  loginMode = true;
  loggedIn: boolean;

  constructor(private accountService: AccountService) {}

  ngOnInit() {
    this.loggedIn = this.accountService.hasToken;
    this.profileSub = this.accountService.profileSubject.subscribe((profile) =>
      console.log(`User ${profile.name} has just logged in.`)
    );
  }

  loginToggle() {
    this.loginMode = !this.loginMode;
  }

  signOut() {
    this.accountService.signOut();
    // this.accountService.loggedInStatus.next();
  }
}
