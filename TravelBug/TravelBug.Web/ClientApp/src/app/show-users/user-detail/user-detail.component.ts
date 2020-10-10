import { Component, Input, OnInit } from '@angular/core';
import { Profile } from 'src/app/models/profile';
import { ProfileService } from 'src/app/services/profile.service';

@Component({
  selector: 'app-user-detail',
  templateUrl: './user-detail.component.html',
  styleUrls: ['./user-detail.component.css']
})
export class UserDetailComponent implements OnInit {
  @Input() user: Profile;
  ownUsername: string;

  constructor(private userService: ProfileService) {}

  ngOnInit() {
    this.ownUsername = window.localStorage.getItem("travelBug:Username")
    this.user.following = !!this.user.followers.find(
      (f) =>
        f.followingUser === this.ownUsername
    );
  }

  followUser() {
    this.userService.followUser(this.user).subscribe((res) => {
      this.user.following = true;
    });
  }

  unfollowUser() {
    this.userService.unfollowUser(this.user).subscribe((res) => {
      this.user.following = false;
    });
  }

}
