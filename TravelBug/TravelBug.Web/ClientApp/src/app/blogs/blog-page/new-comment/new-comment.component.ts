import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { BlogComment } from 'src/app/models/comment';

@Component({
  selector: 'app-new-comment',
  templateUrl: './new-comment.component.html',
  styleUrls: ['./new-comment.component.css']
})
export class NewCommentComponent implements OnInit {
  newComment= new BlogComment();

  constructor() { }

  ngOnInit() {
  }

  onSubmit(description: NgForm) {
    console.log(description.value);
  }
}
