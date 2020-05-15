import { Component, OnInit, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Poll, Invoice, Message } from 'src/app/models/invoice.model';
import { FormControl, Validators } from '@angular/forms';
import { HttpClient } from '@angular/common/http';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-dialog-send-message',
  templateUrl: './dialog-send-message.component.html',
  styleUrls: ['./dialog-send-message.component.scss'],
})
export class DialogSendMessageComponent {
  dateCreated: String;
  constructor(
    private userService: UserService,
    public http: HttpClient,
    public dialogRef: MatDialogRef<DialogSendMessageComponent>,
    @Inject(MAT_DIALOG_DATA) public data: Message
  ) {
    this.dateCreated = this.dateFormated(new Date());
  }
  onNoClick(): void {
    this.dialogRef.close();
  }

  validator = new FormControl('', Validators.required);

  getErrorMessage() {
    return 'Not Valid';
  }

  isDisabled() {
    return this.validator.invalid;
  }

  sendMessage() {
    this.data.administratorId = this.userService.getUserId();
    this.http
      .post<Message>('https://localhost:44365/Admin/sendMessage', this.data)
      .subscribe((response) => {
        console.log(response);
      });
  }

  dateFormated(date): String {
    var newDate =
      date.getFullYear() +
      '/' +
      (date.getMonth() + 1) +
      '/' +
      date.getDate() +
      ' ' +
      date.getHours() +
      ':' +
      date.getMinutes();

    return newDate;
  }
}
