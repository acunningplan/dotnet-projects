import { Component, OnInit, OnDestroy } from "@angular/core";
import { Subscription } from "rxjs";
import { ActivatedRoute } from "@angular/router";
import { Blog } from "../models/blog";

@Component({
  selector: "app-blogs",
  templateUrl: "./blogs.component.html",
  styleUrls: ["./blogs.component.css"],
})
export class BlogsComponent implements OnInit, OnDestroy {
  siteDataSub: Subscription;
  blogs: Blog[] = null;

  constructor(private activatedRoute: ActivatedRoute) {}

  ngOnInit() {
    this.activatedRoute.data.subscribe((data: { blogs: Blog[] }) => {
      console.log(data.blogs);
      this.blogs = data.blogs.sort((x, y) => {
        return Date.parse(y.created) - Date.parse(x.created);
      });
    });
  }

  ngOnDestroy() {
    // this.siteDataSub!.unsubscribe();
  }
}
