import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { SharedService } from './shared.service';
import { HttpClientModule } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { DataTablesModule } from 'angular-datatables';
import { NavbarComponentComponent } from './navbar-component/navbar-component.component';
import { CompanyComponent } from './company/company.component';
import { AddComponent } from './company/add/add.component';
import { ListComponent } from './company/list/list.component';
import { ViewComponent } from './company/view/view.component';

import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { EditComponent } from './company/edit/edit.component';
import { RouterModule } from '@angular/router';

@NgModule({
  declarations: [
    AppComponent,
    NavbarComponentComponent,
    CompanyComponent,
    AddComponent,
    ListComponent,
    ViewComponent,
    EditComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    DataTablesModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule.forRoot([])
  ],
  providers: [
    SharedService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
