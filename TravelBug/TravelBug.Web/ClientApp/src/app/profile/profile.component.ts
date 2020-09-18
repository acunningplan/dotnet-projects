import { Component, OnInit } from "@angular/core";
import { AccountService } from "../services/account.service";
import { Subscription } from "rxjs";
import { Blog } from "../models/blog";
import { BlogService } from "../services/blog.service";

@Component({
  selector: "app-profile",
  templateUrl: "./profile.component.html",
  styleUrls: ["./profile.component.css"],
})
export class ProfileComponent implements OnInit {
  loginSub: Subscription;
  blogs: Blog[];

  constructor(private accountService: AccountService, private blogService: BlogService) {}

  ngOnInit() {
    this.blogService.fetchOwnBlogs().subscribe(blogs => {
      this.blogs = blogs
    });
  }

  signOut() {
    this.accountService.signOut();
  }
}
