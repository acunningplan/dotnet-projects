import { Injectable } from "@angular/core";
import { Router } from "@angular/router";
import { HttpClient } from "@angular/common/http";
import { LoginForm } from "../account/login-form/login-form";

@Injectable({
  providedIn: "root",
})
export class AccountService {
  constructor(private router: Router, private httpClient: HttpClient) {}

  private profile: Profile;

  getProfile() {
    return this.profile;
  }

  signIn(loginForm: LoginForm) {
    return this.httpClient.post<LoginResponse>("api/user/login", loginForm);
  }

  register(loginForm: LoginForm) {
    return this.httpClient.post<LoginResponse>("api/user/register", loginForm);
  }

  signOut() {
    this.profile = null;
    this.router.navigate(["/"]);
    window.localStorage.removeItem("travelBugToken");
    window.localStorage.removeItem("travelBugUsername");
  }
}
