import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

interface Company {
  name: string;
  code: string;
}

@Component({
  selector: 'app-companyselection',
  templateUrl: './companyselection.component.html',
  styleUrls: ['./companyselection.component.scss']
})
export class CompanyselectionComponent {

  constructor(private router: Router, private activateRoute: ActivatedRoute){}

  companies: Company[];

  selectedCity: Company;

  showHeaderForCompanySelect: boolean = false;

  ngOnInit() {
      this.showHeaderForCompanySelect = this.activateRoute.snapshot?.params['value'] == "header" ? true : false;
      this.companies = [
          { name: 'New York', code: 'NY' },
          { name: 'Rome', code: 'RM' },
          { name: 'London', code: 'LDN' },
          { name: 'Istanbul', code: 'IST' },
          { name: 'Paris', code: 'PRS' }
      ];
  }

  onSaveCompanySelection() {
    this.router.navigate(['/dashboard']);
  }

  goBack() {
    this.router.navigate(['/dashboard']);
  }
}
