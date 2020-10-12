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
import { LoadingService } from "../services/loading.service";

@Injectable({
  providedIn: "root",
})
export class BlogListResolverService implements Resolve<Blog[]> {
  constructor(
    private httpClient: HttpClient,
    private loadingService: LoadingService
  ) {}

  resolve(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot
  ): Blog[] | Observable<Blog[]> | Promise<Blog[]> {
    this.loadingService.loading.next(true);
    return this.httpClient.get<Blog[]>(`${environment.apiUrl}/blog/`);
    // .pipe(tap((b) => console.log(b)));
  }
}
