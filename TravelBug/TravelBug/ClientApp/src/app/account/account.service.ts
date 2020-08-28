import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class AccountService {

  constructor() { }

  private profile: Profile;

  getProfile() {
    return this.profile;
  }
}
