import { BrowserModule } from "@angular/platform-browser";
import { NgModule } from "@angular/core";
import { FormsModule } from "@angular/forms";
import { HttpClientModule, HTTP_INTERCEPTORS } from "@angular/common/http";
import { RouterModule } from "@angular/router";

import { AppComponent } from "./app.component";
import { NavMenuComponent } from "./nav-menu/nav-menu.component";
import { HomeComponent } from "./home/home.component";
import { OrdersComponent } from "./orders/orders.component";
import { FoodMenuComponent } from "./food-menu/food-menu.component";
import { AccountComponent } from "./account/account.component";
import { AboutComponent } from "./about/about.component";
import { MenuComponent } from "./menu/menu.component";
import { Oauth2RedirectComponent } from "./oauth2-redirect/oauth2-redirect.component";

import {
  SocialLoginModule,
  AuthServiceConfig,
  FacebookLoginProvider,
  GoogleLoginProvider,
} from "angularx-social-login";

const config = new AuthServiceConfig([
  {
    id: GoogleLoginProvider.PROVIDER_ID,
    provider: new GoogleLoginProvider(
      "350645675339-c8pshk7k3ih1qtvjn4vhtat5d4h63nha.apps.googleusercontent.com"
    ),
  },
  {
    id: FacebookLoginProvider.PROVIDER_ID,
    provider: new FacebookLoginProvider("233736334505512"),
  },
]);

export function provideConfig() {
  return config;
}

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    OrdersComponent,
    FoodMenuComponent,
    AccountComponent,
    AboutComponent,
    MenuComponent,
    Oauth2RedirectComponent,
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: "ng-cli-universal" }),
    HttpClientModule,
    FormsModule,
    SocialLoginModule,
    RouterModule.forRoot([
      { path: "", component: HomeComponent, pathMatch: "full" },
      { path: "menu", component: MenuComponent },
      { path: "about", component: AboutComponent },
      { path: "account", component: AccountComponent },
      { path: "orders", component: OrdersComponent },
      { path: "oauth2callback", component: Oauth2RedirectComponent },
    ]),
  ],
  providers: [{ provide: AuthServiceConfig, useFactory: provideConfig }],
  bootstrap: [AppComponent],
})
export class AppModule {}
