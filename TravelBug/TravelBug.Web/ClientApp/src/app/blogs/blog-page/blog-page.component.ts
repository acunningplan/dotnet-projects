import { Component, Input, OnInit } from "@angular/core";
import { ActivatedRoute, Router } from "@angular/router";
import * as moment from "moment";
import { Blog } from "src/app/models/blog";
import { BlogService } from "src/app/services/blog.service";
import { LoadingService } from "src/app/services/loading.service";
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

  latitude = 51.45395348950013;
  longitude = -0.9786673543780711;

  constructor(
    private activatedRoute: ActivatedRoute,
    private router: Router,
    private routerTrackingService: RouterTrackingService,
    private blogService: BlogService,
    private loadingService: LoadingService
  ) {}

  ngOnInit() {
    this.activatedRoute.data.subscribe((data: { blog: Blog }) => {
      console.log(data.blog);
      this.blog = data.blog;
      this.userIsAuthor =
        this.blog.user.username ===
        window.localStorage.getItem("travelBug:Username");
      this.dateCreated = moment(this.blog.created).format("h:mma, D MMM");
      if (this.blog.coordinates) {
        let location = this.blog.coordinates.split(",")
        this.latitude = parseFloat(location[0]) ;
        this.longitude = parseFloat(location[1]);
      }
      this.loadingService.loading.next(false);
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

  onChooseLocation(event) {
    console.log(event)
    // console.log(event.coords);
  }

  onDelete() {}
}
