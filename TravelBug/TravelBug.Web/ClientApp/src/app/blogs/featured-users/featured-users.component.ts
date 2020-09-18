import { Component, OnInit } from '@angular/core';
import { Profile } from 'src/app/models/profile';

@Component({
  selector: 'app-featured-users',
  templateUrl: './featured-users.component.html',
  styleUrls: ['./featured-users.component.css']
})
export class FeaturedUsersComponent implements OnInit {
  users: Profile[] = [];

  constructor() { }

  ngOnInit() {
    // fetch users here
  }

}
