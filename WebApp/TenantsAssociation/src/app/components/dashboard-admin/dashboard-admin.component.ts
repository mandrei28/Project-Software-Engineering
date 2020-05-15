import { Component, Inject, OnInit } from '@angular/core';
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
  Message,
} from 'src/app/models/invoice.model';
import { DialogAddPollComponent } from './dialog-add-poll/dialog-add-poll.component';
import { DialogAddInvoiceComponent } from './dialog-add-invoice/dialog-add-invoice.component';
import { DialogSendMessageComponent } from './dialog-send-message/dialog-send-message.component';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-dashboard-admin',
  templateUrl: './dashboard-admin.component.html',
  styleUrls: ['./dashboard-admin.component.scss'],
})
export class DashboardAdminComponent implements OnInit {
  message: Message;
  user: User;
  poll: Poll;
  invoice: Invoice;
  messageToSend: Message;
  dateCreated: String;
  constructor(
    private userService: UserService,
    public dialog: MatDialog,
    public http: HttpClient
  ) {}
  ngOnInit(): void {
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
    const adminId = this.userService.getUserId();
    this.http
      .get<Message>('https://localhost:44365/admin/' + adminId)
      .subscribe((response) => {
        console.log(response);
        this.message = response;
        this.dateCreated = this.dateFormated(this.message.dateCreated);
      });
  }

  postInvoice() {
    this.http
      .post<Invoice>('https://localhost:44365/admin/addInvoice', this.invoice)
      .subscribe((response) => {
        console.log(response);
      });
  }

  dateFormated(createdDate): String {
    var date = new Date(createdDate);
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
