import { Component, OnInit } from "@angular/core";
import { environment } from "src/environments/environment";

@Component({
  selector: "app-root",
  templateUrl: "./app.component.html",
})
export class AppComponent implements OnInit {
  title = "app";

  ngOnInit() {
    // FB.init({ appId: environment.fbAppId, version: "v2.7" });
  }
}
