import { Component, Input, OnInit } from "@angular/core";
import { Blog } from "src/app/models/blog";
import { Profile } from "src/app/models/profile";
import { BlogService } from "src/app/services/blog.service";

@Component({
  selector: "app-user-blogs",
  templateUrl: "./user-blogs.component.html",
  styleUrls: ["./user-blogs.component.css"],
})
export class UserBlogsComponent implements OnInit {
  @Input() blogs: Blog[];
  @Input() profile: Profile;
  @Input() ownProfile: boolean;

  constructor() {}

  ngOnInit() {
    
  }
}
