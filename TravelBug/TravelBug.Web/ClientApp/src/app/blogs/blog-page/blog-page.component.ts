import { Component, Input, OnInit } from "@angular/core";
import { ActivatedRoute, Router } from "@angular/router";
import * as moment from "moment";
import { Subscription } from "rxjs";
import { Blog } from "src/app/models/blog";
import { BlogComment } from "src/app/models/comment";
import { BlogService } from "src/app/services/blog.service";
import { CommentService } from "src/app/services/comment.service";
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

  // Coordinates for google map
  lat: number;
  lng: number;

  newComment = new BlogComment();
  comments: BlogComment[] = [];
  postedCommentSubscription: Subscription;

  constructor(
    private activatedRoute: ActivatedRoute,
    private router: Router,
    private routerTrackingService: RouterTrackingService,
    private blogService: BlogService,
    private loadingService: LoadingService,
    private commentService: CommentService
  ) {}

  ngOnInit() {
    this.activatedRoute.data.subscribe((data: { blog: Blog }) => {
      console.log(data.blog);
      this.blog = data.blog;
      this.comments = data.blog.comments.sort(
        (x, y) => +new Date(y.created) - +new Date(x.created)
      );
      this.userIsAuthor =
        this.blog.user.username ===
        window.localStorage.getItem("travelBug:Username");
      this.dateCreated = moment(this.blog.created).format("h:mma, D MMM");

      console.log(this.blog.coordinates);
      if (this.blog.coordinates) {
        let location = this.blog.coordinates.split(",");
        this.lat = parseFloat(location[0]);
        this.lng = parseFloat(location[1]);
      }
      this.loadingService.loading.next(false);
    });

    // Introduce comment changes to comment section
    this.postedCommentSubscription = this.commentService.commentChange.subscribe(
      (comment) => {
        // if (!comment.id) {
        // }
        // else {
        if (comment.description == null) {
          // Delete comment if description is null
          let index = this.comments.findIndex((c) => c.id == comment.id);
          this.comments.splice(index, 1);
        } else {
          // New comment: add to top of comment section
          this.comments.unshift(comment);
        }
        // }
      }
    );

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
    console.log(event);
    // console.log(event.coords);
  }

  onDelete() {}
}
