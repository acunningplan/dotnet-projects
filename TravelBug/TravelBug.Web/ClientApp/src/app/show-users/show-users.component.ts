import { Component, OnInit } from "@angular/core";
import { ActivatedRoute } from "@angular/router";
import { LoadingBarService } from "@ngx-loading-bar/core";
import { Profile } from "../models/profile";

@Component({
  selector: "app-show-users",
  templateUrl: "./show-users.component.html",
  styleUrls: ["./show-users.component.css"],
})
export class ShowUsersComponent implements OnInit {
  users: Profile[];

  constructor(
    private activatedRoute: ActivatedRoute,
    private loadingBarService: LoadingBarService
  ) {}

  ngOnInit() {
    this.activatedRoute.data.subscribe((data: { users: Profile[] }) => {
      console.log(data.users);
      this.users = data.users.sort((x, y) => {
        return +new Date(y.lastLogin) - +new Date(x.lastLogin);
      });
      this.loadingBarService.complete();
    });
  }
}
