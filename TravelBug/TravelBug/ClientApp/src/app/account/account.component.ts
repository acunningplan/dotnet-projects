import { Component, OnInit } from "@angular/core";
import { AccountService } from "../services/account.service";

@Component({
  selector: "app-account",
  templateUrl: "./account.component.html",
  styleUrls: ["./account.component.css"],
})
export class AccountComponent implements OnInit {
  profile: Profile;
  login = true;
  loggedIn: boolean;
  username: string;

  constructor(private accountService: AccountService) {}

  ngOnInit() {
    this.loggedIn = this.accountService.hasToken;
    this.username = this.profile ? this.profile.username : "Guest";
  }

  loginToggle() {
    this.login = !this.login;
  }

  signOut() {
    this.accountService.signOut();
    // this.accountService.loggedInStatus.next();
  }
}
