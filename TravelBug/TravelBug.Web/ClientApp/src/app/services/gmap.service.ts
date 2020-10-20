import { ElementRef, Injectable } from "@angular/core";
import { Subject } from "rxjs";

@Injectable({
  providedIn: "root",
})
export class GmapService {
  private element: HTMLElement;
  private gmap: google.maps.Map;
  private currentMarker: google.maps.Marker;
  isSearching = new Subject<boolean>();
  coordsSubject = new Subject<{ lat: number; lng: number }>();

  constructor() {}

  get defaultCoords() {
    // Charing cross
    return { lat: 51.5073, lng: -0.12755 };
  }

  getMap(element: HTMLElement, options: google.maps.MapOptions) {
    if (!options.center) options.center = this.defaultCoords;
    if (!options.zoom) options.zoom = 10;
    return new google.maps.Map(element, options);
  }

  initMapWithUserLocation(element: HTMLElement) {
    this.element = element;
    this.findUserLocation();
  }

  initMap(element: HTMLElement, coords: { lat: number; lng: number }) {
    this.element = element;
    this.gmap = new google.maps.Map(element, {
      center: coords,
      zoom: 12,
    });

    if (this.currentMarker) this.currentMarker.setMap(null);
    this.currentMarker = new google.maps.Marker({
      map: this.gmap,
      position: coords,
    });

    this.gmap.setCenter(coords);
  }

  findUserLocation() {
    let infoWindow = new google.maps.InfoWindow();

    // Try HTML5 geolocation.
    if (navigator.geolocation) {
      navigator.geolocation.getCurrentPosition(
        (position: Position) => {
          const pos = {
            lat: position.coords.latitude,
            lng: position.coords.longitude,
          };

          this.gmap = new google.maps.Map(this.element, {
            center: pos,
            zoom: 12,
          });

          // infoWindow.setPosition(pos);
          // infoWindow.setContent("Location found.");
          // infoWindow.open(this.gmap);
          this.gmap.setCenter(pos);
        },
        () => {
          this.gmap = new google.maps.Map(this.element, {
            center: this.defaultCoords,
            zoom: 12,
          });
          this.handleLocationError(
            true,
            this.gmap,
            infoWindow,
            this.gmap.getCenter()
          );
        }
      );
    } else {
      this.gmap = new google.maps.Map(this.element, {
        center: this.defaultCoords,
        zoom: 12,
      });

      // Browser doesn't support Geolocation
      this.handleLocationError(
        false,
        this.gmap,
        infoWindow,
        this.gmap.getCenter()
      );
    }
  }

  private handleLocationError(
    browserHasGeolocation: boolean,
    map: google.maps.Map,
    infoWindow: google.maps.InfoWindow,
    pos: google.maps.LatLng
  ) {
    infoWindow.setPosition(pos);
    infoWindow.setContent(
      browserHasGeolocation
        ? "Access to user location denied."
        : "Error: Your browser doesn't support geolocation."
    );
    infoWindow.open(map);
  }

  searchLocation(query: string) {
    this.isSearching.next(true);

    let mapOptions = {
      center: this.defaultCoords,
      zoom: 12,
    };

    let service = new google.maps.places.PlacesService(this.gmap);
    let infowindow = new google.maps.InfoWindow();

    const request = {
      query,
      fields: ["name", "geometry"],
    };

    let placeGeometry: google.maps.places.PlaceGeometry;

    // This should find multiple places from search
    service.findPlaceFromQuery(request, (results, status) => {
      if (status === google.maps.places.PlacesServiceStatus.OK) {
        this.isSearching.next(false);

        for (let i = 0; i < results.length; i++) {
          let pos = (results[i].geometry as google.maps.places.PlaceGeometry)
            .location;

          if (this.currentMarker) this.currentMarker.setMap(null);

          // Add a marker to each result
          this.currentMarker = new google.maps.Marker({
            map: this.gmap,
            position: pos,
          });

          // Add click listener to marker
          google.maps.event.addListener(this.currentMarker, "click", () => {
            infowindow.setContent(results[i].name);
            infowindow.open(this.gmap);
          });
        }

        placeGeometry = results[0].geometry as google.maps.places.PlaceGeometry;

        // Centre the map to the COM of markers
        this.gmap.setCenter(placeGeometry.location);

        this.coordsSubject.next({
          lat: placeGeometry.location.lat(),
          lng: placeGeometry.location.lng(),
        });
      }
    });
  }
}
