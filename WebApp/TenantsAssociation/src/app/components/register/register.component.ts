import { Component, OnInit } from '@angular/core';
import {
  FormControl,
  FormGroupDirective,
  NgForm,
  Validators,
} from '@angular/forms';
import { UserModel } from 'src/app/models/user.model';
import { UserService } from 'src/app/services/user.service';
import { MyErrorStateMatcher } from 'src/app/services/error-state.service';
@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss'],
})
export class RegisterComponent implements OnInit {
  value = '';
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
  constructor(public userService: UserService) {}

  getErrorMessage() {
    return this.passwordFormControl.hasError('required')
      ? 'Password cannot be empty'
      : this.passwordFormControl.hasError('minlength')
      ? 'Use 8 or more characters'
      : '';
  }

  ngOnInit() {}
  register() {
    let user: UserModel = {
      Email: this.emailFormControl.value,
      Name: 'Dragos',
      Password: this.passwordFormControl.value,
    };
    this.userService.register(user);
  }
}
