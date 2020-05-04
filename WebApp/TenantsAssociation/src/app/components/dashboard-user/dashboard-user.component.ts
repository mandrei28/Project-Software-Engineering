import { Component, OnInit } from '@angular/core';
import { ChartType, ChartOptions } from 'chart.js';
import {
  SingleDataSet,
  Label,
  monkeyPatchChartJsLegend,
  monkeyPatchChartJsTooltip,
} from 'ng2-charts';
import { DatePipe } from '@angular/common';

@Component({
  selector: 'app-dashboard-user',
  templateUrl: './dashboard-user.component.html',
  styleUrls: ['./dashboard-user.component.scss'],
})
export class DashboardUserComponent implements OnInit {
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
  today_date: string;
  test: string;
  public dateFrom: string = '2016-10-01';
  constructor(private datePipe: DatePipe) {
    {
      this.today_date = datePipe.transform(Date.now(), 'yyyy-MM-dd');
    }
    if (this.today_date > this.dateFrom) {
      this.test = this.dateFrom;
    }
    monkeyPatchChartJsTooltip();
    monkeyPatchChartJsLegend();
  }

  ngOnInit(): void {}
}
