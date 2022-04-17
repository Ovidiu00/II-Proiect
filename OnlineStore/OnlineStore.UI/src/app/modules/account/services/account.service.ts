import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import {  Subject } from 'rxjs';
import { LoginModel } from '../models/login-model';
import { RegisterModel } from '../models/register-model';
import { UserModel } from '../models/user.model';

@Injectable({
  providedIn: 'root',
})
export class AccountService {
  constructor(private http: HttpClient) {
    this.loggedInUser.next(true);
  }

  private apiBaseURL = 'https://localhost:44350';
  private userersAPI = this.apiBaseURL + '/users/';

  private loggedInUser:Subject<boolean> = new Subject<boolean>();

  public isLoggedIn$ = this.loggedInUser.asObservable();

  login(dto: LoginModel): boolean {
    let success: boolean = false;
    this.http
      .post<any>(this.userersAPI + 'authenticate', dto)
      .subscribe((x) => {
        sessionStorage.setItem('token', x.token);
        sessionStorage.setItem('user',JSON.stringify(x.user));

        this.loggedInUser.next(true);
        success = true;
      });
    return success;
  }

  register(dto: RegisterModel) {
    return this.http.post(this.userersAPI + 'register', dto);
  }
  getToken(){
    return localStorage.getItem('token');
  }

  getLoggedInUser():UserModel{
    return JSON.parse(sessionStorage.getItem('user'));
  }
  logout(){
    sessionStorage.removeItem('token');
    sessionStorage.removeItem('user');

    this.loggedInUser.next(false);
  }
}
