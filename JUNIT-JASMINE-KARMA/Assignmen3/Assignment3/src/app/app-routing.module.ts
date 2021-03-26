import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { CompanyComponent } from './company/company.component';
import { AddComponent } from './company/add/add.component';
import { ListComponent } from './company/list/list.component';
import { ViewComponent } from './company/view/view.component';
import { EditComponent } from './company/edit/edit.component';

const routes: Routes = [
  { path: '', redirectTo: 'list-company', pathMatch: 'full'},
  { path: 'add-company', component: AddComponent },
  { path: 'list-company', component: ListComponent },
  { path: 'view-company/:id', component: ViewComponent },
  { path: 'edit-company/:id', component: EditComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})

export class AppRoutingModule { }
