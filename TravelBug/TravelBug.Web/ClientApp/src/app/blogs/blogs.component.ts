import { Component, OnInit, OnDestroy } from "@angular/core";
import { Subscription } from "rxjs";
import { ActivatedRoute } from "@angular/router";
import { Blog } from "../models/blog";
import * as moment from "moment";
import { LoadingBarService } from "@ngx-loading-bar/core";

@Component({
  selector: "app-blogs",
  templateUrl: "./blogs.component.html",
  styleUrls: ["./blogs.component.css"],
})
export class BlogsComponent implements OnInit {
  blogs: Blog[] = null;

  constructor(private activatedRoute: ActivatedRoute, private loadingBar: LoadingBarService) {}

  ngOnInit() {
    this.activatedRoute.data.subscribe((data: { blogs: Blog[] }) => {
      console.log(data.blogs);
      this.blogs = data.blogs.sort((x, y) => {
        return +new Date(y.created) - +new Date(x.created);
      });

    this.loadingBar.complete();
    });
  }
}
