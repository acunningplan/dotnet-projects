import { HttpClient } from "@angular/common/http";
import { Component, OnInit } from "@angular/core";
import { ActivatedRoute } from "@angular/router";
import { environment } from "src/environments/environment";

@Component({
  selector: "app-verify-email",
  templateUrl: "./verify-email.component.html",
  styleUrls: ["./verify-email.component.css"],
})
export class VerifyEmailComponent implements OnInit {
  confirmingEmail = false;

  constructor(private httpClient: HttpClient, private route: ActivatedRoute) {}

  ngOnInit() {
    this.route.queryParams.subscribe((params) => {
      const email = params["email"];
      const token = params["token"];
      if (email && token) {
        this.confirmingEmail = true;
        this.httpClient
          .post(`${environment.apiUrl}/user/verify-email`, {
            email,
            token,
          })
          .subscribe(
            () => console.log("Verification successful"),
            () => console.log("Cannot verify email.")
          );
      }
    });
  }

  // @ViewChild("mapContainer", { static: false }) gmap: ElementRef;

  // ngAfterViewInit() {
  //   this.mapInitializer();
  // }

  // mapInitializer() {
  //   let lat = 40.73061;
  //   let lng = -73.935242;
  //   let coordinates = new google.maps.LatLng(lat, lng);

  //   // Set map location
  //   let mapOptions: google.maps.MapOptions = {
  //     center: coordinates,
  //     zoom: 13,
  //   };

  //   // Set marker location
  //   let marker = new google.maps.Marker({
  //     position: coordinates,
  //   });

  //   // Assign map to HTML element
  //   let map = new google.maps.Map(this.gmap.nativeElement, mapOptions);
  //   marker.setMap(map);
  // }
}
