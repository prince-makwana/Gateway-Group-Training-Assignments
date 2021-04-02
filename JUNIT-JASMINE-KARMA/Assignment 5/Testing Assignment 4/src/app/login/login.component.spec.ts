import { ComponentFixture, TestBed } from '@angular/core/testing';
import { AuthService } from '../auth.service';

import { LoginComponent } from './login.component';

describe('LoginComponent', () => {
  let component: LoginComponent;
  let service: AuthService;
  let fixture: ComponentFixture<LoginComponent>;
  let spy: any;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [LoginComponent]
    })
      .compileComponents();
    service = new AuthService();
    component = new LoginComponent(service);
  });

  afterEach(() => {
    service = null;
    component = null;
  });


  it('should create', () => {
    expect(component).toBeTruthy();
  });

  it('needsLogin returns true when the user has not been authenticated', () => {
    spy = spyOn(service, 'isAuthenticated').and.returnValue(false);
    expect(component.needsLogin()).toBeTruthy();
    expect(service.isAuthenticated).toHaveBeenCalled();

  });

  it('needsLogin returns false when the user has been authenticated', () => {
    spy = spyOn(service, 'isAuthenticated').and.returnValue(true);
    expect(component.needsLogin()).toBeFalsy();
    expect(service.isAuthenticated).toHaveBeenCalled();
  });

  it('should return true if email is valid',()=>{
    spy = spyOn(service,'emailValidation').and.returnValue(true);
    expect(component.validateEmail("princemakwana29@gmail.com")).toBeTruthy();
    expect(service.emailValidation).toHaveBeenCalled();    
  });

  it('should return false if email is invalid',()=>{
    spy = spyOn(service,'emailValidation').and.returnValue(true);
    expect(component.validateEmail("prince")).toBeFalsy();
    expect(service.emailValidation).toHaveBeenCalled();    
  });

  it('should return true if password is valid',()=>{
    spy = spyOn(service,'passwordValidation').and.returnValue(true);
    expect(component.validatePassword("Password")).toBeTruthy();
    expect(service.passwordValidation).toHaveBeenCalled();    
  });

  it('should return false if password is invalid',()=>{
    spy = spyOn(service,'passwordValidation').and.returnValue(true);
    expect(component.validatePassword("Prince")).toBeFalsy();
    expect(service.passwordValidation).toHaveBeenCalled();    
  });
});
