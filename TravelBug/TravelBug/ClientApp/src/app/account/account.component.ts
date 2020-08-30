import { Component, OnInit } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Router } from "@angular/router";
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

  constructor(
    private accountService: AccountService,
    private http: HttpClient,
    private router: Router
  ) {}

  ngOnInit() {
    this.loggedIn = window.localStorage.getItem("travelBugToken") != null;
    this.profile = this.accountService.getProfile();
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
