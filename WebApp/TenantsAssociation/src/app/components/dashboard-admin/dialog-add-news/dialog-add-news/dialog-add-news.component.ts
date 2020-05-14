import { Component, OnInit, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { NewsModel } from 'src/app/models/invoice.model';
import { FormControl, Validators } from '@angular/forms';
@Component({
  selector: 'app-dialog-add-news',
  templateUrl: './dialog-add-news.component.html',
  styleUrls: ['./dialog-add-news.component.scss'],
})
export class DialogAddNewsComponent {
  constructor(
    public dialogRef: MatDialogRef<DialogAddNewsComponent>,
    @Inject(MAT_DIALOG_DATA) public data: NewsModel
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
}
