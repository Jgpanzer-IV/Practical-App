import { Injectable, NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { Routes, RouterModule } from '@angular/router';
import { HttpClientModule } from '@angular/common/http';

import { AppComponent } from './app.component';
import { CustomerComponent } from './customer/customer.component';
import { CustomerCardComponent } from './customer/customer-card/customer-card.component';
import { CustomerFormComponent } from './customer/customer-form/customer-form.component';
import { HomeComponent } from './home/home.component';
import { CustomerRegisterFormComponent } from './customer/customer-register-form/customer-register-form.component';
import { CustomerService } from './services/customer.service';

const appRoute: Routes = [
  { path: 'home', component: HomeComponent },
  { path: 'customer', component: CustomerComponent },
  { path: 'customer/register', component: CustomerRegisterFormComponent },
];

@NgModule({
  declarations: [
    AppComponent,
    CustomerComponent,
    CustomerCardComponent,
    CustomerFormComponent,
    HomeComponent,
    CustomerRegisterFormComponent,
  ],
  imports: [BrowserModule, HttpClientModule, RouterModule.forRoot(appRoute)],
  bootstrap: [AppComponent],
})
export class AppModule {}
