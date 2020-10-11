import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Blog } from "../models/blog";
import {
  Resolve,
  ActivatedRouteSnapshot,
  RouterStateSnapshot,
} from "@angular/router";
import { Observable } from "rxjs";
import { environment } from "src/environments/environment";
import { LoadingBarService } from "@ngx-loading-bar/core";

@Injectable({
  providedIn: "root",
})
export class BlogListResolverService implements Resolve<Blog[]> {
  constructor(
    private httpClient: HttpClient,
    private loadingBarService: LoadingBarService
  ) {}

  resolve(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot
  ): Blog[] | Observable<Blog[]> | Promise<Blog[]> {
    this.loadingBarService.start();
    return this.httpClient.get<Blog[]>(`${environment.apiUrl}/blog/`);
    // .pipe(tap((b) => console.log(b)));
  }
}
