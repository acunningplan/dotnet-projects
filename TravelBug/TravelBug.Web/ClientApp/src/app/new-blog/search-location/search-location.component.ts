import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { PlacesApiResponse } from 'src/app/models/places';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-search-location',
  templateUrl: './search-location.component.html',
  styleUrls: ['./search-location.component.css']
})
export class SearchLocationComponent implements OnInit {
  isSearching = false;
  locationText = "Coffee";
  proxyUrl = "https://cors-anywhere.herokuapp.com/"

  coords: {
    lat: number,
    lng: number
  }

  constructor(private http: HttpClient) { }

  ngOnInit() {

    // let headers = new Headers();
    // headers.append('Content-Type', 'application/json');
    
    // let options = new RequestOpt({ headers: headers });
    

    // let proxyUrl = "https://cors-anywhere.herokuapp.com/"
  }

  types = ["locality", 'political']

  searchLocation() {
    this.isSearching = true;
    let requestUrl = `https://maps.googleapis.com/maps/api/place/findplacefromtext/json?input=${this.locationText}&inputtype=textquery&fields=formatted_address,name,geometry,types&key=${environment.agmApiKey}`
    this.http
      .get<PlacesApiResponse>(requestUrl)
      .subscribe(res => {
        this.isSearching = false;
        if (res.candidates.length > 0) {
          let place = res.candidates[0];
          console.log(place)
          this.coords = place.geometry.location;
        } else {
          console.log("Can't find anything.")
        }
      });
  }

}
