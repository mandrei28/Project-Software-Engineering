import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { DashboardAdminComponent } from './components/dashboard-admin/dashboard-admin.component';

const routes: Routes = [
  {
    path: 'adminDashboard',
    component: DashboardAdminComponent
  },
  { path: '', redirectTo: '/adminDashboard', pathMatch: 'full' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {}
