import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { ActivatedRouteSnapshot, RouterStateSnapshot } from "@angular/router";
import { Observable } from "rxjs";
import { environment } from "src/environments/environment";
import { Profile } from "../models/profile";
import { LoadingService } from "../services/loading.service";

@Injectable({
  providedIn: "root",
})
export class UserProfileResolverService {
  constructor(private httpClient: HttpClient, private loadingService: LoadingService) {}

  resolve(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot
  ): Profile | Observable<Profile> | Promise<Profile> {
    this.loadingService.loading.next(true);
    return this.httpClient.get<Profile>(
      `${environment.apiUrl}/profile/${route.params["username"]}`
    );
  }
}
