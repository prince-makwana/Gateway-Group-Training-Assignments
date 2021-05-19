import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Comments } from '../models/comments';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class HttpServiceService {

  constructor(private http: HttpClient) { }

  async getComments(): Promise<Observable<any>>{
    return this.http.get('https://jsonplaceholder.typicode.com/comments');
  }

  async getComment(id:number): Promise<Observable<any>> {
    return this.http.get('https://jsonplaceholder.typicode.com/comments/${id}');
  }

  async addComments(): Promise<Observable<any>> {
   return this.http.post<Comments>('https://jsonplaceholder.typicode.com/comments', {postId:1, id:1, name:"abc", email: 'abc@gmail.com', body:"xyz"});
  }

  async updateComment(): Promise<Observable<any>>{
    return this.http.put<Comments>('https://jsonplaceholder.typicode.com/comments/2', {postId:2, id:2, name:"abc", email: 'abc@gmail.com', body:"xyz"});
  }
  async deleteComment(id:number): Promise<Observable<any>>{
    return this.http.delete<Comments>('https://jsonplaceholder.typicode.com/comments/${id}');
  }
}
