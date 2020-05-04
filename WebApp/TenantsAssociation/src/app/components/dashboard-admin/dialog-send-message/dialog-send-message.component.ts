import { Component, OnInit, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Poll, Invoice, Message } from 'src/app/models/invoice.model';
import { FormControl, Validators } from '@angular/forms';

@Component({
  selector: 'app-dialog-send-message',
  templateUrl: './dialog-send-message.component.html',
  styleUrls: ['./dialog-send-message.component.scss'],
})
export class DialogSendMessageComponent {
  constructor(
    public dialogRef: MatDialogRef<DialogSendMessageComponent>,
    @Inject(MAT_DIALOG_DATA) public data: Message
  ) {
    data.dateCreated = new Date();
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
}
