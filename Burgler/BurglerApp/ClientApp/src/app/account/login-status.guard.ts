import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, UrlTree } from '@angular/router';
import { Observable } from 'rxjs';
import { LoginStatusService } from './login-status-service.service';

@Injectable({
  providedIn: 'root'
})
export class LoginStatusGuard implements CanActivate {
  constructor(private loginStatusService: LoginStatusService) {}
  canActivate(
    next: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): Observable<boolean | UrlTree> | Promise<boolean | UrlTree> | boolean | UrlTree {
    return this.loginStatusService.getLoginData().loggedIn;
  }
}
