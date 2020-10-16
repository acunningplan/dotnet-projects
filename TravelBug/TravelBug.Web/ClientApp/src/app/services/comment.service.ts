import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { BlogComment } from '../models/comment';

@Injectable({
  providedIn: 'root'
})
export class CommentService {

  constructor(private http: HttpClient) { 
  }

  postComment(description: string, blogId: string) {
    let comment = new BlogComment();
    comment.description = description;
    return this.http.post(`${environment.apiUrl}/comment/${blogId}`, comment);
  }
}
