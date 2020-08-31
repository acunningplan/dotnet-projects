import { Component, OnInit } from "@angular/core";
import { Blog } from "./blog";
import { BlogService } from "../services/blog.service";

@Component({
  selector: "app-blogs",
  templateUrl: "./blogs.component.html",
  styleUrls: ["./blogs.component.css"],
})
export class BlogsComponent implements OnInit {
  blogs: Blog[];

  constructor(private blogService: BlogService) {}

  ngOnInit() {
    this.blogService.fetchBlogs().subscribe((res) => {
      this.blogs = res;
    });
    console.log("Showing blogs.");
    console.log(this.blogs);
    // this.blogs = this.blogService.showBlogs();
  }
}
