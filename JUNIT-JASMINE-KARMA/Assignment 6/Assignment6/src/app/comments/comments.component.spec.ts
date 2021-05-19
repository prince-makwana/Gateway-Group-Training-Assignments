import { ComponentFixture, TestBed } from '@angular/core/testing';
import { HttpServiceService } from '../shared/http-service.service';
import { HttpClientTestingModule } from '@angular/common/http/testing';
import { CommentsComponent } from './comments.component';

describe('CommentsComponent', () => {
  let component: CommentsComponent;
  let service: HttpServiceService;

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [
        HttpClientTestingModule
      ]
    });
    service = TestBed.inject(HttpServiceService);
    component = new CommentsComponent(service);
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  it('should call GetAllComments()', (done) => {
    component.GetAllComments().then((data) => {
      expect(data).toBeTruthy();
      done();
    });
  });

  it('should call GetCommentById()', (done) => {
    component.GetCommentById(3).then((data) => {
      expect(data).toBeTruthy();
      done();
    });
  });

  it('should call addComment()', (done) => {
    component.addComment({postId:2, id:2, name:"abc", email: 'abc@gmail.com', body:"xyz"}).then((data) => {
      expect(data).toBeTruthy();
      done();
    });
  });

  it('should call updateComment()', (done) => {
    component.updateComment({postId:3, id:1, name:"abc", email: 'abc@gmail.com', body:"xyz"}).then((data) => {
      expect(data).toBeTruthy();
      done();
    });
  });

  it('should call deleteComment()', (done) => {
    component.deleteComment(5).then((data) => {
      expect(data).toBeTruthy();
      done();
    });
  });

});
