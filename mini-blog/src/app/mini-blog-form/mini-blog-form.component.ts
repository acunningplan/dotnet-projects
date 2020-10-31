import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { MiniBlog } from '../models/mini-blog';

@Component({
  selector: 'app-mini-blog-form',
  templateUrl: './mini-blog-form.component.html',
  styleUrls: ['./mini-blog-form.component.css'],
})
export class MiniBlogFormComponent implements OnInit {
  blog = new MiniBlog();
  @Output() blogSubmitted = new EventEmitter<MiniBlog>();

  constructor() {}

  ngOnInit(): void {}

  submitBlog() {
    console.log(this.blog);
    this.blogSubmitted.emit(this.blog);
    this.blog = new MiniBlog();
  }
}
