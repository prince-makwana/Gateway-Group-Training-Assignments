import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  isAuthenticated(): boolean {
    return !!localStorage.getItem('token');
  }

  emailValidation(email: any): boolean {
    const re = /^[a-z0-9._%+-]+@[a-z0-9.-]+\\.[a-z]{2,4}$/;
    return re.test(String(email).toLowerCase());
  }

  passwordValidation(password: any): boolean {
    const re = /^(?=.*[0-9])(?=.*[a-z])(?=.*[A-Z])(?=.*[@#$%^&-+=()])(?=\\S+$).{8, 20}$/;
    return re.test(String(password));
  }

  constructor() { }
}
