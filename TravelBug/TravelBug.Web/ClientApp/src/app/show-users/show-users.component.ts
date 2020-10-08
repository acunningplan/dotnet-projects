import { Component, OnInit } from "@angular/core";
import { ActivatedRoute } from "@angular/router";
import { Profile } from "../models/profile";

@Component({
  selector: "app-show-users",
  templateUrl: "./show-users.component.html",
  styleUrls: ["./show-users.component.css"],
})
export class ShowUsersComponent implements OnInit {
  users: Profile[];

  constructor(private activatedRoute: ActivatedRoute) {}

  ngOnInit() {
    this.activatedRoute.data.subscribe((data: { users: Profile[] }) => {
      console.log(data.users);
      this.users = data.users;
      // this.users = data.users.sort((x, y) => {
      //   // return y.username - x.username;
      // });
    });
  }
}
