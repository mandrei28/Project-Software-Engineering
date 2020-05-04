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

export class MessageModel {
  id: string;
  text: string;
  userId: string;
  administratorId: string;
}

export interface User {
  name: string;
  password: string;
  mail: string;
}

export class Poll {
  question: string;
}
export class Invoice {
  email: string;
  invoiceNumber: number;
  bill: number;
  description: string;
  createDate: Date;
  dueDate: Date;
  payDate: Date;
}

export class Message {
  email: string;
  text: string;
  dateCreated: Date;
}
