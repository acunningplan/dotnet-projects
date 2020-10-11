import { HttpClient } from "@angular/common/http";
import { Component, Input, OnInit } from "@angular/core";
import { Profile } from "src/app/models/profile";
import { NotificationService } from "src/app/services/notification.service";
import { ProfileService } from "src/app/services/profile.service";
import { environment } from "src/environments/environment";

@Component({
  selector: "app-featured-user",
  templateUrl: "./user-detail.component.html",
  styleUrls: ["./user-detail.component.css"],
})
export class FeaturedUserDetailComponent implements OnInit {
  @Input() user: Profile;
  ownUsername: string;

  constructor(
    private userService: ProfileService,
    private notificationService: NotificationService
  ) {}

  ngOnInit() {
    this.ownUsername = window.localStorage.getItem("travelBug:Username");
    this.user.following = !!this.user.followers.find(
      (f) => f.followingUser === this.ownUsername
    );
  }

  followUser() {
    this.userService.followUser(this.user).subscribe((res) => {
      this.user.following = true;
      this.notificationService.showSuccess(
        "User followed! Refresh page to get new blog feed."
      );
    });
  }

  unfollowUser() {
    this.userService.unfollowUser(this.user).subscribe((res) => {
      this.user.following = false;
      this.notificationService.showSuccess(
        "User unfollowed! Refresh page to get new blog feed."
      );
    });
  }
}
