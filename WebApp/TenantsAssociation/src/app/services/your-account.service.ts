import { Injectable } from '@angular/core';
import {
  YourAccountNameModel,
  YourAccountEmailModel,
  YourAccountPasswordModel,
} from '../models/your-account.model';
import { HttpClient } from '@angular/common/http';
import { UserService } from './user.service';
import { SessionService } from './session.service';

@Injectable({
  providedIn: 'root',
})
export class YourAccountService {
  userId: string;
  constructor(
    private http: HttpClient,
    private userService: UserService,
    private sessionService: SessionService
  ) {
    this.userId = this.userService.getUserId();
  }

  newName(newName: YourAccountNameModel) {
    return this.http
      .post<YourAccountNameModel>(
        'https://localhost:44365/user/name/' + this.userId,
        newName,
        this.sessionService.requestOptions
      )
      .subscribe(
        (response) => {},
        (error) => {}
      );
  }
  newEmail(newEmail: YourAccountEmailModel) {
    return this.http
      .post<YourAccountNameModel>(
        'https://localhost:44365/user/email/' + this.userId,
        newEmail,
        this.sessionService.requestOptions
      )
      .subscribe(
        (response) => {},
        (error) => {}
      );
  }
  newPassword(newPassword: YourAccountPasswordModel) {
    return this.http
      .post<YourAccountNameModel>(
        'https://localhost:44365/user/password/' + this.userId,
        newPassword,
        this.sessionService.requestOptions
      )
      .subscribe(
        (response) => {},
        (error) => {}
      );
  }
  sendMessage(message: string) {
    return this.http
      .post(
        'https://localhost:44365/user/message/' + this.userService.getUserId(),
        JSON.stringify(message),
        this.sessionService.requestOptions
      )
      .subscribe(
        (response) => {},
        (error) => {}
      );
  }
}
