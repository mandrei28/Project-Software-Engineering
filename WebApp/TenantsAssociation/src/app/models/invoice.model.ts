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
