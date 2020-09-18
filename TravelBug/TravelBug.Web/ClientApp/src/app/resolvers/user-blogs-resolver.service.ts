import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Blog } from '../models/blog';
import { BlogService } from '../services/blog.service';
import { UserService } from '../services/user.service';

@Injectable({
  providedIn: 'root'
})
export class UserBlogsResolverService {
  constructor(
    private httpClient: HttpClient,
    private blogService: BlogService
  ) {}

  resolve(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot
  ): Blog[] | Observable<Blog[]> | Promise<Blog[]> {
    return this.httpClient.get<Blog[]>(`${environment.apiUrl}/blog/user`);
  }
}
