import { Component, OnInit, Input, OnDestroy } from "@angular/core";
import { Blog } from "src/app/models/blog";

@Component({
  selector: "app-blog-detail",
  templateUrl: "./blog-detail.component.html",
  styleUrls: ["./blog-detail.component.css"],
})
export class BlogDetailComponent implements OnInit, OnDestroy {
  @Input() blog: Blog;

  constructor() {}

  ngOnInit() {}

  ngOnDestroy() {
    // this.routerSub.unsubscribe();
  }
}
