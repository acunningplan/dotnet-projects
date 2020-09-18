import { HttpClient } from "@angular/common/http";
import { Component, OnInit } from "@angular/core";
import { ActivatedRoute } from "@angular/router";
import { environment } from "src/environments/environment";

@Component({
  selector: "app-verify-email",
  templateUrl: "./verify-email.component.html",
  styleUrls: ["./verify-email.component.css"],
})
export class VerifyEmailComponent implements OnInit {
  confirmingEmail = false;

  constructor(private httpClient: HttpClient, private route: ActivatedRoute) {}

  ngOnInit() {
    this.route.queryParams.subscribe((params) => {
      const email = params["email"];
      const token = params["token"];
      if (email && token) {
        this.confirmingEmail = true;
        this.httpClient
          .post(`${environment.apiUrl}/user/verify-email`, {
            email,
            token,
          })
          .subscribe(
            () => console.log("Verification successful"),
            () => console.log("Cannot verify email.")
          );
      }
    });
  }
}
