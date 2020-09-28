import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Image } from '../models/image';

@Injectable({
  providedIn: 'root'
})
export class PhotoService {

  constructor(private httpClient: HttpClient) {}

  uploadImages(images: Image[]) {
    this.httpClient.post(`${environment.apiUrl}/photo/`, images)
  }

}
