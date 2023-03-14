import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AccountComponent } from './account/account.component';
import { CompanyComponent } from './company/company.component';
import { EmployeeComponent } from './employee/employee.component';

const routes: Routes = [
  { path: 'company', component: CompanyComponent },
  { path: 'employee', component: EmployeeComponent },
  { path: 'account', component: AccountComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
