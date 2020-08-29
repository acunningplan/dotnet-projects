import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { HttpClient } from "@angular/common/http";

@Injectable({
  providedIn: 'root'
})
export class AccountService {

  constructor(private router: Router, private httpClient: HttpClient) { }

  private profile: Profile;

  getProfile() {
    return this.profile;
  }

  signIn (loginForm: LoginForm) {
    return this.httpClient.post<LoginResponse>("api/login", {
      email: loginForm.email,
      password: loginForm.password
    })
  }

  register (loginForm: LoginForm) {
    return this.httpClient.post<LoginResponse>("api/register", {
      email: loginForm.email,
      password: loginForm.password
    })
  }

  signOut () {
    this.profile = null;
    this.router.navigate(["/"]);
    window.localStorage.removeItem("travelBugToken");
    window.localStorage.removeItem("travelBugUsername");
  }
}