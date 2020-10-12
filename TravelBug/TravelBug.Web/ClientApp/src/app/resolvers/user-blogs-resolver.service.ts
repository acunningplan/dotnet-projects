import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { ActivatedRouteSnapshot, RouterStateSnapshot } from "@angular/router";
import { Observable } from "rxjs";
import { Blog } from "../models/blog";
import { BlogService } from "../services/blog.service";
import { LoadingService } from "../services/loading.service";

@Injectable({
  providedIn: "root",
})
export class UserBlogsResolverService {
  constructor(
    private httpClient: HttpClient,
    private blogService: BlogService,
    private loadingService: LoadingService
  ) {}

  resolve(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot
  ): Blog[] | Observable<Blog[]> | Promise<Blog[]> {
    this.loadingService.loading.next(true);
    return this.blogService.fetchBlogs(route.params["username"]);
  }
}
