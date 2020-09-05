import { Component, OnInit } from "@angular/core";
import { environment } from "src/environments/environment";
import { FbLoginResponse, UserData } from "./login-types";
import { AccountService } from "src/app/services/account.service";

@Component({
  selector: "app-social-login",
  templateUrl: "./social-login.component.html",
  styleUrls: ["./social-login.component.css"],
})
export class SocialLoginComponent implements OnInit {
  constructor(private accountService: AccountService) {}

  ngOnInit() {
    this.googleInit();
  }

  private googleInit() {
    gapi.load("auth2", () => {
      let auth2 = gapi.auth2.init({
        client_id: `${environment.googleClientId}.apps.googleusercontent.com`,
        cookie_policy: "single_host_origin",
        scope: "profile email",
      });
      let googleBtn = document.getElementById("googleBtn");

      auth2.attachClickHandler(
        googleBtn,
        {},
        (googleUser: gapi.auth2.GoogleUser) => {
          let basicProfile = googleUser.getBasicProfile();
          let authResponse = googleUser.getAuthResponse();

          let userData = new UserData();
          userData.accessToken = authResponse.access_token;
          userData.email = basicProfile.getEmail();
          userData.id = basicProfile.getId();
          userData.photoUrl = basicProfile.getImageUrl();
          userData.username = basicProfile.getName();

          console.log(userData);

          this.accountService.socialLogin(userData, "google");
        },
        () => console.log("Login failed.")
      );
    });
  }

  // 1. Login to facebook
  // 2. Use accesstoken to request user data
  // 3. Save data to service and navigate to home page / blogs
  fbLogin() {
    FB.login((res) => {
      let { accessToken } = res.authResponse;
      FB.api(
        "/me",
        { fields: "name, email, picture.width(300)" },
        (res: FbLoginResponse) => {
          // let userData = new FbUserData(accessToken, res);
          let userData = new UserData();
          userData.accessToken = accessToken;
          userData.email = res.email;
          userData.id = res.id;
          userData.photoUrl = res.picture.data.url;
          userData.username = res.name;

          this.accountService.socialLogin(userData, "facebook");
        }
      );
    });
  }
}
