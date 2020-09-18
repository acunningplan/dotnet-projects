import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { environment } from "src/environments/environment";
import { Profile } from "../models/profile";
import { tap } from "rxjs/operators";

@Injectable({
  providedIn: "root",
})
export class UserService {
  userProfile: Profile;

  get getUserProfile(): Profile {
    return this.userProfile || new Profile();
  }

  constructor(private httpClient: HttpClient) {}

  fetchUserProfile() {
    return this.httpClient.get<Profile>(`${environment.apiUrl}/user`).pipe(
      tap((res) => {
        if (res) this.userProfile = res;
      })
    );
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
