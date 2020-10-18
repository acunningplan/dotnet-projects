import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Subject } from 'rxjs';
import { environment } from 'src/environments/environment';
import { BlogComment } from '../models/comment';

@Injectable({
  providedIn: 'root'
})
export class CommentService {

  commentChange = new Subject<BlogComment>();

  constructor(private http: HttpClient) { 
  }

  postComment(description: string, blogId: string) {
    let comment = new BlogComment();
    comment.description = description;
    return this.http.post<BlogComment>(`${environment.apiUrl}/comment/${blogId}`, comment);
  }

  patchComment(commentId: string, comment: BlogComment) {
    let keysToChange = ["description"]
    return this.http.patch(`${environment.apiUrl}/comment/${commentId}`,
      keysToChange.map((k) => ({
        op: "replace",
        path: k,
        value: comment[k]
      }))
    )
  }

  deleteComment(blogId: string, commentId: string) {
    return this.http.delete(`${environment.apiUrl}/comment/${blogId}/${commentId}`);
  }
}
