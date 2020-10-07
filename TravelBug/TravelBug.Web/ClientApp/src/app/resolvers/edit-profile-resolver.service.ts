import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { ActivatedRouteSnapshot, RouterStateSnapshot } from "@angular/router";
import { Observable } from "rxjs";
import { environment } from "src/environments/environment";
import { Profile } from "../models/profile";

@Injectable({
  providedIn: "root",
})
export class EditProfileResolverService {
  constructor(private httpClient: HttpClient) {}

  resolve(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot
  ): Profile | Observable<Profile> | Promise<Profile> {
    return this.httpClient.get<Profile>(
      `${environment.apiUrl}/profile/${window.localStorage.getItem(
        "travelBug:Username"
      )}`
    );
  }
}
