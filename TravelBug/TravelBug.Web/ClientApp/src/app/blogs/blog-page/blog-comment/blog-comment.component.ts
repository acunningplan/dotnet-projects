import { Component, Input, OnInit } from '@angular/core';
import * as moment from 'moment';
import { BlogComment } from 'src/app/models/comment';

@Component({
  selector: 'app-blog-comment',
  templateUrl: './blog-comment.component.html',
  styleUrls: ['./blog-comment.component.css']
})
export class BlogCommentComponent implements OnInit {
  @Input() comment: BlogComment;
  dateCreated: string;

  constructor() { }

  ngOnInit() {
    this.dateCreated = moment(this.comment.created).format('hh:mm, Do MMM');
  }

}
