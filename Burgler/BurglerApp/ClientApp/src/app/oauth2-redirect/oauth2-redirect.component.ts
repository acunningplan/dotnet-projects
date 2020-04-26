// import { Component, OnInit } from "@angular/core";
// import { Router, ActivatedRoute } from "@angular/router";
// import { HttpClient } from "@angular/common/http";

// @Component({
//   selector: "app-oauth2-redirect",
//   templateUrl: "./oauth2-redirect.component.html",
//   styleUrls: ["./oauth2-redirect.component.css"],
// })
// export class Oauth2RedirectComponent implements OnInit {
//   apiUrl = "http://localhost:5000/api/user/google";
//   code: string;

//   constructor(
//     private router: Router,
//     private route: ActivatedRoute,
//     private http: HttpClient
//   ) {}

//   async ngOnInit() {
//     this.code = this.route.snapshot.queryParams.code;
//     console.log(this.code);
//     // this.code = this.code.replace("/", "%2F");
//     console.log(this.code);
//     let body = { AuthorizationCode: this.code };
//     let response;
//     this.http.post(this.apiUrl, body).subscribe((res) => (response = res));
//     console.log(response);
//   }

//   sendRequest() {
//     // let body = new URLSearchParams();
//     // body.set("AuthorizationCode", this.route.snapshot.queryParams.code);
//     // const userData = await this.http.post(
//     //   "http://localhost:5000/api/user/google",
//     //   body
//     // );
//     // console.log(userData);
//     let body = {
//       AuthorizationCode: this.code,
//     };
//     let response;
//     this.http.post(this.apiUrl, body).subscribe((res) => (response = res));
//     console.log(response);
//   }

//   // renavigate() {
//   //   this.router.navigate(["/"]);
//   // }
// }
