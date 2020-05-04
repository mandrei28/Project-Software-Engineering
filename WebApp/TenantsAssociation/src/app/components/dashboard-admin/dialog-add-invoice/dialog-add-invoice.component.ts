import { Component, OnInit, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Poll, Invoice } from 'src/app/models/invoice.model';
import { FormControl, Validators } from '@angular/forms';

@Component({
  selector: 'app-dialog-add-invoice',
  templateUrl: './dialog-add-invoice.component.html',
  styleUrls: ['./dialog-add-invoice.component.scss'],
})
export class DialogAddInvoiceComponent {
  constructor(
    public dialogRef: MatDialogRef<DialogAddInvoiceComponent>,
    @Inject(MAT_DIALOG_DATA) public data: Invoice
  ) {}
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
