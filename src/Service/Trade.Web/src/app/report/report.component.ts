import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Table } from 'primeng/table';

interface Customer {
  name: string,
  country: string,
  date: string,
  balance: number,
  verified: boolean
}

@Component({
  selector: 'app-report',
  templateUrl: './report.component.html',
  styleUrls: ['./report.component.scss']
})

export class ReportComponent implements OnInit {

  PageTitle: string = "Purchase Report";
  reportIndex: number = 0;

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

  loading: boolean = true;

  constructor(private rote: Router, private activateRoute: ActivatedRoute) {
    this.reportIndex = activateRoute.snapshot.params['id'];
  }

  ngOnInit() {
    this.loading = false;
  }

  goBack() {
    this.rote.navigate(['/dashboard']);
  }

  //Tabel functions
  clear(table: Table) {
      table.clear();
  }

  myfunc(event: any): string {
    return event.target.value;
  }

}
