import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { environment } from "src/environments/environment";
import { Profile } from "../models/profiles";

@Injectable({
  providedIn: "root",
})
export class UserService {
  constructor(private httpClient: HttpClient) {}

  getUserProfile() {
    this.httpClient.get<{ userProfile: Profile }>(`${environment.apiUrl}/user`);
  }
}
