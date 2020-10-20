import {
  AfterViewInit,
  Component,
  ElementRef,
  Input,
  OnInit,
  ViewChild,
} from "@angular/core";
import { Subscription } from "rxjs";
import { GmapService } from "../services/gmap.service";

@Component({
  selector: "app-google-map",
  templateUrl: "./google-map.component.html",
  styleUrls: ["./google-map.component.css"],
})
export class GoogleMapComponent implements OnInit, AfterViewInit {
  componentInit = false;
  componentInitSub: Subscription;
  viewInit = false;
  viewInitSub: Subscription;
  gmap: google.maps.Map;

  @Input() height: string;
  @Input() lat: number;
  @Input() lng: number;
  @ViewChild("mapContainer", { static: false }) elementRef: ElementRef;

  constructor(private gmapService: GmapService) {}

  // Make sure both the component and view are initiated
  ngOnInit() {
    this.componentInit = true;
    if (this.viewInit) this.mapInitialization();
  }

  ngAfterViewInit() {
    this.viewInit = true;
    if (this.componentInit) this.mapInitialization();
  }

  mapInitialization() {
    if (this.lat && this.lng) {
      let coords = { lat: this.lat, lng: this.lng };
      this.gmapService.initMap(this.elementRef.nativeElement, coords);
    } else {
      this.gmapService.initMapWithUserLocation(this.elementRef.nativeElement);
    }
  }

  findUserLocation() {
    // let map = new google.maps.Map(
    //   document.getElementById("map") as HTMLElement,
    //   {
    //     center: { lat: 51.5073, lng: -0.12755 },
    //     zoom: 8,
    //   }
    // );
    let infoWindow = new google.maps.InfoWindow();

    // Try HTML5 geolocation.
    if (navigator.geolocation) {
      navigator.geolocation.getCurrentPosition(
        (position: Position) => {
          const pos = {
            lat: position.coords.latitude,
            lng: position.coords.longitude,
          };

          infoWindow.setPosition(pos);
          infoWindow.setContent("Location found.");
          infoWindow.open(this.elementRef.nativeElement);
          this.elementRef.nativeElement.setCenter(pos);
        },
        () => {
          this.handleLocationError(true, infoWindow, this.gmap.getCenter());
        }
      );
    } else {
      // Browser doesn't support Geolocation
      this.handleLocationError(false, infoWindow, this.gmap.getCenter());
    }
  }

  handleLocationError(
    browserHasGeolocation: boolean,
    infoWindow: google.maps.InfoWindow,
    pos: google.maps.LatLng
  ) {
    infoWindow.setPosition(pos);
    infoWindow.setContent(
      browserHasGeolocation
        ? "Error: The Geolocation service failed."
        : "Error: Your browser doesn't support geolocation."
    );
    infoWindow.open(this.gmap);
  }
}
