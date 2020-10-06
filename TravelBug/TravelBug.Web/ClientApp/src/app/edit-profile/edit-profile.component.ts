import { Component, OnInit } from "@angular/core";
import { ActivatedRoute, Router } from "@angular/router";
import { Profile } from "../models/profile";
import { PhotoService } from "../services/photo.service";
import { ProfileService } from "../services/profile.service";

@Component({
  selector: "app-edit-profile",
  templateUrl: "./edit-profile.component.html",
  styleUrls: ["./edit-profile.component.css"],
})
export class EditProfileComponent implements OnInit {
  warning = false;
  profile: Profile;
  photoDataUrl: string | ArrayBuffer;
  photoFile: File;
  backToLink = ["/profile", window.localStorage.getItem("travelBug:Username")];

  constructor(
    private activatedRoute: ActivatedRoute,
    private router: Router,
    private userService: ProfileService,
    private photoService: PhotoService
  ) {}

  ngOnInit() {
    this.activatedRoute.data.subscribe((data: { profile: Profile }) => {
      this.profile = data.profile;
    });
  }

  onSelectFile(event) {
    if (event.target.files && event.target.files[0]) {
      // Add file for upload
      this.photoFile = <File>event.target.files[0];

      // Get data url to display selected image
      var reader = new FileReader();
      reader.readAsDataURL(this.photoFile);
      reader.onload = (pe: ProgressEvent) => {
        this.photoDataUrl = reader.result;
      };
    }
  }

  onClickDelete() {
    //
  }

  onSubmit() {
    this.userService.editProfile(this.profile).subscribe(() => {
      if (this.photoFile) {
        let fd = new FormData();
        fd.append("files", this.photoFile, "profile-picture");
        this.photoService.uploadProfilePicture(fd);
      }
      this.router.navigate([
        "/profile",
        window.localStorage.getItem("travelBug:Username"),
      ]);
    });
  }
}
