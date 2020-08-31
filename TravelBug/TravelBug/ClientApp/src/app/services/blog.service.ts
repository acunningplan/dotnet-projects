import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Blog } from "../blogs/blog";
import { environment } from "src/environments/environment";

@Injectable({
  providedIn: "root",
})
export class BlogService {
  blogs: Blog[] = [];

  constructor(private httpClient: HttpClient) {}

  postBlog(blog: Blog) {
    return this.httpClient.post(`${environment.apiUrl}/blog/`, blog);
  }

  showBlogs() {
    return this.blogs;
  }

  fetchBlogs() {
    return this.httpClient.get<Blog[]>(`${environment.apiUrl}/blog/`);
  }

  getBlog(blogId: string) {
    return this.httpClient.get<{ blog: Blog }>(
      `${environment.apiUrl}/blog/${blogId}`
    );
  }

  patchBlog(blogId: string, blog: Blog) {
    return this.httpClient.patch(`${environment.apiUrl}/blog/${blogId}`, blog);
  }

  deleteBlog(blogId: string) {
    return this.httpClient.delete(`${environment.apiUrl}/blog/${blogId}`);
  }
}
