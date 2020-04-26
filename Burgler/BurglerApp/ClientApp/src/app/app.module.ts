import { BrowserModule } from "@angular/platform-browser";
import { NgModule } from "@angular/core";
import { FormsModule } from "@angular/forms";
import { HttpClientModule, HTTP_INTERCEPTORS } from "@angular/common/http";
import { RouterModule } from "@angular/router";

import { AppComponent } from "./app.component";
import { NavMenuComponent } from "./nav-menu/nav-menu.component";
import { HomeComponent } from "./home/home.component";
import { OrdersComponent } from "./orders/orders.component";
import { AccountComponent } from "./account/account.component";
import { AboutComponent } from "./about/about.component";
import { MenuComponent } from "./menu/menu.component";

import { SocialLoginModule, AuthServiceConfig } from "angularx-social-login";
import { AuthInterceptorService } from "./interceptors/auth-interceptor.service";
import { provideConfig } from "./auth-service/auth-service-config";
import { LoggingInterceptorService } from "./interceptors/logging-interceptor.service";
import { LeftSidebarComponent } from "./menu/left-sidebar/left-sidebar.component";
import { RightSidebarComponent } from "./menu/right-sidebar/right-sidebar.component";
import { MenuResolverService } from "./menu/menu-resolver.service";
import { OrderResolverService } from "./orders/order-resolver.service";

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    OrdersComponent,
    AccountComponent,
    AboutComponent,
    MenuComponent,
    LeftSidebarComponent,
    RightSidebarComponent,
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: "ng-cli-universal" }),
    HttpClientModule,
    FormsModule,
    SocialLoginModule,
    RouterModule.forRoot([
      { path: "", component: HomeComponent, pathMatch: "full" },
      {
        path: "menu",
        component: MenuComponent,
        resolve: [MenuResolverService],
      },
      { path: "about", component: AboutComponent },
      { path: "account", component: AccountComponent },
      {
        path: "orders",
        component: OrdersComponent,
        resolve: [OrderResolverService],
      },
    ]),
  ],
  providers: [
    {
      provide: HTTP_INTERCEPTORS,
      useClass: LoggingInterceptorService,
      multi: true,
    },
    {
      provide: HTTP_INTERCEPTORS,
      useClass: AuthInterceptorService,
      multi: true,
    },
    { provide: AuthServiceConfig, useFactory: provideConfig },
  ],
  bootstrap: [AppComponent],
})
export class AppModule {}
