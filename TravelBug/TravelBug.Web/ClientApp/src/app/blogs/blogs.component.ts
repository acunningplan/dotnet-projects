import { Component, OnInit, OnDestroy } from "@angular/core";
import { Blog } from "./blog";
import { BlogService } from "../services/blog.service";
import { FetchDataService } from "../services/fetch-data.service";
import { SiteData } from "../models/site-data";
import { Subscription } from "rxjs";
import { environment } from "src/environments/environment";
import { HttpClient } from "@angular/common/http";
import { ActivatedRoute } from "@angular/router";

@Component({
  selector: "app-blogs",
  templateUrl: "./blogs.component.html",
  styleUrls: ["./blogs.component.css"],
})
export class BlogsComponent implements OnInit, OnDestroy {
  siteDataSub: Subscription;
  blogs: Blog[];

  constructor(private activatedRoute: ActivatedRoute) {}

  ngOnInit() {
    this.activatedRoute.data.subscribe((data: { blogs: Blog[] }) => {
      console.log(data);
      this.blogs = data.blogs;
    });
  }

  ngOnDestroy() {
    // this.siteDataSub!.unsubscribe();
  }
}
