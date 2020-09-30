import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";

import { environment } from "src/environments/environment";
import { Blog } from "../models/blog";
import { tap } from "rxjs/operators";
import { PostBlogResponse } from "../new-blog/post-blog-response";
import { ImageUploadResponse } from "../new-blog/image-upload-response";
import { Observable } from "rxjs";
import { PhotoService } from "./photo.service";
import { Router } from "@angular/router";

@Injectable({
  providedIn: "root",
})
export class BlogService {
  blogs: Blog[] = [];
  private currentBlog: Blog;
  private editedBlog: Blog;

  constructor(
    private httpClient: HttpClient,
    private photoService: PhotoService,
    private router: Router
  ) {}

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

  // Post blog and upload photos
  postBlog(blog: Blog) {
    // Post blog without images
    return this.httpClient.post<PostBlogResponse>(
      `${environment.apiUrl}/blog`,
      blog
    );
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
