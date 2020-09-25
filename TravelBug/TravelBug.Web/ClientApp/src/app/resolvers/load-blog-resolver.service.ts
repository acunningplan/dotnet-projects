import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import {
  ActivatedRoute,
  ActivatedRouteSnapshot,
  Router,
  RouterStateSnapshot,
} from "@angular/router";
import { Observable, of } from "rxjs";
import { catchError, map, tap } from "rxjs/operators";
import { environment } from "src/environments/environment";
import { Blog } from "../models/blog";
import { BlogService } from "../services/blog.service";

@Injectable({
  providedIn: "root",
})
export class LoadBlogResolverService {
  id: string;
  constructor(
    private httpClient: HttpClient,
    private router: Router,
    private blogService: BlogService
  ) {}

  resolve(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot
  ): Blog | Observable<Blog> | Promise<Blog> {
    return this.httpClient
      .get<Blog>(`${environment.apiUrl}/blog/${route.params["id"]}`)
      .pipe(
        tap((res) => {
          // Check if current user is actually the author of the blog
          if (
            res.user.username !==
            window.localStorage.getItem("travelBug:Username")
          )
            throw new Error();
          else {
            this.blogService.setEditedBlog(res);
          }
        }),
        catchError((err) => {
          console.log(err);
          this.router.navigate(["/not-found"]);
          return of(null);
        })
      );
  }
}
