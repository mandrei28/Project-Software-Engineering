import { Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { InvoiceModel } from 'src/app/models/invoice.model';
import { HttpClient } from '@angular/common/http';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-invoices',
  templateUrl: './invoices.component.html',
  styleUrls: ['./invoices.component.scss'],
})
export class InvoicesComponent implements OnInit {
  displayedColumns: string[] = [
    'InvoiceNo',
    'Description',
    'Created',
    'Due',
    'Bill',
  ];
  invoices: InvoiceModel[];

  dataSource = new MatTableDataSource<InvoiceModel>();

  @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;
  constructor(public http: HttpClient, public userService: UserService) {
    this.getInvoices();
  }

  ngOnInit(): void {}

  getInvoices() {
    const userId = this.userService.getUserId();
    this.http
      .get<InvoiceModel[]>('https://localhost:44365/invoice/' + userId)
      .subscribe((response) => {
        console.log(response);
        this.invoices = response;
        this.dataSource = new MatTableDataSource<InvoiceModel>(this.invoices);
        this.dataSource.paginator = this.paginator;
      });
  }
  logout() {
    this.userService.logout();
  }
}
