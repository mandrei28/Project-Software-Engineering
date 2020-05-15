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
import { RegisterComponent } from './components/register/register.component';
import { MatInputModule } from '@angular/material/input';
import { MatFormFieldModule } from '@angular/material/form-field';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { ChartsModule } from 'ng2-charts';
import { MatRadioModule } from '@angular/material/radio';
import { DashboardAdminComponent } from './components/dashboard-admin/dashboard-admin.component';
import { DialogPoolComponent } from './components/dashboard-admin/dialog-user/dialog-pool.component';
import { MatDialogModule } from '@angular/material/dialog';
import { DialogAddPollComponent } from './components/dashboard-admin/dialog-add-poll/dialog-add-poll.component';
import { DialogSendMessageComponent } from './components/dashboard-admin/dialog-send-message/dialog-send-message.component';
import { DialogAddInvoiceComponent } from './components/dashboard-admin/dialog-add-invoice/dialog-add-invoice.component';
import { MatListModule } from '@angular/material/list';

import { LoginComponent } from './components/login/login.component';
import { AuthGuard } from './services/auth.guard';
import { YourAccountComponent } from './components/your-account/your-account.component';
import { MatExpansionModule } from '@angular/material/expansion';
import { NavbarComponent } from './components/navbar/navbar.component';
import { MatToolbarModule } from '@angular/material/toolbar';
import { ContactComponent } from './components/contact/contact.component';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import { DatePipe } from '@angular/common';
import { MatSnackBarModule } from '@angular/material/snack-bar';
import { InvoiceDetailsComponent } from './components/invoice-details/invoice-details.component';
import { ServicesComponent } from './components/services/services.component';

@NgModule({
  declarations: [
    AppComponent,
    InvoicesComponent,
    DashboardUserComponent,
    RegisterComponent,
    LoginComponent,
    YourAccountComponent,
    NavbarComponent,
    ContactComponent,
    DashboardAdminComponent,
    DialogPoolComponent,
    DialogAddPollComponent,
    DialogSendMessageComponent,
    DialogAddInvoiceComponent,
    DashboardComponent,
    InvoiceDetailsComponent,
    ServicesComponent,
  ],
  imports: [
    MatCheckboxModule,
    MatIconModule,
    FormsModule,
    MatSnackBarModule,
    ReactiveFormsModule,
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
    ChartsModule,
    MatRadioModule,
    MatExpansionModule,
    MatToolbarModule,
    MatButtonModule,
    MatDialogModule,
    MatFormFieldModule,
    MatInputModule,
    MatIconModule,
    MatListModule,
  ],

  providers: [AuthGuard, DatePipe],
  bootstrap: [AppComponent],
})
export class AppModule {}
