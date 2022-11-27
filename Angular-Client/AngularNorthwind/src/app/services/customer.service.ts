import { HttpClient } from '@angular/common/http';
import { CustomerModel } from '../models/customer.model';
import { map } from 'rxjs/operators';
import { Injectable } from '@angular/core';

@Injectable()
export class CustomerService {
  customers: CustomerModel[] = Array();
  isUpToDate: boolean = false;

  constructor(private httpClient: HttpClient) {}

  RetrieveAsync(url: string) {
    return new Promise((resolve, reject) => {
      this.httpClient
        // Making GET request with url
        .get(url)
        // Funnel the response data into specified type
        .pipe(
          // Using the map method to convert to response data into specified type, And specified key for each element
          map((response: { [key: string]: CustomerModel }) => {
            const postArray: CustomerModel[] = [];
            for (const key in response) {
              if (response.hasOwnProperty(key)) {
                postArray.push({ ...response[key] });
                // { property : value }
                // { ...object[index] }                          //// spreade operator
                // { property : ...object[index].property }
              }
            }
            return postArray;
          })
        )
        // Subscribe to the response data.
        .subscribe((response) => {
          if (response === null) reject('Error to retrieve data');
          else resolve(response);
        });
    });
  }

  // GetAsync(url: string): CustomerModel[] {
  //   if (!this.isUpToDate) {
  //     this.RetrieveAsync(url);
  //   }
  //   return this.customers;
  // }
}
