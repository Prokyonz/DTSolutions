import { Component } from '@angular/core';
import { Router } from '@angular/router';

interface City {
  name: string;
  code: string;
}

@Component({
  selector: 'app-viewcts',
  templateUrl: './viewcts.component.html',
  styleUrls: ['./viewcts.component.scss']
})

export class ViewctsComponent {
  showViewSection:boolean = false;
  PageTitle:string = "Add Details"

  cities: City[] = [
      { name: 'New York', code: 'NY' },
      { name: 'Rome', code: 'RM' },
      { name: 'London', code: 'LDN' },
      { name: 'Istanbul', code: 'IST' },
      { name: 'Paris', code: 'PRS' }
  ];

  constructor(private router: Router) {

  }

  myfunction() {
    if(this.showViewSection == true) {
      this.showViewSection = false;
      this.PageTitle = "Add Details";
    }
    else
      this.router.navigate(["dashboard"]);
  }

  showDetails() {
    this.PageTitle = "View Details";
    this.showViewSection = true;
  }
}
