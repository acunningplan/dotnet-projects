import { Component, OnDestroy, OnInit } from "@angular/core";
import { Router } from "@angular/router";
import { Blog } from "../models/blog";
import { BlogService } from "../services/blog.service";

@Component({
  selector: "app-new-blog",
  templateUrl: "./new-blog.component.html",
  styleUrls: ["./new-blog.component.css"],
})
export class NewBlogComponent implements OnInit, OnDestroy {
  blog: Blog;

  constructor(private blogService: BlogService, private router: Router) {}

  ngOnInit() {
    this.blog = this.blogService.loadCurrentBlog();
  }

  onSubmit() {
    // console.log(this.blog);
    this.blogService.postBlog(this.blog).subscribe(() => {
      this.router.navigate(["/"]);
    });
  }

  ngOnDestroy() {
    this.blogService.saveCurrentBlog(this.blog);
  }
}
