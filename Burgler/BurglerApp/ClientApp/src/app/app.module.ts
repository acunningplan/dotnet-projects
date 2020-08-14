import { BrowserModule } from "@angular/platform-browser";
import { NgModule } from "@angular/core";
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
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
import { PastOrdersResolverService } from "./orders/past-orders-resolver.service";
import { BurgerModalComponent } from "./menu/burger-modal/burger-modal.component";
import { OrderDetailComponent } from './orders/order-detail/order-detail.component';
import { ReformatDateTimePipe } from './orders/order-detail/reformat-date-time.pipe';
import { CheckOneSizeDirective } from './menu/check-one-size.directive';
import { OrderItemComponent } from './orders/order-detail/order-item/order-item.component';
import { OrderConfirmationComponent } from './orders/order-confirmation/order-confirmation.component';
import { LoadingComponent } from './loading/loading.component';

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
    BurgerModalComponent,
    OrderDetailComponent,
    ReformatDateTimePipe,
    CheckOneSizeDirective,
    OrderItemComponent,
    OrderConfirmationComponent,
    LoadingComponent,
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: "ng-cli-universal" }),
    HttpClientModule,
    FormsModule,
    SocialLoginModule,
    ReactiveFormsModule,
    RouterModule.forRoot([
      { path: "", component: HomeComponent, pathMatch: "full" },
      {
        path: "menu",
        component: MenuComponent,
        resolve: [MenuResolverService, OrderResolverService],
      },
      { path: "about", component: AboutComponent },
      { path: "account", component: AccountComponent },
      {
        path: "orders",
        component: OrdersComponent,
        resolve: [
          MenuResolverService,
          OrderResolverService,
          PastOrdersResolverService,
        ],
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
