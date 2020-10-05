import { Component, OnInit } from "@angular/core";
import { ActivatedRoute, Router } from "@angular/router";
import { Profile } from "../models/profile";
import { ProfileService } from "../services/profile.service";

@Component({
  selector: "app-edit-profile",
  templateUrl: "./edit-profile.component.html",
  styleUrls: ["./edit-profile.component.css"],
})
export class EditProfileComponent implements OnInit {
  profile: Profile;
  backToLink = ["/profile", window.localStorage.getItem("travelBug:Username")];

  constructor(
    private activatedRoute: ActivatedRoute,
    private router: Router,
    private userService: ProfileService
  ) {}

  ngOnInit() {
    this.activatedRoute.data.subscribe((data: { profile: Profile }) => {
      this.profile = data.profile;
    });
  }

  onSubmit() {
    this.userService.editProfile(this.profile).subscribe(() => {
      this.router.navigate([
        "/profile",
        window.localStorage.getItem("travelBug:Username"),
      ]);
    });
  }
}
