import { Component, Input, OnInit } from "@angular/core";
import { NgForm } from "@angular/forms";
import { BlogComment } from "src/app/models/comment";
import { CommentService } from "src/app/services/comment.service";
import { LoadingService } from "src/app/services/loading.service";
import { ProfileService } from "src/app/services/profile.service";

@Component({
  selector: "app-new-comment",
  templateUrl: "./new-comment.component.html",
  styleUrls: ["./new-comment.component.css"],
})
export class NewCommentComponent implements OnInit {
  @Input() blogId: string;
  newComment = new BlogComment();

  constructor(
    private commentService: CommentService,
    private profileService: ProfileService,
    private loadingService: LoadingService
  ) {}

  ngOnInit() {
    this.newComment = new BlogComment(this.profileService.getUserProfile);
    console.log(this.newComment);
  }

  onSubmit(description: NgForm) {
    console.log("You should see the loading bar for a split second");
    this.loadingService.loading.next(true);
    this.commentService
      .postComment(description.value, this.blogId)
      .subscribe((res) => {
        this.loadingService.loading.next(false);
        this.newComment = new BlogComment();
        this.commentService.commentChange.next(res);
      });
  }
}
