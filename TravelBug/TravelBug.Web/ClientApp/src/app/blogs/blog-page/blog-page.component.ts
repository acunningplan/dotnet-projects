import { Component, Input, OnInit } from "@angular/core";
import { ActivatedRoute } from "@angular/router";
import { Blog } from "src/app/models/blog";

@Component({
  selector: "app-blog-page",
  templateUrl: "./blog-page.component.html",
  styleUrls: ["./blog-page.component.css"],
})
export class BlogPageComponent implements OnInit {
  blog: Blog;
  id: string;

  constructor(private activatedRoute: ActivatedRoute) {}

  ngOnInit() {
    // this.activatedRoute.data.subscribe((data: { blog: Blog }) => {
    //   console.log(data.blog)
    // });
    this.activatedRoute.data.subscribe((data: { blog: Blog }) => {
      console.log(data.blog);
      this.blog = data.blog;
    });

    this.activatedRoute.params.subscribe((params) => {
      console.log(params["id"]);
      this.id = params["id"];
    });
  }
}
