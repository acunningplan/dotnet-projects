import { Component, Input, OnInit } from "@angular/core";
import { ActivatedRoute } from "@angular/router";
import { Blog } from "src/app/models/blog";
import { RouterTrackingService } from "src/app/services/router-tracking.service";

@Component({
  selector: "app-blog-page",
  templateUrl: "./blog-page.component.html",
  styleUrls: ["./blog-page.component.css"],
})
export class BlogPageComponent implements OnInit {
  blog: Blog;
  id: string;
  backTo = "Blogs";
  backToUrl = "/blogs";

  constructor(
    private activatedRoute: ActivatedRoute,
    private routerTrackingService: RouterTrackingService
  ) {}

  ngOnInit() {
    this.activatedRoute.data.subscribe((data: { blog: Blog }) => {
      console.log(data.blog);
      this.blog = data.blog;
    });

    // Get previous url and set back to url to previous url
    let prevUrl = this.routerTrackingService.prevUrl;
    if (prevUrl) this.backToUrl = prevUrl;

    switch (prevUrl) {
      case "/blogs":
        this.backTo = "Blogs";
        break;
      case "/profile":
        this.backTo = "Profile";
        break;
      default:
        this.backTo = "Home";
    }
  }
}
