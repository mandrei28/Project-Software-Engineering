import { Component, OnInit } from '@angular/core';
import { MyErrorStateMatcher } from 'src/app/services/error-state.service';
import { Validators, FormControl } from '@angular/forms';
import { UserService } from 'src/app/services/user.service';
import { UserModel } from 'src/app/models/user.model';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss'],
})
export class LoginComponent {
  hide = true;
  matcher = new MyErrorStateMatcher();

  emailFormControl = new FormControl('', [
    Validators.required,
    Validators.email,
  ]);

  passwordFormControl = new FormControl('', [
    Validators.required,
    Validators.minLength(8),
  ]);

  constructor(private userService: UserService) {}

  getErrorMessage() {
    return this.passwordFormControl.hasError('required')
      ? 'Password is required'
      : this.passwordFormControl.hasError('minlength')
      ? 'Password must be at least 8 charahcters'
      : '';
  }

  login() {
    let user: UserModel = {
      Email: this.emailFormControl.value,
      Name: '',
      Password: this.passwordFormControl.value,
    };
    this.userService.login(user);
  }
}
