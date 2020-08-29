import { Component, OnInit, Input } from "@angular/core";
import { Router } from "@angular/router";
import { LoadingService } from "src/app/services/loading.service";
import { HttpClient } from "@angular/common/http";
import { AccountService } from "src/app/services/account.service";
// import LoginForm from "./login-form";

@Component({
  selector: "app-login-form",
  templateUrl: "./login-form.component.html",
  styleUrls: ["./login-form.component.css"],
})
export class LoginFormComponent {
  @Input() login: boolean;
  loginForm = new LoginForm();
  submitted = false;
  warning = false;
  warningMessage = "Please make sure the two passwords match.";

  constructor(
    private router: Router,
    private loadingService: LoadingService,
    private httpClient: HttpClient,
    private accountService: AccountService
  ) {}

  onSubmit() {
    if (
      !this.login &&
      this.loginForm.password != this.loginForm.confirmPassword
    ) {
      this.warning = true;
      return;
    }
    this.loadingService.loading.next(true);

    if (this.login) {
      this.accountService.signIn(this.loginForm).subscribe((loginResponse) => {
        this.router.navigate(["/"]);
      });
    } else {
      
    }
  }

  newForm() {
    this.loginForm = new LoginForm();
  }
}

class LoginForm {
  email: string;
  password: string;
  confirmPassword: string;
}
