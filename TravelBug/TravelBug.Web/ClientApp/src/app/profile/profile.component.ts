import { Component, OnInit, OnDestroy } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { AccountService } from "../services/account.service";
import { Subscription } from "rxjs";

@Component({
  selector: "app-profile",
  templateUrl: "./profile.component.html",
  styleUrls: ["./profile.component.css"],
})
export class ProfileComponent {
  loginSub: Subscription;

  constructor(private accountService: AccountService) {}

  signOut() {
    this.accountService.signOut();
  }
}
