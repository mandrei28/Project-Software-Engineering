import { Component, OnInit, ViewChild } from '@angular/core';
import { ChartType, ChartOptions } from 'chart.js';
import {
  SingleDataSet,
  Label,
  monkeyPatchChartJsLegend,
  monkeyPatchChartJsTooltip,
} from 'ng2-charts';
import { HttpClient } from '@angular/common/http';
import { UserService } from 'src/app/services/user.service';
import { SessionService } from 'src/app/services/session.service';
import { InvoiceModel } from 'src/app/models/invoice.model';
import { DatePipe } from '@angular/common';
import { DueDate } from 'src/app/models/duedate.model';
import { MatTableDataSource } from '@angular/material/table';

@Component({
  selector: 'app-dashboard-user',
  templateUrl: './dashboard-user.component.html',
  styleUrls: ['./dashboard-user.component.scss'],
})
export class DashboardUserComponent implements OnInit {
  displayedColumns: string[] = ['InvoiceNo', 'Description'];

  dataSource = new MatTableDataSource<InvoiceModel>();

  //radio-button
  a = 2;
  favoriteChoice: string;
  choice: string[] = ['9:00', '10:00', '11:00'];

  // Pie
  public pieChartOptions: ChartOptions = {
    responsive: true,
    maintainAspectRatio: false,
    legend: { position: 'top' },
  };

  public pieChartLabels: Label[] = [['9:00'], ['10:00'], '11:00'];

  public pieChartData: SingleDataSet = [3, 5, this.a];
  public pieChartType: ChartType = 'pie';
  public pieChartLegend = true;
  public pieChartPlugins = [];
  invoices: InvoiceModel[];

  today_date: string;

  constructor(
    public http: HttpClient,
    public userService: UserService,
    public sessionService: SessionService,
    private datePipe: DatePipe
  ) {
    monkeyPatchChartJsTooltip();
    monkeyPatchChartJsLegend();

    this.getOverdueInvoices();
  }

  getOverdueInvoices() {
    this.today_date = this.datePipe.transform(Date.now(), 'yyyy-MM-dd');
    let duedate: DueDate = {
      dueDate: this.today_date,
    };
    const userId = this.userService.getUserId();
    this.http
      .post<InvoiceModel[]>(
        'https://localhost:44365/invoice/' + userId,
        duedate,
        this.sessionService.requestOptions
      )
      .subscribe((response) => {
        console.log(response);
        this.invoices = response;
      });
  }

  ngOnInit(): void {}
}
