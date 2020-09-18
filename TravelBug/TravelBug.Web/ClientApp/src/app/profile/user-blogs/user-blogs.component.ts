import { Component, Input, OnInit } from "@angular/core";
import { Blog } from "src/app/models/blog";
import { BlogService } from "src/app/services/blog.service";

@Component({
  selector: "app-user-blogs",
  templateUrl: "./user-blogs.component.html",
  styleUrls: ["./user-blogs.component.css"],
})
export class UserBlogsComponent implements OnInit {
  @Input() blogs: Blog[];

  constructor() {}

  ngOnInit() {
    
  }
}
