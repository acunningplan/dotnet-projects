import { BrowserModule } from "@angular/platform-browser";
import { NgModule } from "@angular/core";
import { FormsModule } from "@angular/forms";
import { HttpClientModule, HTTP_INTERCEPTORS } from "@angular/common/http";
import { RouterModule } from "@angular/router";

import { AppComponent } from "./app.component";
import { NavMenuComponent } from "./nav-menu/nav-menu.component";
import { HomeComponent } from "./home/home.component";
import { AccountComponent } from "./account/account.component";
import { BlogsComponent } from "./blogs/blogs.component";
import { LoginFormComponent } from "./account/login-form/login-form.component";
import { SocialLoginComponent } from "./account/social-login/social-login.component";
import { BlogDetailComponent } from "./blogs/blog-detail/blog-detail.component";
import { BlogPageComponent } from "./blog-page/blog-page.component";
import { LoggingInterceptorService } from "./interceptors/logging-interceptor.service";
import { AuthInterceptorService } from "./interceptors/auth-interceptor.service";
import { ProfileComponent } from "./profile/profile.component";
import { BlogListResolverService } from "./resolvers/blog-list-resolver.service";
import { VerifyEmailComponent } from "./verify-email/verify-email.component";
import { NewBlogComponent } from "./new-blog/new-blog.component";
import { UserBlogsComponent } from "./profile/user-blogs/user-blogs.component";
import { UserProfileResolverService } from "./resolvers/user-profile-resolver.service";
import { UserBlogsResolverService } from "./resolvers/user-blogs-resolver.service";
import { FeaturedUsersComponent } from "./blogs/featured-users/featured-users.component";
import { FeaturedUsersResolverService } from "./resolvers/featured-users-resolver.service";

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    AccountComponent,
    BlogsComponent,
    LoginFormComponent,
    SocialLoginComponent,
    BlogDetailComponent,
    BlogPageComponent,
    ProfileComponent,
    VerifyEmailComponent,
    NewBlogComponent,
    UserBlogsComponent,
    FeaturedUsersComponent,
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: "ng-cli-universal" }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: "", component: HomeComponent, pathMatch: "full" },
      { path: "account", component: AccountComponent },
      {
        path: "profile",
        component: ProfileComponent,
        resolve: {
          profile: UserProfileResolverService,
          blogs: UserBlogsResolverService,
        },
      },
      {
        path: "blogs",
        component: BlogsComponent,
        resolve: {
          blogs: BlogListResolverService,
          featuredUsers: FeaturedUsersResolverService,
        },
      },
      { path: "blog", component: BlogPageComponent },
      { path: "new-blog", component: NewBlogComponent },
      { path: "verify-email", component: VerifyEmailComponent },
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
  ],
  bootstrap: [AppComponent],
})
export class AppModule {}
