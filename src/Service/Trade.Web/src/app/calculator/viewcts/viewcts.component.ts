import { Component } from '@angular/core';
import { Router } from '@angular/router';

import { Message, MessageService } from 'primeng/api';


interface City {
  name: string;
  code: string;
}

interface Product {
  id:number,
  number: string,
  cts: number,
  rate: number,
  percentage: string,
  amount: number,
}

interface Summary {
  id: number,
  sizeName:string,
  percentage: string,
  amount: number 
}

interface Customer {
  name: string,
  country: string,
  date: string,
  balance: number,
  verified: boolean
}

@Component({
  selector: 'app-viewcts',
  templateUrl: './viewcts.component.html',
  styleUrls: ['./viewcts.component.scss'],
  providers: [MessageService]
})

export class ViewctsComponent {
  showViewSection:boolean = false;
  showAddSection:boolean = false;
  showHomeSection:boolean = true;

  PageTitle:string = "History";
  loading: boolean = false;
  valueTextArea: string;
  showHistory: boolean = true;

  products: Product[] = [
    { id: 1, number: 'IF SSD', cts: 12, rate: 1254, percentage: '1.3', amount: 125 },
    { id: 2, number: 'SSD', cts: 10, rate: 1569, percentage: '1.4', amount: 157 },
  ]

  summary: Summary[] = [
    { id: 1, sizeName: '+2', percentage: '14', amount: 12563 },
    { id: 2, sizeName: '+6', percentage: '52', amount: 58000 },
    { id: 3, sizeName: '+11', percentage: '68', amount: 158000 }
  ]

  cities: City[] = [
      { name: '+2', code: 'NY' },
      { name: '-2', code: 'RM' },
      { name: '+6', code: 'LDN' },
      { name: '+11', code: 'IST' },
      { name: '-6', code: 'PRS' }
  ];

   //Table variables
   customers: Customer[] = [
    { name: 'Abhishek', country: 'India', date: '12/12/2014', balance: 25000, verified: true },
    { name: 'Anand', country: 'India', date: '12/12/2014', balance: 28000, verified: false },
    { name: 'Shaielsh', country: 'USA', date: '01/11/2015', balance: 45000, verified: false },
    { name: 'Akshay', country: 'UK', date: '01/11/2017', balance: 145000, verified: false },
    { name: 'Abhishek', country: 'India', date: '12/12/2014', balance: 25000, verified: true },
    { name: 'Anand', country: 'India', date: '12/12/2014', balance: 28000, verified: false },
    { name: 'Shaielsh', country: 'USA', date: '01/11/2015', balance: 45000, verified: false },
    { name: 'Akshay', country: 'UK', date: '01/11/2017', balance: 145000, verified: false },
    { name: 'Abhishek', country: 'India', date: '12/12/2014', balance: 25000, verified: true },
    { name: 'Anand', country: 'India', date: '12/12/2014', balance: 28000, verified: false },
    { name: 'Shaielsh', country: 'USA', date: '01/11/2015', balance: 45000, verified: false },
    { name: 'Akshay', country: 'UK', date: '01/11/2017', balance: 145000, verified: false },
  ];  

  constructor(private router: Router, private messageService: MessageService) {

  }

  myfunction() {
    if(this.showViewSection == true) {
      this.showAddSection = true;
      this.showViewSection = false;
      this.showHomeSection = false;
      this.PageTitle = "Add Details";
    }
    else
      this.router.navigate(["dashboard"]);
  }

  showDetails() {
    this.PageTitle = "View Details";
    this.showAddSection = false;
    this.showViewSection = true;
    this.showHomeSection = false;
  }

  showMessage() {
    this.messageService.addAll([{severity:'success', summary:'Success'}, { severity:'error', summary:'Error occurred.' }]);
  }

  saveDetails() {    
      this.loading = true;

      setTimeout(() => {
          this.loading = false;
          this.messageService.addAll([{severity:'success', summary:'Details saved successfully.'}, { severity:'error', summary:'Error occurred.' }]);
          this.showAddSection = false;
          this.showViewSection = false;
          this.showHomeSection = true;
      }, 2000);
  }

  onAddIconClick() {
    console.log("add button click.");
    this.showAddSection = true;
    this.showViewSection = false;
    this.showHomeSection = false;
  }
}
