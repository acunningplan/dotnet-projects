import { Component, Input, OnInit } from "@angular/core";
import { NgForm } from "@angular/forms";
import * as moment from "moment";
import { BlogComment } from "src/app/models/comment";
import { CommentService } from "src/app/services/comment.service";
import { LoadingService } from "src/app/services/loading.service";

@Component({
  selector: "app-blog-comment",
  templateUrl: "./blog-comment.component.html",
  styleUrls: ["./blog-comment.component.css"],
})
export class BlogCommentComponent implements OnInit {
  @Input() comment: BlogComment;
  dateCreated: string;
  ownComment: boolean;

  editMode = false;
  editedComment: string;

  constructor(
    private commentService: CommentService,
    private loadingService: LoadingService
  ) {}

  ngOnInit() {
    this.dateCreated = moment(this.comment.created).format("hh:mma, Do MMM");
    this.ownComment =
      window.localStorage.getItem("travelBug:Username") ===
      this.comment.author.username;
    this.editedComment = this.comment.description;
  }

  editComment() {
    this.loadingService.loading.next(true);
    this.comment.description = this.editedComment;
    this.commentService
      .patchComment(this.comment.id, this.comment)
      .subscribe(() => {
        this.editMode = false;
        this.loadingService.loading.next(false);
      });
  }

  deleteComment() {
    this.loadingService.loading.next(true);
    this.commentService
      .deleteComment(this.comment.blogId, this.comment.id)
      .subscribe((res) => {
        this.loadingService.loading.next(false);
        this.comment.description = null;
        this.commentService.commentChange.next(this.comment);
      });
  }

  cancelEdit() {
    this.editMode = false;
    this.editedComment = this.comment.description;
  }

  ngOnDestroy() {}
}
