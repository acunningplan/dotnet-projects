import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { environment } from "src/environments/environment";
import { Image } from "../models/image";
import { ImageUploadResponse } from "../new-blog/image-upload-response";

@Injectable({
  providedIn: "root",
})
export class PhotoService {
  constructor(private httpClient: HttpClient) {}

  // uploadImages(images: Image[]) {
  //   this.httpClient.post(`${environment.apiUrl}/photo/`, images)
  // }
  uploadImages(blogId: string, fd: FormData): Observable<ImageUploadResponse> {
    return this.httpClient.post<ImageUploadResponse>(
      `${environment.apiUrl}/photo/${blogId}`,
      fd
    );
  }
}
