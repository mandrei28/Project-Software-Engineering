import { Injectable } from '@angular/core';
import { UserModel } from '../models/user.model';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { JwtHelperService } from '@auth0/angular-jwt';
import { Router } from '@angular/router';
import { SessionService } from './session.service';
@Injectable({
  providedIn: 'root',
})
export class UserService {
  jwtHelper = new JwtHelperService();

  constructor(
    private http: HttpClient,
    private router: Router,
    private sessionService: SessionService
  ) {}

  register(user: UserModel) {
    return this.http.post('https://localhost:44365/user', user).subscribe(
      (data) => {},
      (error) => {}
    );
  }
  login(currentUser: UserModel) {
    return this.http
      .post<UserModel>(
        'https://localhost:44365/user' + '/authenticate',
        currentUser
      )
      .subscribe(
        (response) => {
          const user = response;
          localStorage.setItem('currentUser', JSON.stringify(user));
          this.router.navigate(['']);
        },
        (error) => {}
      );
  }
  logout() {
    localStorage.removeItem('currentUser');
    sessionStorage.removeItem('currentUser');
    this.router.navigate(['/login']);
  }
  isTokenExpired(): boolean {
    if (localStorage.getItem('currentUser')) {
      const token = JSON.parse(localStorage.getItem('currentUser')).token;
      return this.jwtHelper.isTokenExpired(token);
    }
    return true;
  }
  getUserId() {
    if (localStorage.getItem('currentUser')) {
      var token = localStorage.getItem('currentUser');
      var tokenInfo = this.jwtHelper.decodeToken(token);
      return tokenInfo.nameid;
    }
  }
  getUserType() {
    if (localStorage.getItem('currentUser')) {
      var token = localStorage.getItem('currentUser');
      var tokenInfo = this.jwtHelper.decodeToken(token);
      if (tokenInfo.role === 'admin') return true;
      else return false;
    }
  }
  isLoggedIn() {
    if (localStorage.getItem('currentUser')) return true;
    return false;
  }
  sendMessage(message: string) {
    return this.http
      .post(
        'https://localhost:44365/user/message/' + this.getUserId(),
        JSON.stringify(message),
        this.sessionService.requestOptions
      )
      .subscribe(
        (response) => {},
        (error) => {}
      );
  }
}
