import { Component, OnDestroy, OnInit } from "@angular/core";
import { Subscription } from "rxjs";
import { GmapService } from "src/app/services/gmap.service";

@Component({
  selector: "app-search-location",
  templateUrl: "./search-location.component.html",
  styleUrls: ["./search-location.component.css"],
})
export class SearchLocationComponent implements OnInit, OnDestroy {
  isSearching = false;
  isSearchingSub: Subscription;
  coordsSub: Subscription;
  locationText = "Sweeney and Todd";
  proxyUrl = "https://cors-anywhere.herokuapp.com/";

  coords: {
    lat: number;
    lng: number;
  };

  constructor(private gmap: GmapService) {}

  ngOnInit() {
    this.isSearchingSub = this.gmap.isSearching.subscribe(
      (s) => (this.isSearching = s)
    );

    this.coordsSub = this.gmap.coordsSubject.subscribe((coords) => {
      this.coords = coords;
      console.log(this.coords);
    });
  }

  searchLocation() {
    console.log("Searching");
    this.gmap.searchLocation(this.locationText);
  }

  ngOnDestroy() {
    this.isSearchingSub.unsubscribe();
    this.coordsSub.unsubscribe();
  }
}
