import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Blog } from '../blogs/blog';

@Injectable({
  providedIn: 'root'
})
export class BlogService {
  blogs: Blog[] = [];

  constructor(private httpClient: HttpClient) { }

  postBlog(blog: Blog) {
    return this.httpClient.post("/api/blog/", blog)
  }

  showBlogs() {
    return this.blogs;
  }

  fetchBlogs() {
    return this.httpClient.get<{blogs: Blog[]}>(`/api/blog/`)
  }

  getBlog(blogId: string) {
    return this.httpClient.get<{blog: Blog}>(`/api/blog/${blogId}`);
  }

  patchBlog(blogId: string, blog: Blog) {
    return this.httpClient.patch(`/api/blog/${blogId}`, blog);
  }

  deleteBlog(blogId: string) {
    return this.httpClient.delete(`/api/blog/${blogId}`)
  }
}
