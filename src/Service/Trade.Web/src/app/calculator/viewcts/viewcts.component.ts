import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

import { Message, MessageService } from 'primeng/api';
import { SharedService } from '../../common/shared.service';

interface tableitems {
  size: string,
  number: string,
  carat: number,
  rate: number,
  numbername: string,
  percentage: number,
  amount: number
  //sizename: string
}

interface masterItem{
  size: string,
  sizename: string,
  totalcarat: number
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
  size:string,
  sizename:string,
  percentage: number,
  amount: number,
  totcarat: number 
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
  masterItem: masterItem[] = [];
  summatydata: Summary[] = [];
  selectednumber: any;
  selectedsize: any;
  selectedcarat : number = 0;
  mastercarat: number = 0;
  selectedtotalcarat: number = 0;
  valueTextArea: string;
  summaryTotAmount = 0;

  products: Product[] = [
    { id: 1, number: 'IF SSD', cts: 12, rate: 1254, percentage: '1.3', amount: 125 },
    { id: 2, number: 'SSD', cts: 10, rate: 1569, percentage: '1.4', amount: 157 },
  ]

  // summary: Summary[] = [
  //   { id: 1, sizeName: '+2', percentage: '14', amount: 12563 },
  //   { id: 2, sizeName: '+6', percentage: '52', amount: 58000 },
  //   { id: 3, sizeName: '+11', percentage: '68', amount: 158000 }
  // ]

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
    this.summatydata.forEach(e => {
      const filteredSize = this.tableitems.filter((f) => {
        return f.size == e.size;
      });
      
      const totalAmount = filteredSize.reduce((acc, curr) => {
        return acc + curr.amount;
      }, 0);
      e.amount = totalAmount;
      e.percentage = (e.totcarat / this.mastercarat)*100;
      this.summaryTotAmount = this.summaryTotAmount + e.amount;
    });
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
    this.selectedsize = event.value;
    var caratData = this.masterItem.filter(e => e.size == this.selectedsize.id);
    if (caratData != null && caratData.length > 0){
      this.selectedtotalcarat = caratData[0].totalcarat;
    }
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
    if (this.masterItem.filter(e => e.size == this.selectedsize.id).length == 0){
      this.masterItem.push({
        size : this.selectedsize.id,
        sizename: this.selectedsize.name,
        totalcarat: this.selectedtotalcarat
      });

      this.summatydata.push({
        size: this.selectedsize.id,
        sizename : this.selectedsize.name,
        percentage : 0,
        amount : 0,
        totcarat : this.selectedtotalcarat
      });
    }
    var retdata = this.pricelist.filter(e => e.sizeId == this.selectedsize.id && e.numberId == this.selectednumber.id);
      this.tableitems.push({
        size : this.selectedsize.id,
        number : this.selectednumber.id,
        carat : this.selectedcarat,
        rate : (retdata != null && retdata.length > 0) ? retdata[0].price : 0,
        numbername: this.selectednumber.name,
        amount: this.selectedcarat * ((retdata != null && retdata.length > 0) ? retdata[0].price : 0),
        percentage : (this.selectedcarat / ((retdata != null && retdata.length > 0) ? retdata[0].price : 0)) * 100
    });
    // if (this.selectedsizeonly.findIndex((s: any) => s == this.selectedsize) < 0){
    //   this.selectedsizeonly.push(this.selectedsize);
    // }    
  }
  getItemsBySize(size: string){
    debugger;
    return this.tableitems.filter(item => item.size === size);
  }

  deleteitems(item: any){
    debugger;
    if (confirm("Are you sure you want to delete this item?")) {
      var index = this.tableitems.indexOf(item);
      if (index >= 0){
        this.tableitems.splice(index, 1);
      }
      if (this.tableitems.filter(e => e.size == item.size).length == 0){
        var ind = this.masterItem.findIndex(e => e.size == item.size);
        if (ind >= 0){
          this.masterItem.splice(ind,1);
        }
      }
    }
  }
}
