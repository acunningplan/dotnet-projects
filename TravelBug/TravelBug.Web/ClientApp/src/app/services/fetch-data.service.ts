import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Blog } from "../blogs/blog";
import { Router } from "@angular/router";
import { SiteData } from "../models/site-data";
import { environment } from "src/environments/environment";
import { Subject } from "rxjs";

@Injectable({
  providedIn: "root",
})
export class FetchDataService {
  data = new Subject<SiteData>();

  constructor(private httpClient: HttpClient, private router: Router) {}

  fetchData(route: string) {
    switch (route) {
      case "/blogs":
        console.log("Fetching blogs");
        this.httpClient
          .get<Blog[]>(`${environment.apiUrl}/blog/`)
          .subscribe((res) => {
            this.data.next(new SiteData(res));
            this.router.navigate(["/blogs"]);
          });
        break;
    }
  }
}
