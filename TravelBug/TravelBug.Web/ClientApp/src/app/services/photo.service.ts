import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { environment } from "src/environments/environment";
import { Photo } from "../models/image";
import { ImageUploadResponse } from "../new-blog/image-upload-response";

@Injectable({
  providedIn: "root",
})
export class PhotoService {
  constructor(private httpClient: HttpClient) {}

  uploadProfilePicture(fd: FormData) {
    this.httpClient
      .patch(`${environment.apiUrl}/profile/photo`, fd)
      .subscribe((res) => console.log(res));
  }

  uploadImages(blogId: string, fd: FormData) {
    this.httpClient
      .post<ImageUploadResponse[]>(`${environment.apiUrl}/photo/${blogId}`, fd)
      .subscribe((res) => console.log(res));
  }

  deleteImages(blogId: string, imageUrls: string[]) {
    const options = {
      headers: new HttpHeaders({
        "Content-Type": "application/json",
      }),
      body: {
        urls: imageUrls,
      },
    };

    this.httpClient
      .delete<ImageUploadResponse[]>(
        `${environment.apiUrl}/photo/${blogId}`,
        options
      )
      .subscribe((res) => console.log(res));
  }
}
