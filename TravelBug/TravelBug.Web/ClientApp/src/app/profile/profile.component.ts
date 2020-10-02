import { Component, OnInit } from "@angular/core";
import { AccountService } from "../services/account.service";
import { Subscription } from "rxjs";
import { Blog } from "../models/blog";
import { Profile } from "../models/profile";
import { ActivatedRoute } from "@angular/router";
import { environment } from "src/environments/environment";

@Component({
  selector: "app-profile",
  templateUrl: "./profile.component.html",
  styleUrls: ["./profile.component.css"],
})
export class ProfileComponent implements OnInit {
  loginSub: Subscription;
  blogs: Blog[];
  profile: Profile;
  allowEdit = false;

  constructor(
    private accountService: AccountService,
    private activatedRoute: ActivatedRoute,
    private route: ActivatedRoute
  ) {}

  ngOnInit() {
    let username = this.route.snapshot.url[1].path;
    if (username === window.localStorage.getItem("travelBug:Username")) {
      this.allowEdit = true;
    }
    this.activatedRoute.data.subscribe(
      (data: { profile: Profile; blogs: Blog[] }) => {
        console.log(data);
        this.profile = data.profile;
        this.blogs = data.blogs;
        if (this.profile && !this.profile.photoUrl)
          this.profile.photoUrl = environment.defaultPhotoUrl;
      }
    );
  }

  signOut() {
    this.accountService.signOut();
  }

  onEdit() {
    
  }
}
