import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import {  catchError, Subject, tap } from 'rxjs';
import { AlertifyService } from '../../../shared/services/alertify-service/alertify.service';
import { LoginModel } from '../models/login-model';
import { RegisterModel } from '../models/register-model';
import { UserModel } from '../models/user.model';

@Injectable({
  providedIn: 'root',
})
export class AccountService {
  constructor(private http: HttpClient,private alertify:AlertifyService) {
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
        this.alertify.success("Autentificare realizata cu succes");

        this.loggedInUser.next(true);
        success = true;
      });
    return success;
  }

  register(dto: RegisterModel) {
    return this.http.post(this.userersAPI + 'register', dto).pipe(
      tap(() => this.alertify.success("Te-ai inregistrat cu succes!")),
      catchError(async () => this.alertify.error("Eroare la inregistrare!"))
    );
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
