import { Injectable } from '@angular/core';
import {
  Router,
  CanActivate,
  ActivatedRouteSnapshot,
  RouterStateSnapshot,
} from '@angular/router';
import { UserService } from './user.service';

@Injectable()
export class AuthGuard implements CanActivate {
  constructor(private router: Router, private userService: UserService) {}

  canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot) {
    if (this.userService.isTokenExpired() === true) {
      localStorage.removeItem('currentUser');
    }

    if (
      localStorage.getItem('currentUser') ||
      sessionStorage.getItem('currentUser')
    ) {
      return true;
    }

    this.router.navigate(['/login']);
    return false;
  }
}
