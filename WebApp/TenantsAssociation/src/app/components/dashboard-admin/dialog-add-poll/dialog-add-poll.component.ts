import { Component, OnInit, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Poll } from 'src/app/models/invoice.model';
import { FormControl, Validators } from '@angular/forms';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-dialog-add-poll',
  templateUrl: './dialog-add-poll.component.html',
  styleUrls: ['./dialog-add-poll.component.scss'],
})
export class DialogAddPollComponent {
  constructor(
    public http: HttpClient,
    public dialogRef: MatDialogRef<DialogAddPollComponent>,
    @Inject(MAT_DIALOG_DATA) public data: Poll
  ) {}
  onNoClick(): void {
    this.dialogRef.close();
  }

  questionValidator = new FormControl('', Validators.required);

  getErrorMessage() {
    return 'Not Valid';
  }

  isDisabled() {
    return this.questionValidator.invalid;
  }

  createPoll() {
    this.http
      .post<Poll>('https://localhost:44365/admin/createPoll', this.data)
      .subscribe((response) => {
        console.log(response);
      });
  }
}
