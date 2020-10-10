import { Component, Input, OnInit } from "@angular/core";
import { ActivatedRoute, Router } from "@angular/router";
import * as moment from "moment";
import { Blog } from "src/app/models/blog";
import { BlogService } from "src/app/services/blog.service";
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
  userIsAuthor = false;
  dateCreated: string;

  constructor(
    private activatedRoute: ActivatedRoute,
    private router: Router,
    private routerTrackingService: RouterTrackingService,
    private blogService: BlogService
  ) {}

  ngOnInit() {
    this.activatedRoute.data.subscribe((data: { blog: Blog }) => {
      console.log(data.blog);
      this.blog = data.blog;
      this.userIsAuthor =
        this.blog.user.username ===
        window.localStorage.getItem("travelBug:Username");
      this.dateCreated = moment(this.blog.created).format("h:mma, D MMM");
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

  onEdit() {
    this.blogService.setEditedBlog(this.blog);
    this.router.navigate([`/edit-blog/${this.blog.id}`]);
  }

  onDelete() {}
}
