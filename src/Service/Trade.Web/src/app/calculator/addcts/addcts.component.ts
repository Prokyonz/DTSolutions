import { Component, OnInit } from '@angular/core';

interface City {
  name: string;
  code: string;
}

@Component({
  selector: 'app-addcts',
  templateUrl: './addcts.component.html',
  styleUrls: ['./addcts.component.scss']
})

export class AddctsComponent implements OnInit {
  cities: City[] = [];

  ngOnInit() {
    this.cities = [
        { name: 'New York', code: 'NY' },
        { name: 'Rome', code: 'RM' },
        { name: 'London', code: 'LDN' },
        { name: 'Istanbul', code: 'IST' },
        { name: 'Paris', code: 'PRS' }
    ];
}
  
  addCts(){
    
  }

 

   
}
