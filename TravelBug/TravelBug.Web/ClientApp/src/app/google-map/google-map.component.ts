import { AfterViewInit, Component, ElementRef, OnInit, ViewChild } from '@angular/core';

@Component({
  selector: 'app-google-map',
  templateUrl: './google-map.component.html',
  styleUrls: ['./google-map.component.css']
})
export class GoogleMapComponent implements OnInit, AfterViewInit {

  constructor() { }

  ngOnInit() {
  }



  @ViewChild("mapContainer", { static: false }) gmap: ElementRef;

  ngAfterViewInit() {
    this.mapInitializer();
  }

  mapInitializer() {
    let lat = 40.73061;
    let lng = -73.935242;
    let coordinates = new google.maps.LatLng(lat, lng);

    // Set map location
    let mapOptions: google.maps.MapOptions = {
      center: coordinates,
      zoom: 13,
    };

    // Set marker location
    let marker = new google.maps.Marker({
      position: coordinates,
    });

    // Assign map to HTML element
    let map = new google.maps.Map(this.gmap.nativeElement, mapOptions);
    marker.setMap(map);
  }

}
