import { HttpClient } from "@angular/common/http";
import { Component, OnInit } from "@angular/core";
import { ActivatedRoute } from "@angular/router";
import { Profile } from "src/app/models/profile";
import { environment } from "src/environments/environment";

@Component({
  selector: "app-featured-users",
  templateUrl: "./featured-users.component.html",
  styleUrls: ["./featured-users.component.css"],
})
export class FeaturedUsersComponent implements OnInit {
  users: Profile[] = [];

  constructor(
    private httpClient: HttpClient,
    private activatedRoute: ActivatedRoute
  ) {}

  ngOnInit() {
    this.activatedRoute.data.subscribe((data: { featuredUsers: Profile[] }) => {
      console.log(data.featuredUsers);
      this.users = data.featuredUsers;
      this.users.forEach((u) => {
        // Check whether current user follows this featured user
        u.following = u.followers.includes(
          window.localStorage.getItem("travelBug:Username")
        );
      });
    });
  }

  followUser(user: Profile) {
    this.httpClient
      .post(`${environment.apiUrl}/profiles/${user.username}/follow`, {})
      .subscribe((res) => {
        user.following = true;
      });
  }

  unfollowUser(user: Profile) {
    this.httpClient
      .post(`${environment.apiUrl}/profiles/${user.username}/unfollow`, {})
      .subscribe((res) => {
        user.following = false;
      });
  }
}
