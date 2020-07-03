import { Injectable } from "@angular/core";
import { Subject } from "rxjs";

@Injectable({
  providedIn: "root",
})
export class LoginStatusService {
  loggedInStatus = new Subject();

  constructor() {}

  getLoginData() {
    let loggedIn = window.localStorage.getItem("burglerToken") != null;
    let userName = window.localStorage.getItem("burglerUsername");
    return { loggedIn, userName };
  }
}
