import { Component } from '@angular/core';
import { Router } from '@angular/router';

import { Message, MessageService } from 'primeng/api';


interface City {
  name: string;
  code: string;
}

@Component({
  selector: 'app-viewcts',
  templateUrl: './viewcts.component.html',
  styleUrls: ['./viewcts.component.scss'],
  providers: [MessageService]
})

export class ViewctsComponent {
  showViewSection:boolean = false;
  PageTitle:string = "Add Details";
  loading: boolean = false;

  cities: City[] = [
      { name: 'New York', code: 'NY' },
      { name: 'Rome', code: 'RM' },
      { name: 'London', code: 'LDN' },
      { name: 'Istanbul', code: 'IST' },
      { name: 'Paris', code: 'PRS' }
  ];

  constructor(private router: Router, private messageService: MessageService) {

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

  showMessage() {
    this.messageService.addAll([{severity:'success', summary:'Success'}, { severity:'error', summary:'Error occurred.' }]);
  }

  saveDetails() {    
      this.loading = true;

      setTimeout(() => {
          this.loading = false;
          this.messageService.addAll([{severity:'success', summary:'Details saved successfully.'}, { severity:'error', summary:'Error occurred.' }]);
          this.showViewSection = false;
      }, 2000);
  }
}
