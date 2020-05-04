import { Component, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { User, Invoice } from 'src/app/models/invoice.model';
import { FormControl, Validators } from '@angular/forms';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-dialog-pool',
  templateUrl: './dialog-pool.component.html',
  styleUrls: ['./dialog-pool.component.scss'],
})
export class DialogPoolComponent {
  constructor(
    public http: HttpClient,
    public dialogRef: MatDialogRef<DialogPoolComponent>,
    @Inject(MAT_DIALOG_DATA) public data: User
  ) {}
  hide: boolean = true;
  onNoClick(): void {
    this.dialogRef.close();
  }

  mailPattern = new RegExp(
    '^([a-zA-Z0-9_.-]+)@([a-zA-Z0-9_.-]+)\\.([a-zA-Z]{2,5})'
  );
  passPattern = new RegExp(
    '^(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.*[?<>{}$!\\._-]).{6,}'
  );
  emailValidator = new FormControl('', [
    Validators.required,
    Validators.pattern(this.mailPattern),
  ]);
  passwordValidator = new FormControl('', [
    Validators.required,
    Validators.pattern(this.passPattern),
  ]);
  nameValidator = new FormControl('', Validators.required);

  getErrorMessage() {
    return 'Not Valid';
  }

  isDisabled() {
    var val =
      this.emailValidator.invalid ||
      this.passwordValidator.invalid ||
      this.nameValidator.invalid;
    return val;
  }
  createUser() {
    this.http
      .post<User>('https://localhost:44365/Admin/createUser', this.data)
      .subscribe((response) => {
        console.log(response);
      });
  }
}
