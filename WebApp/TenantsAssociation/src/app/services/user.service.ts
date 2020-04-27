import { Injectable } from '@angular/core';
import { UserModel } from '../models/user.model';
import { HttpClient } from '@angular/common/http';
import { JwtHelperService } from '@auth0/angular-jwt';
import { Router } from '@angular/router';
@Injectable({
  providedIn: 'root',
})
export class UserService {
  jwtHelper = new JwtHelperService();
  constructor(private http: HttpClient, private router: Router) {}

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
    var token = localStorage.getItem('currentUser');
    var tokenInfo = this.jwtHelper.decodeToken(token);
    return tokenInfo.nameid;
  }
}
