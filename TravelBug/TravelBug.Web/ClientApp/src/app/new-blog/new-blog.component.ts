import { Component, OnDestroy, OnInit } from "@angular/core";
import { NgForm } from "@angular/forms";
import { Router } from "@angular/router";
import { Blog } from "../models/blog";
import { BlogService } from "../services/blog.service";
import { RouterTrackingService } from "../services/router-tracking.service";

@Component({
  selector: "app-new-blog",
  templateUrl: "./new-blog.component.html",
  styleUrls: ["./new-blog.component.css"],
})
export class NewBlogComponent implements OnInit, OnDestroy {
  blog: Blog;
  warning: string = null;
  backToLink = "/";

  constructor(
    private blogService: BlogService,
    private router: Router,
    private routerTrackingService: RouterTrackingService
  ) {}

  ngOnInit() {
    this.blog = this.blogService.loadCurrentBlog();
    this.backToLink = this.routerTrackingService.prevUrl;
  }

  onSubmit(title: NgForm, description: NgForm) {
    // console.log(this.blog);
    // console.log(title.value, description.value);
    if (!title.value || !description.value) {
      this.warning = "Title and description must be non-empty.";
    } else {
      this.blogService.postBlog(this.blog).subscribe(() => {
        this.blog = new Blog();
        this.router.navigate(["/profile"]);
      });
    }
  }

  ngOnDestroy() {
    this.blogService.saveCurrentBlog(this.blog);
  }
}
