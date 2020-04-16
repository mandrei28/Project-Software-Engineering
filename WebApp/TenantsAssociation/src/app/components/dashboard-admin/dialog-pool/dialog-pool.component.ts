import { Component, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { DialogData } from '../dashboard-admin.component';

@Component({
  selector: 'app-dialog-pool',
  templateUrl: './dialog-pool.component.html',
  styleUrls: ['./dialog-pool.component.scss']
})
export class DialogPoolComponent {
  constructor(
    public dialogRef: MatDialogRef<DialogPoolComponent>,
    @Inject(MAT_DIALOG_DATA) public data: DialogData
  ) {}

  onNoClick(): void {
    this.dialogRef.close();
  }
}
