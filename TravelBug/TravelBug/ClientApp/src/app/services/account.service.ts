import { Injectable } from "@angular/core";
import { Router } from "@angular/router";
import { HttpClient } from "@angular/common/http";
import { LoginForm } from "../account/login-form/login-form";
import { Subject } from "rxjs";
import { Profile } from "../models/profiles";

@Injectable({
  providedIn: "root",
})
export class AccountService {
  loginStatus = new Subject<boolean>();

  constructor(private router: Router, private httpClient: HttpClient) {}

  profileSubject = new Subject<Profile>();

  get hasToken() {
    return !!localStorage.getItem("travelBug:Token");
  }

  signIn(loginForm: LoginForm) {
    return this.httpClient.post<LoginResponse>("api/user/login", loginForm);
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
