import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { map } from 'rxjs/operators';
import { CustomerModel } from '../models/customer.model';
import { CustomerService } from '../services/customer.service';
import { Observable, Subscription } from 'rxjs';

@Component({
  selector: 'app-customer',
  templateUrl: './customer.component.html',
  styleUrls: ['./customer.component.css'],
  providers: [CustomerService],
})
export class CustomerComponent implements OnInit {
  customers: CustomerModel[] = Array();

  customerObservable: Subscription;

  constructor(private customerService: CustomerService) {}

  ngOnInit(): void {}

  onPrintData() {
    this.customerService
      .RetrieveAsync('https://localhost:5002/api/Customers?country=USA')
      .then(
        (retrieved) => {
          console.log(retrieved);
        },
        (rejected) => {
          console.log(rejected);
        }
      );
    // console.log(this.customers);
  }
}
