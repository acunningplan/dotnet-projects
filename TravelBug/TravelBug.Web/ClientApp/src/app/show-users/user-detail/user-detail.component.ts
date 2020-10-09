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

  constructor(private userService: ProfileService) {}

  ngOnInit() {
    this.user.following = !!this.user.followers.find(
      (f) =>
        f.followingUser === window.localStorage.getItem("travelBug:Username")
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
