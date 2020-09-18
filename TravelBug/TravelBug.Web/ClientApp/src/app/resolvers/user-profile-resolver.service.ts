import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { ActivatedRouteSnapshot, RouterStateSnapshot } from "@angular/router";
import { Observable } from "rxjs";
import { environment } from "src/environments/environment";
import { Profile } from "../models/profile";
import { UserService } from "../services/user.service";

@Injectable({
  providedIn: "root",
})
export class UserProfileResolverService {
  constructor(
    private httpClient: HttpClient,
    private userService: UserService
  ) {}

  resolve(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot
  ): Profile | Observable<Profile> | Promise<Profile> {
    return this.httpClient.get<Profile>(`${environment.apiUrl}/user/`);
  }
}
