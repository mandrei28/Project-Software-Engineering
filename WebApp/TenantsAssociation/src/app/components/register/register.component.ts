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
  hide = true;
  matcher = new MyErrorStateMatcher();
  mailPattern = new RegExp(
    '^([a-zA-Z0-9_.-]+)@([a-zA-Z0-9_.-]+)\\.([a-zA-Z]{2,5})'
  );
  passPattern = new RegExp(
    '^(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.*[?<>{}$!\\._-]).{6,}'
  );
  emailFormControl = new FormControl('', [
    Validators.required,
    Validators.pattern(this.mailPattern),
  ]);
  passwordFormControl = new FormControl('', [
    Validators.required,
    Validators.pattern(this.passPattern),
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
