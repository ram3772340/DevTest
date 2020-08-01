import { Component, OnInit } from '@angular/core';
import { CustomerModel } from '../models/customer.model';
import { NgForm } from '@angular/forms';
import { CustomerService } from '../services/customer.service';

@Component({
  selector: 'app-customer',
  templateUrl: './customer.component.html',
  styleUrls: ['./customer.component.scss']
})
export class CustomerComponent implements OnInit {

  public customers: CustomerModel[] = [];
  public customerTypes: string[] = ["large", "small"];

  public newCustomer: CustomerModel = {
    customerId: null,
    customerName: null,
    customerType: null
  };

  constructor(
    private customerService: CustomerService) { }

  ngOnInit() {
    this.customerService.GetCustomers().subscribe(customers => this.customers = customers);
  }

  public createCustomer(form: NgForm): void {
    if (form.invalid) {
      alert('form is not valid');
    } else {
      this.customerService.CreateCustomer(this.newCustomer).then(() => {
        this.customerService.GetCustomers().subscribe(customers => this.customers = customers);
      });
    }
  }
}
