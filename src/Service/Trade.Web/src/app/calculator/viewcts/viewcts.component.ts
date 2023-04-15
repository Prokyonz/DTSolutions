import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

import { Message, MessageService } from 'primeng/api';
import { SharedService } from '../../common/shared.service';

interface tableitems {
  size: string,
  number: string,
  carat: number,
  rate: number,
  sizename: string
}

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

@Component({
  selector: 'app-viewcts',
  templateUrl: './viewcts.component.html',
  styleUrls: ['./viewcts.component.scss'],
  providers: [MessageService]
})

export class ViewctsComponent implements OnInit{
  showViewSection:boolean = false;
  PageTitle:string = "Add Details";
  loading: boolean = false;
  branches: any;
  party: any;
  dealers: any;
  sizes: any;
  numbers: any;
  pricelist: any[] = [];
  comanyid: string = "ff8d3c9b-957b-46d1-b661-560ae4a2433e";
  tableitems: tableitems[] = [];
  selectednumber: any;
  selectedsize: any;
  selectedcarat : number = 0;
  valueTextArea: string;

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

  constructor(private router: Router, private messageService: MessageService, private sharedService: SharedService) {

  }
  ngOnInit(): void {
    this.getparty();
    this.getdealer();
    this.getbranch();
    this.getsize();
    this.getnumber();
    this.getAllNumberPrice();
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

  getparty(){
    this.sharedService.customGetApi("Service/GetParty?companyid=" + this.comanyid).subscribe((t) => {
      debugger;
      if (t.success == true){
        this.party = t.data;
      }
    });      
  }

  getdealer(){
    this.sharedService.customGetApi("Service/GetDealer?companyid=" + this.comanyid).subscribe((t) => {
      debugger;
      if (t.success == true){
        this.dealers = t.data;
      }
    });      
  }

  getbranch(){
    this.sharedService.customGetApi("Service/GetBranch?companyid=" + this.comanyid).subscribe((t) => {
      debugger;
      if (t.success == true){
        this.branches = t.data;
      }
    });      
  }

  getsize(){
      this.sharedService.customGetApi("Service/GetSize").subscribe((t) => {
        debugger;
        if (t.success == true){
          this.sizes = t.data;
        }
      });      
  }

  getnumber(){
    this.sharedService.customGetApi("Service/GetNumber").subscribe((t) => {
      debugger;
      if (t.success == true){
        this.numbers = t.data;
      }
    });      
  }

  getAllNumberPrice(){
    this.sharedService.customGetApi("Service/GetAllNumberPrice?companyId=ff8d3c9b-957b-46d1-b661-560ae4a2433e&categoryId=0").subscribe((t) => {
      debugger;
      if (t.success == true){
       this.pricelist = t.data;
      }
    });      
  }

  handlesize(event: any) {
    this.selectedsize = event.value.value;
  }

  viewdata(){
    debugger;
    //console.log(this.caratData);
  }

  handlenumber(event: any) {
    this.selectednumber = event.value.number;
  }

  addItems(){
    debugger;
    var retdata = this.pricelist.filter(e => e.sizeId == this.selectedsize.id && e.numberId == this.selectednumber.id);
    this.tableitems.push({
      size : this.selectedsize.id,
      number : this.selectednumber.id,
      carat : this.selectedcarat,
      rate : retdata[0].price,
      sizename: this.selectedsize.name
    });
    // if (this.selectedsizeonly.findIndex((s: any) => s == this.selectedsize) < 0){
    //   this.selectedsizeonly.push(this.selectedsize);
    // }    
  }
}
