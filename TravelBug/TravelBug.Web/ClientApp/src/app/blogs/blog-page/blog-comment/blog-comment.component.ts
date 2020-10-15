import { Component, Input, OnInit } from '@angular/core';
import { BlogComment } from 'src/app/models/comment';

@Component({
  selector: 'app-blog-comment',
  templateUrl: './blog-comment.component.html',
  styleUrls: ['./blog-comment.component.css']
})
export class BlogCommentComponent implements OnInit {
  @Input() comment: BlogComment;

  constructor() { }

  ngOnInit() {
  }

}
