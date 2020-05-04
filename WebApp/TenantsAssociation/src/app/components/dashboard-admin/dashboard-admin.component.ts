import { Component, Inject } from '@angular/core';
import { DialogPoolComponent } from './dialog-user/dialog-pool.component';
import {
  MatDialog,
  MatDialogRef,
  MAT_DIALOG_DATA,
} from '@angular/material/dialog';
import { HttpClient } from '@angular/common/http';
import {
  MessageModel,
  User,
  Poll,
  Invoice,
} from 'src/app/models/invoice.model';
import { DialogAddPollComponent } from './dialog-add-poll/dialog-add-poll.component';
import { DialogAddInvoiceComponent } from './dialog-add-invoice/dialog-add-invoice.component';
import { DialogSendMessageComponent } from './dialog-send-message/dialog-send-message.component';
import { Message } from '@angular/compiler/src/i18n/i18n_ast';

@Component({
  selector: 'app-dashboard-admin',
  templateUrl: './dashboard-admin.component.html',
  styleUrls: ['./dashboard-admin.component.scss'],
})
export class DashboardAdminComponent {
  message: MessageModel;
  user: User;
  poll: Poll;
  invoice: Invoice;
  messageToSend: Message;
  constructor(public dialog: MatDialog, public http: HttpClient) {
    this.getLastMessage();
  }

  openAddUserDialog(): void {
    const dialogRef = this.dialog.open(DialogPoolComponent, {
      width: '20em',
      data: { name: ' ', email: '', password: '' },
    });

    dialogRef.afterClosed().subscribe((result) => {
      console.log('The dialog was closed');
      this.user = result;
    });
  }

  openAddPoolDialog(): void {
    const dialogRef = this.dialog.open(DialogAddPollComponent, {
      width: '20em',
      data: { question: '' },
    });

    dialogRef.afterClosed().subscribe((result) => {
      console.log('The dialog was closed');
      this.poll = result;
    });
  }
  openAddInvoiceDialog(): void {
    const dialogRef = this.dialog.open(DialogAddInvoiceComponent, {
      width: '20em',
      data: {
        email: '',
        invoiceNumber: '',
        bill: '',
        description: '',
        createDate: '',
        dueDate: '',
        payDate: '',
      },
    });

    dialogRef.afterClosed().subscribe((result) => {
      console.log('The dialog was closed');
      this.invoice = result;
    });
  }

  openSendMessageDialog(): void {
    const dialogRef = this.dialog.open(DialogSendMessageComponent, {
      width: '20em',
      data: { email: '', dateCreated: '', text: '' },
    });

    dialogRef.afterClosed().subscribe((result) => {
      console.log('The dialog was closed');
      this.messageToSend = result;
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

  createPoll() {
    const adminId = '9245FE4A-D402-451C-B9ED-9C1A04247484';
    this.http
      .post<Invoice>('https://localhost:44365/admin/createPoll', this.poll)
      .subscribe((response) => {
        console.log(response);
      });
  }

  postInvoice() {
    this.http
      .post<Invoice>('https://localhost:44365/admin/addInvoice', this.invoice)
      .subscribe((response) => {
        console.log(response);
      });
  }
}
