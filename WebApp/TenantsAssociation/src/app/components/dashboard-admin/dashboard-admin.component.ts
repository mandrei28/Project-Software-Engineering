import { Component, Inject } from '@angular/core';
import { DialogPoolComponent } from './dialog-pool/dialog-pool.component';
import {
  MatDialog,
  MatDialogRef,
  MAT_DIALOG_DATA,
} from '@angular/material/dialog';
import { HttpClient } from '@angular/common/http';
import { MessageModel } from 'src/app/models/invoice.model';

export interface DialogData {
  animal: string;
  name: string;
}

@Component({
  selector: 'app-dashboard-admin',
  templateUrl: './dashboard-admin.component.html',
  styleUrls: ['./dashboard-admin.component.scss'],
})
export class DashboardAdminComponent {
  animal: string;
  name: string;
  message: MessageModel;
  constructor(public dialog: MatDialog, public http: HttpClient) {
    this.getLastMessage();
  }

  openDialog(): void {
    const dialogRef = this.dialog.open(DialogPoolComponent, {
      width: '250px',
      data: { name: this.name, animal: this.animal },
    });

    dialogRef.afterClosed().subscribe((result) => {
      console.log('The dialog was closed');
      this.animal = result;
    });
  }

  getLastMessage() {
    const adminId = '9245FE4A-D402-451C-B9ED-9C1A04247484';
    this.http
      .get<MessageModel>('https://localhost:44365/admin/' + adminId)
      .subscribe((response) => {
        console.log(response);
        this.message = response;
      });
  }
}
