import { Component, OnInit } from "@angular/core";
import { environment } from "src/environments/environment";
import { AccountService } from "src/app/services/account.service";
import { GoogleProfile } from "../../models/profiles";
// import "@types/gapi2";
// import "@types/gapi2.auth2";
// declare const gapi: any;
// const gapi = require("gapi");

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
        (googleUser) => {
          let basicProfile = googleUser.getBasicProfile();

          let googleProfile = new GoogleProfile(basicProfile);
          this.accountService.profileSubject.next(googleProfile);
        },
        () => console.log("Cannot get profile.")
      );
    });
  }

  private fbLogin() {
    // FB.login(function (response) {
    //   if (response.authResponse) {
    //     console.log("Welcome!  Fetching your information.... ");
    //     FB.api("/me", function (response) {
    //       console.log("Good to see you, " + response.name + ".");
    //     });
    //   } else {
    //     console.log("User cancelled login or did not fully authorize.");
    //   }
    // });
  }
}
