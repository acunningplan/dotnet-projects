import { Component, OnInit, Input } from "@angular/core";
import { Router } from "@angular/router";
import { LoadingService } from "src/app/services/loading.service";
import { AccountService } from "src/app/services/account.service";
import { LoginForm } from "./login-form";
import { NgForm } from "@angular/forms";
import { HttpErrorResponse } from "@angular/common/http";

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
    private router: Router,
    private loadingService: LoadingService,
    private accountService: AccountService
  ) {}

  onSubmit(email: NgForm, password: NgForm, confirmPassword: NgForm) {
    if (!this.validityCheck(email, password, confirmPassword)) return;

    this.loadingService.loading.next(true);

    if (this.login) {
      this.accountService.signIn(this.loginForm).subscribe(
        (res) => {
          this.postLogin(res);
        },
        (err: HttpErrorResponse) => {
          if (err.status == 401) this.warning = "Invalid email or password.";
          else this.warning = "Login failed, please try again later.";
        }
      );
    } else {
      this.accountService.register(this.loginForm).subscribe((res) => {
        this.postLogin(res);
      },
      (err: HttpErrorResponse) => {
        this.warning = "Failed to sign up, please try again later.";
      });
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

  private postLogin(res: LoginResponse) {
    const { token, refreshToken, username } = res;
    if (token) {
      localStorage.setItem("travelBug:Token", token);
      localStorage.setItem("travelBug:RefreshToken", refreshToken);
      localStorage.setItem("travelBug:Username", username);

      this.accountService.loginStatus.next(true);

      this.router.navigate(["/"]);
    }
  }

  newForm() {
    this.loginForm = new LoginForm();
  }
}
