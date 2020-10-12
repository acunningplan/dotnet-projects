export class PlacesApiResponse {
  candidates: Place[];
  status: string;
}

class Place {
  geometry: {
    location: {
      lat: number;
      lng: number;
    }
  }
  name: string;
  types: string[]
}