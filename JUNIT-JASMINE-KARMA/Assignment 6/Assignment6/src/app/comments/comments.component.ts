import { Component, OnInit } from '@angular/core';
import { Comments } from '../models/comments';
import { HttpServiceService } from '../shared/http-service.service';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-comments',
  templateUrl: './comments.component.html',
  styleUrls: ['./comments.component.css']
})
export class CommentsComponent implements OnInit {

  constructor(private service : HttpServiceService) { }

  ngOnInit(): void {
  }

  async GetAllComments(){
    return (await this.service.getComments()).subscribe(val => console.log(val));
  }
  
  async GetCommentById(id:number){
    return (await this.service.getComment(id)).subscribe(val => console.log(val));
  }
  async addComment(model:Comments){
    return await this.service.addComments();
  }
  async updateComment(model:Comments){
    return await this.service.updateComment();
  }
  async deleteComment(id:number){
    return (await this.service.deleteComment(id)).subscribe(val => console.log(val));
  }

}
