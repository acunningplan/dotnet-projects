import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { environment } from "src/environments/environment";
import { Profile } from "../models/profiles";
import { ServerLoginResponse } from "../models/serverLoginResponse";
import { AccountService } from "./account.service";
import { Router } from "@angular/router";
import { UserData } from "../account/social-login/login-types";

@Injectable({
  providedIn: "root",
})
export class UserService {
  constructor(
    private httpClient: HttpClient,
    private accountService: AccountService,
    private router: Router
  ) {}

  getUserProfile() {
    this.httpClient.get<{ userProfile: Profile }>(`${environment.apiUrl}/user`);
  }

  // socialLogin(userData: UserData, socialMedia: "google" | "facebook") {
  //   this.httpClient
  //     .post(`${environment.apiUrl}/user/${socialMedia}-login`, userData)
  //     .subscribe((res: ServerLoginResponse) => {
  //       this.postLogin(res);
  //     });
  // }

  // postLogin(res: ServerLoginResponse) {
  //   if (res.token) {
  //     localStorage.setItem("travelBug:Token", res.token);
  //     localStorage.setItem("travelBug:RefreshToken", res.refreshToken);
  //     localStorage.setItem("travelBug:Username", res.username);

  //     this.accountService.loginStatus.next(true);

  //     this.router.navigate(["/"]);
  //   }
  // }
}
