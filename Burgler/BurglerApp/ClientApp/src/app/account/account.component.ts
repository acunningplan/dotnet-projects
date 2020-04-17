import { Component, OnInit } from "@angular/core";
import {
  AuthService,
  FacebookLoginProvider,
  GoogleLoginProvider,
  SocialUser,
} from "angularx-social-login";
import { HttpClient } from "@angular/common/http";
import { signInResponse } from "../interfaces/interfaces";
import { Router } from "@angular/router";

@Component({
  selector: "app-account",
  templateUrl: "./account.component.html",
  styleUrls: ["./account.component.css"],
})
export class AccountComponent implements OnInit {
  user: SocialUser;
  loggedIn: boolean;

  constructor(
    private authService: AuthService,
    private http: HttpClient,
    private router: Router
  ) {}

  ngOnInit() {
    this.loggedIn = window.localStorage.getItem("token") != null;
  }

  sendToken(authToken, path) {
    this.http
      .post<signInResponse>(`http://localhost:5000/api/user/${path}`, {
        AccessToken: authToken,
      })
      .subscribe((res) => {
        this.router.navigate(["/"]);
        window.localStorage.setItem("token", res.token);
      });
  }

  signInWithFB() {
    this.authService
      .signIn(FacebookLoginProvider.PROVIDER_ID)
      .then((res) => this.sendToken(res.authToken, "facebook"));
  }

  signInWithGoogle() {
    this.authService
      .signIn(GoogleLoginProvider.PROVIDER_ID)
      .then((res) => this.sendToken(res.authToken, "google"));
  }

  signOut() {
    this.authService.signOut();
    this.router.navigate(["/"]);
    window.localStorage.removeItem("token");
  }
}
