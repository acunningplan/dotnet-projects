import { Component, OnInit } from "@angular/core";
import { AccountService } from "../services/account.service";
import { Subscription } from "rxjs";
import { Blog } from "../models/blog";
import { Profile } from "../models/profile";
import { ActivatedRoute } from "@angular/router";
import { environment } from "src/environments/environment";
import { ProfileService } from "../services/profile.service";

@Component({
  selector: "app-profile",
  templateUrl: "./profile.component.html",
  styleUrls: ["./profile.component.css"],
})
export class ProfileComponent implements OnInit {
  loginSub: Subscription;
  blogs: Blog[];
  currentUsername: string;
  ownProfile = false;
  profile: Profile;

  constructor(
    private accountService: AccountService,
    private userService: ProfileService,
    private activatedRoute: ActivatedRoute,
    private route: ActivatedRoute
  ) {}

  ngOnInit() {
    this.currentUsername = window.localStorage.getItem("travelBug:Username");
    let username = this.route.snapshot.url[1].path;

    this.activatedRoute.data.subscribe(
      (data: { profile: Profile; blogs: Blog[] }) => {
        console.log(data);
        this.profile = data.profile;
        this.blogs = data.blogs;
        if (this.profile && !this.profile.photoUrl)
          this.profile.photoUrl = environment.defaultPhotoUrl;
      }
    );

    // Check whether this is the current user's profile
    if (username === this.currentUsername) {
      this.ownProfile = true;
    } else {
      // If not, find out whether current user is following him or her
      this.profile.following = !!this.profile.followers.find(
        (f) => f.followingUser === this.currentUsername
      );
    }
  }

  signOut() {
    this.accountService.signOut();
  }

  onEdit() {}

  onFollow() {
    this.userService
      .followUser(this.profile)
      .subscribe(() => (this.profile.following = true));
  }

  onUnfollow() {
    this.userService
      .unfollowUser(this.profile)
      .subscribe(() => (this.profile.following = false));
  }
}
