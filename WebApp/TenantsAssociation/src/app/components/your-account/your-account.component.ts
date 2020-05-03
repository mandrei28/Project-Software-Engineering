import { Component, OnInit } from '@angular/core';
import { FormControl, Validators } from '@angular/forms';
import { YourAccountService } from 'src/app/services/your-account.service';
import {
  YourAccountNameModel,
  YourAccountPasswordModel,
  YourAccountEmailModel,
} from 'src/app/models/your-account.model';

@Component({
  selector: 'app-your-account',
  templateUrl: './your-account.component.html',
  styleUrls: ['./your-account.component.scss'],
})
export class YourAccountComponent implements OnInit {
  constructor(private yourAccountService: YourAccountService) {}
  nameFormControl = new FormControl('', [Validators.required]);
  emailFormControl = new FormControl('', [
    Validators.required,
    Validators.email,
  ]);
  passwordFormControl = new FormControl('', [
    Validators.required,
    Validators.minLength(8),
  ]);
  currentPasswordFormControl = new FormControl('', [
    Validators.required,
    Validators.minLength(8),
  ]);

  ngOnInit(): void {}
  step = 0;

  setStep(index: number) {
    this.step = index;
    console.log(this.passwordFormControl.errors);
  }
  newName() {
    let name: YourAccountNameModel = {
      name: this.nameFormControl.value,
    };
    this.yourAccountService.newName(name);
  }
  newPassword() {
    let password: YourAccountPasswordModel = {
      currentPassword: this.currentPasswordFormControl.value,
      newPassword: this.passwordFormControl.value,
    };
    this.yourAccountService.newPassword(password);
  }
  newEmail() {
    let email: YourAccountEmailModel = {
      email: this.emailFormControl.value,
    };
    this.yourAccountService.newEmail(email);
  }
}
