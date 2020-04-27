import { Injectable } from '@angular/core';
import { UserModel } from '../models/register.model';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root',
})
export class UserService {
  constructor(private http: HttpClient) {}

  register(user: UserModel) {
    return this.http.post('https://localhost:44365/user', user).subscribe(
      (data) => {},
      (error) => {}
    );
  }
}
