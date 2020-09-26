import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";

import { environment } from "src/environments/environment";
import { Blog } from "../models/blog";
import { tap } from "rxjs/operators";

@Injectable({
  providedIn: "root",
})
export class BlogService {
  blogs: Blog[] = [];
  private currentBlog: Blog;
  private editedBlog: Blog;

  constructor(private httpClient: HttpClient) {}

  saveCurrentBlog(blog: Blog) {
    this.currentBlog = blog;
  }

  fetchOwnBlogs() {
    return this.httpClient.get<Blog[]>(`${environment.apiUrl}/blog/user`).pipe(
      tap((res) => {
        // print response
      })
    );
  }

  loadCurrentBlog() {
    return this.currentBlog || new Blog();
  }

  // Edit blog
  setEditedBlog(blog: Blog) {
    this.editedBlog = blog;
  }

  loadEditedBlog() {
    return this.editedBlog || new Blog();
  }

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

  patchBlog(blog: Blog) {
    // Send patch request to .net core backend using "patch documents"
    let keysToChange = ["title", "description"];
    return this.httpClient.patch(
      `${environment.apiUrl}/blog/${blog.id}`,
      keysToChange.map((k) => ({
        op: "replace",
        path: k,
        value: blog[k],
      }))
    );
  }

  deleteBlog(blogId: string) {
    return this.httpClient.delete(`${environment.apiUrl}/blog/${blogId}`);
  }
}
