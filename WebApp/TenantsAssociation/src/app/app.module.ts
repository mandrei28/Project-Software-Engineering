import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { InvoicesComponent } from './components/invoices/invoices.component';
import { DashboardUserComponent } from './components/dashboard-user/dashboard-user.component';
import { MatTableModule } from '@angular/material/table';
import { MatPaginatorModule } from '@angular/material/paginator';
import { FlexLayoutModule } from '@angular/flex-layout';
import { HttpClientModule } from '@angular/common/http';
import { MatSortModule } from '@angular/material/sort';
import { DashboardAdminComponent } from './components/dashboard-admin/dashboard-admin.component';
import { MatButtonModule } from '@angular/material/button';
import { DialogPoolComponent } from './components/dashboard-admin/dialog-pool/dialog-pool.component';
import { MatDialogModule } from '@angular/material/dialog';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatIconModule } from '@angular/material/icon';
import { DialogAddPollComponent } from './components/dashboard-admin/dialog-add-poll/dialog-add-poll.component';
import { DialogSendMessageComponent } from './components/dashboard-admin/dialog-send-message/dialog-send-message.component';
import { DialogAddInvoiceComponent } from './components/dashboard-admin/dialog-add-invoice/dialog-add-invoice.component';

@NgModule({
  declarations: [
    AppComponent,
    InvoicesComponent,
    DashboardUserComponent,
    DashboardAdminComponent,
    DialogPoolComponent,
    DialogAddPollComponent,
    DialogSendMessageComponent,
    DialogAddInvoiceComponent,
  ],
  imports: [
    FormsModule,
    ReactiveFormsModule,
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MatTableModule,
    MatPaginatorModule,
    FlexLayoutModule,
    HttpClientModule,
    MatSortModule,
    MatButtonModule,
    MatDialogModule,
    MatFormFieldModule,
    MatInputModule,
    MatIconModule,
  ],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule {}
