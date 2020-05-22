import { Component, OnInit, ViewChild } from '@angular/core';
import { User, UserView } from 'src/app/models/invoice.model';
import { HttpClient } from '@angular/common/http';
import { MatPaginator } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';

export interface PeriodicElement {
  name: string;
  position: number;
  weight: number;
  symbol: string;
}
@Component({
  selector: 'app-services',
  templateUrl: './services.component.html',
  styleUrls: ['./services.component.scss'],
})
export class ServicesComponent implements OnInit {
  displayedColumns: string[] = ['no', 'name', 'email', 'apartmentNo', 'edit'];
  users: UserView[];
  dataSource = new MatTableDataSource<UserView>();

  @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;
  constructor(public http: HttpClient) {}

  ngOnInit(): void {
    this.getAllUsers();
  }

  getAllUsers() {
    this.http
      .get<UserView[]>('https://localhost:44365/admin/getAllUsers')
      .subscribe((response) => {
        console.log(response);
        this.users = response;
        this.dataSource = new MatTableDataSource<UserView>(this.users);
        this.dataSource.paginator = this.paginator;
      });
  }
}