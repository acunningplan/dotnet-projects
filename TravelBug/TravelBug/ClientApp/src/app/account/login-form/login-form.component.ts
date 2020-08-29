import { Component, OnInit, Input } from "@angular/core";
import { Router } from "@angular/router";
import { LoadingService } from "src/app/services/loading.service";
import { AccountService } from "src/app/services/account.service";
import { LoginForm } from "./login-form";

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
      this.accountService.signIn(this.loginForm).subscribe(this.postLogin);
    } else {
      this.accountService.register(this.loginForm).subscribe(this.postLogin);
    }
  }

  private postLogin(res: LoginResponse) {
    window.localStorage.setItem("travelBug:Token", res.token);
    window.localStorage.setItem("travelBug:RefreshToken", res.refreshToken);
    window.localStorage.setItem("travelBug:Username", res.username);
    this.router.navigate(["/"]);
  }

  newForm() {
    this.loginForm = new LoginForm();
  }
}
