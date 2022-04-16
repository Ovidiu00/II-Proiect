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
  constructor(private http: HttpClient) {}

  private apiBaseURL = 'https://localhost:44350';
  private userersAPI = this.apiBaseURL + '/users/';

  private loggedInUser:Subject<UserModel> = new Subject<UserModel>();

  login(dto: LoginModel): boolean {
    let success: boolean = false;
    this.http
      .post<any>(this.userersAPI + 'authenticate', dto)
      .subscribe((x) => {
        localStorage.setItem('token', x.token);
        this.loggedInUser.next(new UserModel());
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

  getLoggedInUser(){
    return this.loggedInUser.asObservable();
  }
}
