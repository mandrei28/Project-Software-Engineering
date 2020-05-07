import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { map, filter, catchError, mergeMap } from 'rxjs/operators';
import { Observable } from 'rxjs';
import { InvoiceModel, Invoice } from 'src/app/models/invoice.model';
import { HttpClient } from '@angular/common/http';
import { SessionService } from 'src/app/services/session.service';

@Component({
  selector: 'app-invoice-details',
  templateUrl: './invoice-details.component.html',
  styleUrls: ['./invoice-details.component.scss'],
})
export class InvoiceDetailsComponent implements OnInit {
  id: string;
  invoice: InvoiceModel;

  constructor(
    public activatedRoute: ActivatedRoute,
    public http: HttpClient,
    public sessionService: SessionService,
    public router: Router
  ) {}

  ngOnInit(): void {
    this.id = this.activatedRoute.snapshot.paramMap.get('invoiceId');
    this.getInvoices();
  }
  getInvoices() {
    this.http
      .get<InvoiceModel>(
        'https://localhost:44365/invoice/edit/' + this.id,
        this.sessionService.requestOptions
      )
      .subscribe((response) => {
        this.invoice = response;
      });
  }
  payInvoice() {
    this.http
      .post(
        'https://localhost:44365/invoice/pay/' + this.id,
        null,
        this.sessionService.requestOptions
      )
      .subscribe((response) => {
        this.router.navigate(['/invoices']);
      });
  }
}
