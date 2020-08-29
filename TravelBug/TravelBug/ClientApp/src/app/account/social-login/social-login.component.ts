import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-social-login',
  templateUrl: './social-login.component.html',
  styleUrls: ['./social-login.component.css']
})
export class SocialLoginComponent implements OnInit {

  constructor() { }

  ngOnInit() {
  }

  sendToken(authToken, path) {
    // this.http
    //   .post<signInResponse>(`${environment.serverUrl}/user/${path}`, {
    //     AccessToken: authToken,
    //   })
    //   .subscribe((res) => {
    //     this.router.navigate(["/"]);
    //     window.localStorage.setItem("travelBugToken", res.token);
    //     window.localStorage.setItem("travelBugUsername", res.displayName);
    //     this.accountService.loggedInStatus.next();
    //   });
  }

  signInWithFB() {
    // this.accountService
    //   .signIn(FacebookLoginProvider.PROVIDER_ID).then((res) => {
    //   // console.log(res.authToken);
    //   this.sendToken(res.authToken, "facebook");
    // });
  }

  signInWithGoogle() {
    // this.accountService
    //   .signIn(GoogleLoginProvider.PROVIDER_ID)
    //   .then((res) => this.sendToken(res.authToken, "google"));
  }
}
