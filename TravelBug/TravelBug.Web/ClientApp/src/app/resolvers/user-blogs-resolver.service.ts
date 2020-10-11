import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { ActivatedRouteSnapshot, RouterStateSnapshot } from "@angular/router";
import { LoadingBarService } from "@ngx-loading-bar/core";
import { Observable } from "rxjs";
import { environment } from "src/environments/environment";
import { Blog } from "../models/blog";
import { BlogService } from "../services/blog.service";
import { ProfileService } from "../services/profile.service";

@Injectable({
  providedIn: "root",
})
export class UserBlogsResolverService {
  constructor(
    private httpClient: HttpClient,
    private blogService: BlogService,
    private loadingBarService: LoadingBarService
  ) {}

  resolve(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot
  ): Blog[] | Observable<Blog[]> | Promise<Blog[]> {
    // this.loadingBarService.start();
    return this.blogService.fetchBlogs(route.params["username"]);
  }
}
