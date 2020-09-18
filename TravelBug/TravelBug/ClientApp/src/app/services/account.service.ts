import { Injectable, NgZone } from "@angular/core";
import { Router } from "@angular/router";
import { HttpClient } from "@angular/common/http";
import { LoginForm } from "../account/login-form/login-form";
import { Subject } from "rxjs";
import { Profile } from "../models/profiles";
import { environment } from "src/environments/environment";
import { ServerLoginResponse } from "../models/serverLoginResponse";
import { UserData } from "../account/social-login/login-types";

@Injectable({
  providedIn: "root",
})
export class AccountService {
  socialLoginInit = false;
  loginStatus = new Subject<boolean>();

  constructor(
    private router: Router,
    private httpClient: HttpClient,
    private ngZone: NgZone
  ) {}

  profileSubject = new Subject<Profile>();

  get hasToken() {
    return !!localStorage.getItem("travelBug:Token");
  }

  signIn(loginForm: LoginForm) {
    return this.httpClient.post<LoginResponse>("api/user/login", loginForm);
  }

  socialLogin(userData: UserData, socialMedia: "google" | "facebook") {
    this.httpClient
      .post(`${environment.apiUrl}/user/${socialMedia}-login`, userData)
      .subscribe((res: ServerLoginResponse) => {
        this.loginStatus.next(true);
        this.postLogin(res);
      });
  }

  postLogin(res: ServerLoginResponse) {
    console.log(res);
    if (res && res.token) {
      localStorage.setItem("travelBug:Token", res.token);
      localStorage.setItem("travelBug:RefreshToken", res.refreshToken);
      localStorage.setItem("travelBug:Username", res.username);

      this.ngZone.run(() => {
        this.router.navigate(["/"]).then(() => {
          this.loginStatus.next(true);
        });
      });
    }
  }

  postRegister() {
    this.ngZone.run(() => {
      this.router.navigate(["/verify-email"])
    });
  }

  register(loginForm: LoginForm) {
    return this.httpClient.post<LoginResponse>("api/user/register", loginForm);
  }

  signOut() {
    this.loginStatus.next(false);
    this.router.navigate(["/"]);
    window.localStorage.removeItem("travelBug:Token");
    window.localStorage.removeItem("travelBug:RefreshToken");
    window.localStorage.removeItem("travelBug:Username");
  }
}
