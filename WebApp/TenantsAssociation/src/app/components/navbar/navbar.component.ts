import { Component, OnInit } from '@angular/core';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.scss'],
})
export class NavbarComponent implements OnInit {
  constructor(private userService: UserService) {}
  isLoggedIn() {
    return this.userService.isLoggedIn();
  }
  isAdmin() {
    return this.userService.getUserType();
  }
  logout() {
    this.userService.logout();
  }
  ngOnInit(): void {}
}
