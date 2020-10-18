import { HttpClient } from "@angular/common/http";
import {
  AfterViewInit,
  Component,
  ElementRef,
  OnInit,
  ViewChild,
} from "@angular/core";
import { ActivatedRoute } from "@angular/router";
import { environment } from "src/environments/environment";

@Component({
  selector: "app-verify-email",
  templateUrl: "./verify-email.component.html",
  styleUrls: ["./verify-email.component.css"],
})
export class VerifyEmailComponent implements OnInit, AfterViewInit {
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

  title = "angular-gmap";
  @ViewChild("mapContainer", { static: false }) gmap: ElementRef;
  map: google.maps.Map;

  ngAfterViewInit() {
    this.mapInitializer();
  }

  mapInitializer() {
    let lat = 40.73061;
    let lng = -73.935242;
    let coordinates = new google.maps.LatLng(lat, lng);

    let mapOptions: google.maps.MapOptions = {
      center: coordinates,
      zoom: 8,
    };

    let marker = new google.maps.Marker({
      position: coordinates,
      map: this.map,
    });

    let map = new google.maps.Map(this.gmap.nativeElement, mapOptions);
    marker.setMap(map);
  }
}
