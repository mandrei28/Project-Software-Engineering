import { GridAutoDirective } from '@angular/flex-layout/grid/typings/auto/auto';

export class InvoiceModel {
  id: string;
  invoiceNumber: number;
  apartment: string;
  bill: number;
  description: string;
  createdDate: Date;
  dueDate: Date;
  payDate: Date;
}
