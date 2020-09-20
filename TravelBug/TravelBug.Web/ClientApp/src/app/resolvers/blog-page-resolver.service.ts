import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import {
  ActivatedRoute,
  ActivatedRouteSnapshot,
  RouterStateSnapshot,
} from "@angular/router";
import { Observable } from "rxjs";
import { environment } from "src/environments/environment";
import { Blog } from "../models/blog";

@Injectable({
  providedIn: "root",
})
export class BlogPageResolverService {
  id: string;
  constructor(private httpClient: HttpClient, private route: ActivatedRoute) {
    route.params.subscribe(params => {
      console.log(params["id"]);
      this.id = params["id"];
    });
  }

  resolve(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot
  ): Blog | Observable<Blog> | Promise<Blog> {
    return this.httpClient.get<Blog>(`${environment.apiUrl}/blog/${this.id}`);
  }
}
