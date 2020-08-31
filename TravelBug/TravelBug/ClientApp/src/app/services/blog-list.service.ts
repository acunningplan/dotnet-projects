import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Blog } from '../blogs/blog';

@Injectable({
  providedIn: 'root'
})
export class BlogListService {

  constructor(private httpClient: HttpClient) { }

  getBlogList(keyword: string) {
    this.httpClient.get<Blog[]>("blog/list");
  }
}
