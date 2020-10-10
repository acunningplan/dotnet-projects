import { Component, OnInit, Input } from "@angular/core";
import * as moment from "moment";
import { Blog } from "src/app/models/blog";

@Component({
  selector: "app-blog-detail",
  templateUrl: "./blog-detail.component.html",
  styleUrls: ["./blog-detail.component.css"],
})
export class BlogDetailComponent implements OnInit {
  @Input() blog: Blog;
  dateCreated: string;

  constructor() {}

  ngOnInit() {
    this.dateCreated = moment(this.blog.created).format("h:mma, D MMM");
  }
}
