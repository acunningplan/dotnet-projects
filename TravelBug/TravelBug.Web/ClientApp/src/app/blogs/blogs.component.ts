import { Component, OnInit, OnDestroy } from "@angular/core";
import { Subscription } from "rxjs";
import { ActivatedRoute } from "@angular/router";
import { Blog } from "../models/blog";
import * as moment from "moment";

@Component({
  selector: "app-blogs",
  templateUrl: "./blogs.component.html",
  styleUrls: ["./blogs.component.css"],
})
export class BlogsComponent implements OnInit {
  blogs: Blog[] = null;

  constructor(private activatedRoute: ActivatedRoute) {}

  ngOnInit() {
    this.activatedRoute.data.subscribe((data: { blogs: Blog[] }) => {
      console.log(data.blogs);
      this.blogs = data.blogs.sort((x, y) => {
        return +y.created - +x.created;
      });
    });
  }
}
