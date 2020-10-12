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
import { BlogPageComponent } from "./blogs/blog-page/blog-page.component";
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
import { BlogPageResolverService } from "./resolvers/blog-page-resolver.service";
import { NotFoundComponent } from "./not-found/not-found.component";
import { LoadBlogResolverService } from "./resolvers/load-blog-resolver.service";
import { DeleteModalComponent } from "./blogs/blog-page/delete-modal/delete-modal.component";
import { ImageContainerComponent } from "./new-blog/image-container/image-container.component";
import { AppResolverService } from "./resolvers/app-resolver.service";
import { BaseComponent } from "./base/base.component";
import { FeaturedUserDetailComponent } from "./blogs/featured-users/user-detail/user-detail.component";
import { EditProfileComponent } from "./edit-profile/edit-profile.component";
import { EditProfileResolverService } from "./resolvers/edit-profile-resolver.service";
import { ShowUsersComponent } from "./show-users/show-users.component";
import { AllProfilesResolverService } from "./resolvers/all-profiles-resolver.service";
import { UserDetailComponent } from "./show-users/user-detail/user-detail.component";
import { ResponseInterceptorService } from "./interceptors/response-interceptor.service";
import { AdditionalInfoComponent } from "./profile/additional-info/additional-info.component";

import { BrowserAnimationsModule } from "@angular/platform-browser/animations";
import { ToastrModule } from "ngx-toastr";
import {MatProgressBarModule} from '@angular/material/progress-bar';


import { LoadingBarModule } from '@ngx-loading-bar/core';

// import { ImageUploadModule } from "ng2-imageupload";

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
    NotFoundComponent,
    DeleteModalComponent,
    ImageContainerComponent,
    BaseComponent,
    FeaturedUserDetailComponent,
    EditProfileComponent,
    ShowUsersComponent,
    UserDetailComponent,
    AdditionalInfoComponent,
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: "ng-cli-universal" }),
    HttpClientModule,
    FormsModule,
    LoadingBarModule,
    BrowserAnimationsModule, // required animations module
    ToastrModule.forRoot(), // ToastrModule added

    MatProgressBarModule,
    RouterModule.forRoot([
      {
        path: "",
        component: BaseComponent,
        resolve: {
          // appContent: AppResolverService,
        },
        children: [
          { path: "", component: HomeComponent, pathMatch: "full" },
          { path: "account", component: AccountComponent },
          {
            path: "profile/:username",
            component: ProfileComponent,
            resolve: {
              profile: UserProfileResolverService,
              blogs: UserBlogsResolverService,
            },
          },
          {
            path: "edit-profile",
            component: EditProfileComponent,
            resolve: {
              profile: EditProfileResolverService,
            },
          },
          {
            path: "blogs/:id",
            component: BlogPageComponent,
            resolve: {
              blog: BlogPageResolverService,
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
          {
            path: "users",
            component: ShowUsersComponent,
            resolve: {
              users: AllProfilesResolverService,
            },
          },
          { path: "new-blog", component: NewBlogComponent },
          {
            path: "edit-blog/:id",
            component: NewBlogComponent,
            resolve: {
              blog: LoadBlogResolverService,
            },
          },
          { path: "verify-email", component: VerifyEmailComponent },
          { path: "not-found", component: NotFoundComponent },
          { path: "**", redirectTo: "/not-found" },
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
    {
      provide: HTTP_INTERCEPTORS,
      useClass: ResponseInterceptorService,
      multi: true,
    },
  ],
  bootstrap: [AppComponent],
})
export class AppModule {}
