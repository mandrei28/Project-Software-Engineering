import { Component, OnInit } from '@angular/core';
import {
  FormControl,
  FormGroupDirective,
  NgForm,
  Validators,
} from '@angular/forms';
import { ErrorStateMatcher } from '@angular/material/core';
import { UserModel } from 'src/app/models/register.model';
import { UserService } from 'src/app/services/user.service';
export class MyErrorStateMatcher implements ErrorStateMatcher {
  isErrorState(
    control: FormControl | null,
    form: FormGroupDirective | NgForm | null
  ): boolean {
    const isSubmitted = form && form.submitted;
    return !!(
      control &&
      control.invalid &&
      (control.dirty || control.touched || isSubmitted)
    );
  }
}
@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss'],
})
export class RegisterComponent implements OnInit {
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
