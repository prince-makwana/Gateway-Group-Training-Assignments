import { TestBed } from '@angular/core/testing';

import { AuthService } from './auth.service';

describe('AuthService', () => {
  let service: AuthService;
  let spy: any;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(AuthService);
  });

  afterEach(() => {
    service = null;
    localStorage.removeItem('token');
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });

  it('should return true from isAuthenticated when there is a token', () => {
    localStorage.setItem('token', '1234');
    expect(service.isAuthenticated()).toBeTruthy();
  });

  it('should return false from isAuthenticated when there is no token', () => {
    expect(service.isAuthenticated()).toBeFalsy();
  });

  it('should return true if email is valid', () => {
    spy = spyOn(service, 'emailValidation').and.returnValue(true);
    expect(service.emailValidation("princemakwana29@gmail.com")).toBeTruthy();
  });

  it('should return false if email is invalid', () => {
    spy = spyOn(service, 'emailValidation').and.returnValue(true);
    expect(service.emailValidation("prince")).toBeFalsy();
  });

  it('should return true if password is valid',()=>{
    spy = spyOn(service,'passwordValidation').and.returnValue(true);
    expect(service.passwordValidation("Password")).toBeTruthy();  
  });

  it('should return false if password is invalid',()=>{
    spy = spyOn(service,'passwordValidation').and.returnValue(true);
    expect(service.passwordValidation("Prince")).toBeFalsy();    
  });

});
