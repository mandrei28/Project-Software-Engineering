export class InvoiceModel {
  id: string;
  invoiceNumber: number;
  apartmentId: string;
  bill: number;
  description: string;
  createdDate: Date;
  dueDate: Date;
  payDate: Date;
  paid: number;
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
  email: string;
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
  administratorId: string;
}
