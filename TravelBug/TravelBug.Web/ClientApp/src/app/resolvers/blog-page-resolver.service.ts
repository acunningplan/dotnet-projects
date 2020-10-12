import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import {
  ActivatedRouteSnapshot,
  Router,
  RouterStateSnapshot,
} from "@angular/router";
import { Observable, of } from "rxjs";
import { catchError, tap } from "rxjs/operators";
import { environment } from "src/environments/environment";
import { Blog } from "../models/blog";
import { LoadingService } from "../services/loading.service";

@Injectable({
  providedIn: "root",
})
export class BlogPageResolverService {
  id: string;
  constructor(
    private httpClient: HttpClient,
    private router: Router,
    private loadingService: LoadingService
  ) {}

  resolve(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot
  ): Blog | Observable<Blog> | Promise<Blog> {
    this.loadingService.loading.next(true);
    return this.httpClient
      .get<Blog>(`${environment.apiUrl}/blog/${route.params["id"]}`)
      .pipe(
        catchError((err) => {
          console.log(err);
          this.router.navigate(["/not-found"]);
          return of(null);
        })
      );
  }
}
