import { Component, OnInit, Input } from "@angular/core";
import { LoadingService } from "src/app/services/loading.service";
import { AccountService } from "src/app/services/account.service";
import { LoginForm } from "./login-form";
import { NgForm } from "@angular/forms";
import { HttpErrorResponse } from "@angular/common/http";
import { ServerLoginResponse } from "src/app/models/serverLoginResponse";

@Component({
  selector: "app-login-form",
  templateUrl: "./login-form.component.html",
  styleUrls: ["./login-form.component.css"],
})
export class LoginFormComponent {
  @Input() login: boolean;
  loginForm = new LoginForm();
  submitted = false;
  warning = null;

  constructor(
    private loadingService: LoadingService,
    private accountService: AccountService
  ) {}

  onSubmit(email: NgForm, password: NgForm, confirmPassword: NgForm) {
    if (!this.validityCheck(email, password, confirmPassword)) return;

    this.loadingService.loading.next(true);

    if (this.login) {
      this.accountService.signIn(this.loginForm).subscribe(
        (res: ServerLoginResponse) => {
          this.accountService.postLogin(res);
        },
        (err: HttpErrorResponse) => {
          if (err.status == 401) this.warning = "Invalid email or password.";
          else this.warning = "Login failed, please try again later.";
        }
      );
    } else {
      this.accountService.register(this.loginForm).subscribe(
        (res: ServerLoginResponse) => {
          this.accountService.postLogin(res);
        },
        (err: HttpErrorResponse) => {
          this.warning = "Failed to sign up, please try again later.";
        }
      );
    }
  }

  private validityCheck(
    email: NgForm,
    password: NgForm,
    confirmPassword: NgForm
  ) {
    if (!email.valid) {
      this.warning = "Make sure email is valid.";
      return false;
    } else if (!password.valid) {
      this.warning = "Make sure you enter a password.";
      return false;
    } else if (!this.login && confirmPassword != password) {
      this.warning = "Make sure the passwords match.";
      return false;
    }
    return true;
  }

  newForm() {
    this.loginForm = new LoginForm();
  }
}
