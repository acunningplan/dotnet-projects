import { Component, OnInit } from "@angular/core";
import {
  AuthService,
  FacebookLoginProvider,
  GoogleLoginProvider,
} from "angularx-social-login";
import { HttpClient } from "@angular/common/http";
import { signInResponse } from "../interfaces/interfaces";
import { Router } from "@angular/router";
import { environment } from "src/environments/environment";
import { LoginStatusService } from "./login-status-service.service";

@Component({
  selector: "app-account",
  templateUrl: "./account.component.html",
  styleUrls: ["./account.component.css"],
})
export class AccountComponent implements OnInit {
  userName: string;
  loggedIn: boolean;

  constructor(
    private authService: AuthService,
    private loginStatusService: LoginStatusService,
    private http: HttpClient,
    private router: Router
  ) {}

  ngOnInit() {
    this.loggedIn = window.localStorage.getItem("burglerToken") != null;
    this.userName = window.localStorage.getItem("burglerUsername");
  }

  sendToken(authToken, path) {
    this.http
      .post<signInResponse>(`${environment.serverUrl}/user/${path}`, {
        AccessToken: authToken,
      })
      .subscribe((res) => {
        this.router.navigate(["/"]);
        window.localStorage.setItem("burglerToken", res.token);
        window.localStorage.setItem("burglerUsername", res.displayName);
        this.loginStatusService.loggedInStatus.next();
      });
  }

  signInWithFB() {
    this.authService.signIn(FacebookLoginProvider.PROVIDER_ID).then((res) => {
      console.log(res.authToken);
      this.sendToken(res.authToken, "facebook");
    });
  }

  signInWithGoogle() {
    this.authService
      .signIn(GoogleLoginProvider.PROVIDER_ID)
      .then((res) => this.sendToken(res.authToken, "google"));
  }

  signOut() {
    this.authService.signOut();
    this.router.navigate(["/"]);
    window.localStorage.removeItem("burglerToken");
    window.localStorage.removeItem("burglerUsername");
    this.loginStatusService.loggedInStatus.next();
  }
}
