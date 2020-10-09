import { Component, Input, OnInit } from "@angular/core";
import * as moment from "moment";
import { Profile } from "src/app/models/profile";

@Component({
  selector: "app-additional-info",
  templateUrl: "./additional-info.component.html",
  styleUrls: ["./additional-info.component.css"],
})
export class AdditionalInfoComponent implements OnInit {
  @Input() profile: Profile;
  lastLogin: string;

  constructor() {}

  ngOnInit() {
    this.lastLogin = moment(this.profile.lastLogin).format("Do MMM YYYY");
  }
}
