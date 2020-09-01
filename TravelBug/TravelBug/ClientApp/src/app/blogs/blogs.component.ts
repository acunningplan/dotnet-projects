import { Component, OnInit, OnDestroy } from "@angular/core";
import { Blog } from "./blog";
import { BlogService } from "../services/blog.service";
import { FetchDataService } from "../services/fetch-data.service";
import { SiteData } from "../models/site-data";
import { Subscription } from "rxjs";

@Component({
  selector: "app-blogs",
  templateUrl: "./blogs.component.html",
  styleUrls: ["./blogs.component.css"],
})
export class BlogsComponent implements OnInit, OnDestroy {
  siteDataSub: Subscription;
  blogs: Blog[];

  constructor(private fetchDataService: FetchDataService) {}

  ngOnInit() {
    this.siteDataSub = this.fetchDataService.data.subscribe((data) => {
      this.blogs = data.blogs;
      console.log("Changing blogs");
    });
    // this.blogs = this.blogService.showBlogs();
  }

  ngOnDestroy() {
    this.siteDataSub!.unsubscribe();
  }
}
