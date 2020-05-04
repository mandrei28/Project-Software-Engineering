import { Injectable } from '@angular/core';
import { HttpHeaders } from '@angular/common/http';

@Injectable({
  providedIn: 'root',
})
export class SessionService {
  private header = {
    'Content-Type': 'application/json',
    Accept: 'application/json',
    'Access-Control-Allow-Headers': 'Content-Type',
  };
  public requestOptions = {
    headers: new HttpHeaders(this.header).append(
      'Authorization',
      'Bearer ' + JSON.parse(localStorage.getItem('currentUser')).token
    ),
  };
  constructor() {}
}
