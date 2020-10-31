import { Component } from '@angular/core';
import { MiniBlog } from './models/mini-blog';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
})
export class AppComponent {
  title = 'Welcome to the mini-blog site.';
  blogs: MiniBlog[] = [
    {
      title: 'Another sample blog',
      description: 'This is the second mini-blog.',
    },
    { title: 'Sample blog', description: "Here's a sample mini-blog." },
  ];

  onAddBlog(blog: MiniBlog) {
    this.blogs.unshift(blog);
  }
}
