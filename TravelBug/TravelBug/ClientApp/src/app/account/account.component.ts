import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { AccountService } from './account.service';

@Component({
  selector: 'app-account',
  templateUrl: './account.component.html',
  styleUrls: ['./account.component.css']
})
export class AccountComponent implements OnInit {
  profile: Profile;
  loggedIn: boolean;
  username: string;

  constructor(
    private accountService: AccountService,
    private http: HttpClient,
    private router: Router
  ) {}

  ngOnInit() {
    this.loggedIn = window.localStorage.getItem("travelBugToken") != null;
    this.profile = this.accountService.getProfile();
    this.username = this.profile ? this.profile.username : "Guest";
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
    // this.authService.signIn(FacebookLoginProvider.PROVIDER_ID).then((res) => {
    //   // console.log(res.authToken);
    //   this.sendToken(res.authToken, "facebook");
    // });
  }

  signInWithGoogle() {
    // this.authService
    //   .signIn(GoogleLoginProvider.PROVIDER_ID)
    //   .then((res) => this.sendToken(res.authToken, "google"));
  }

  signOut() {
    // this.authService.signOut();
    // this.router.navigate(["/"]);
    // window.localStorage.removeItem("travelBugToken");
    // window.localStorage.removeItem("travelBugUsername");
    // this.accountService.loggedInStatus.next();
  }

}
