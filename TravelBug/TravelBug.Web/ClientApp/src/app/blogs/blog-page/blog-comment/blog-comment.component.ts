import { Component, Input, OnInit } from '@angular/core';
import * as moment from 'moment';
import { BlogComment } from 'src/app/models/comment';
import { CommentService } from 'src/app/services/comment.service';

@Component({
  selector: 'app-blog-comment',
  templateUrl: './blog-comment.component.html',
  styleUrls: ['./blog-comment.component.css']
})
export class BlogCommentComponent implements OnInit {
  @Input() comment: BlogComment;
  dateCreated: string;
  ownComment: boolean;

  constructor(private commentService: CommentService) { }

  ngOnInit() {
    this.dateCreated = moment(this.comment.created).format('hh:mm, Do MMM');
    this.ownComment = window.localStorage.getItem("travelBug:Username") === this.comment.author.username;
  }

  editComment() {
    this.commentService
  }

  deleteComment() {
    this.commentService.deleteComment(this.comment.blogId, this.comment.id)
      .subscribe(res => {
      // trigger onDestroy hook?
        console.log("Deleted")
      }, err => {
        console.log(`Error, ${err}`)
      });
  }

  ngOnDestroy() {

  }
}
