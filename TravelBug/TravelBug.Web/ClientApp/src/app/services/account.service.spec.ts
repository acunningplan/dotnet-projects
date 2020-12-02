import { getTestBed, TestBed } from "@angular/core/testing";

import { AccountService } from "./account.service";
import {
  HttpClientTestingModule,
  HttpTestingController,
} from "@angular/common/http/testing";
import { RouterTestingModule } from "@angular/router/testing";
import { LoginForm } from "../account/login-form/login-form";
import { LoginResponse } from "../account/login-form/login-response";
import { UserData } from "../account/social-login/login-types";
import { ServerLoginResponse } from "../models/serverLoginResponse";
import { environment } from "src/environments/environment";
import { BaseComponent } from "../base/base.component";
import { HomeComponent } from "../home/home.component";
import { Router } from "@angular/router";

describe("Should sign in", () => {
  let injector: TestBed;
  let service: AccountService;
  let httpMock: HttpTestingController;
  let router: Router;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [BaseComponent, HomeComponent],
      imports: [
        HttpClientTestingModule,
        RouterTestingModule.withRoutes([
          // Set up the routes
          // {path, component}
          {
            path: "",
            component: BaseComponent,
            children: [
              { path: "", component: HomeComponent, pathMatch: "full" },
            ],
          },
        ]),
      ],
      providers: [AccountService],
    });
    injector = getTestBed();
    service = injector.get(AccountService);
    httpMock = injector.get(HttpTestingController);
    router = injector.get(Router);
  });

  it("should be created", () => {
    const service: AccountService = TestBed.get(AccountService);
    expect(service).toBeTruthy();
  });

  it("should sign in with user data", () => {
    const loginForm = new LoginForm();
    loginForm.email = "dummy-user@test.com";
    loginForm.password = "Secret_1";

    // Action: Call the method
    service.signIn(loginForm).subscribe((res) => {
      expect(res).toBeDefined();
    });

    const dummyRes = new LoginResponse();

    // Set up http mock for post request
    const req = httpMock.expectOne("api/user/login");
    expect(req.request.method).toBe("POST");
    req.flush(dummyRes);
  });

  it("should sign in with user data", () => {
    const loginForm = new LoginForm();
    loginForm.email = "dummy-user@test.com";
    loginForm.password = "Secret_1";

    // Action: Call the method
    service.signIn(loginForm).subscribe((res) => {
      expect(res).toBeDefined();
    });

    const dummyRes = new LoginResponse();

    // Set up http mock for post request
    const req = httpMock.expectOne("api/user/login");
    expect(req.request.method).toBe("POST");
    req.flush(dummyRes);
  });

  describe("Should social login", () => {
    // Action: Call the method
    const userData = new UserData();

    const dummyRes = new ServerLoginResponse();
    dummyRes.username = "dummy-user";
    dummyRes.token = "mock-token";
    dummyRes.refreshToken = "mock-refresh-token";

    // service.socialLogin(userData, "google");

    it("should send request", () => {
      service.socialLogin(userData, "google");
      const req = httpMock.expectOne(`${environment.apiUrl}/user/google-login`);
      req.flush(dummyRes);
      // Send the mock request

      expect(req.request.method).toBe("POST");

      expect(localStorage.getItem("travelBug:Username")).toBeTruthy();
      // expect(navigateSpy).toHaveBeenCalledWith(["/"]);
    });

    it("should navigate to home", () => {
      // Spy on navigate method
      const navigateSpy = spyOn(router, "navigate");

      // Login
      service.socialLogin(userData, "google");

      // Expect a post request to have been made
      const req = httpMock.expectOne(`${environment.apiUrl}/user/google-login`);
      req.flush(dummyRes);
      // Expect a navigation to home
      expect(navigateSpy).toHaveBeenCalledWith(["/"]);
    });
  });

  afterEach(() => {
    httpMock.verify();
  });
});
