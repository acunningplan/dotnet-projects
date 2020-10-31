import { Component, Input, OnInit } from '@angular/core';
import { MiniBlog } from '../models/mini-blog';

@Component({
  selector: 'app-mini-blog',
  templateUrl: './mini-blog.component.html',
  styleUrls: ['./mini-blog.component.css'],
})
export class MiniBlogComponent implements OnInit {
  @Input() blog: MiniBlog = new MiniBlog();

  constructor() {}

  ngOnInit(): void {}
}
