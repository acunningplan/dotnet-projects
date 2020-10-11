import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { ActivatedRouteSnapshot, RouterStateSnapshot } from "@angular/router";
import { LoadingBarService } from "@ngx-loading-bar/core";
import { Observable } from "rxjs";
import { environment } from "src/environments/environment";
import { Profile } from "../models/profile";

@Injectable({
  providedIn: "root",
})
export class UserProfileResolverService {
  constructor(private httpClient: HttpClient, private loadingBarService: LoadingBarService) {}

  resolve(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot
  ): Profile | Observable<Profile> | Promise<Profile> {
    this.loadingBarService.start();
    return this.httpClient.get<Profile>(
      `${environment.apiUrl}/profile/${route.params["username"]}`
    );
  }
}
