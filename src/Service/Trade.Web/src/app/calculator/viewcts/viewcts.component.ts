import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

import { Message, MessageService } from 'primeng/api';
import { SharedService } from '../../common/shared.service';

interface CalclatorMaster{
  Date: Date,
  CompanyId: string,
  FinancialYearId: string,
  BranchId: string,
  PartyId: string,
  BrokerId: string,
  NetCarat: number,
  Note: string,
  SizeDetails: SizeDetails[] | null,
  UserId: string              
}

interface NumberDetails {
  SizeId: string,
  NumberId: string,
  Carat: number,
  Rate: number,
  NumberName: string,
  Percentage: number,
  Amount: number
  //sizename: string
}

interface SizeDetails{
  SizeId: string,
  SizeName: string,
  TotalCarat: number,
  NumberDetails: NumberDetails[] | null
}

interface Summary {
  SizeId:string,
  SizeName:string,
  Percentage: number,
  Amount: number,
  TotCarat: number 
}

<<<<<<< HEAD
<<<<<<< HEAD
=======
>>>>>>> Save done
interface Customer {
  name: string,
  country: string,
  date: string,
  balance: number,
  verified: boolean
}
<<<<<<< HEAD
=======
>>>>>>> Commit
=======
>>>>>>> Save done

@Component({
  selector: 'app-viewcts',
  templateUrl: './viewcts.component.html',
  styleUrls: ['./viewcts.component.scss'],
  providers: [MessageService]
})

export class ViewctsComponent implements OnInit{
  showViewSection:boolean = false;
  showAddSection:boolean = false;
  showHomeSection:boolean = true;
  showHistory: boolean = true;
  PageTitle:string = "History";
  loading: boolean = false;
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
  valueTextArea: string;
  showHistory: boolean = true;
=======
  branches: any;
  party: any;
  dealers: any;
  sizes: any;
  numbers: any;
=======
  branches: any[] = [];
  party: any[] = [];
  dealers: any[] = [];
  sizes: any[] = [];
  numbers: any[] = [];
>>>>>>> Calculator changes
  pricelist: any[] = [];
  comanyid: string = "ff8d3c9b-957b-46d1-b661-560ae4a2433e";
  NumberDetails: NumberDetails[] = [];
  SizeDetails: SizeDetails[] = [];
  summatydata: Summary[] = [];
  selectednumber: any;
  selectedsize: any;
  selectedcarat : number = 0;
  netcarat: number = 0;
  selectedtotalcarat: number = 0;
  valueTextArea: string;
  summaryTotAmount = 0;
<<<<<<< HEAD
>>>>>>> Add changes

  products: Product[] = [
    { id: 1, number: 'IF SSD', cts: 12, rate: 1254, percentage: '1.3', amount: 125 },
    { id: 2, number: 'SSD', cts: 10, rate: 1569, percentage: '1.4', amount: 157 },
  ]

<<<<<<< HEAD
  summary: Summary[] = [
    { id: 1, sizeName: '+2', percentage: '14', amount: 12563 },
    { id: 2, sizeName: '+6', percentage: '52', amount: 58000 },
    { id: 3, sizeName: '+11', percentage: '68', amount: 158000 }
  ]
=======
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
>>>>>>> Update Calculator
=======
  // summary: Summary[] = [
  //   { id: 1, sizeName: '+2', percentage: '14', amount: 12563 },
  //   { id: 2, sizeName: '+6', percentage: '52', amount: 58000 },
  //   { id: 3, sizeName: '+11', percentage: '68', amount: 158000 }
  // ]
>>>>>>> Add changes

  cities: City[] = [
      { name: '+2', code: 'NY' },
      { name: '-2', code: 'RM' },
      { name: '+6', code: 'LDN' },
      { name: '+11', code: 'IST' },
      { name: '-6', code: 'PRS' }
  ];
=======
  date: Date = new Date();
  branchid: any = [];
  partyid: any = [];
  dealerid: any = [];
  calculatorData: any = [];
  note: string = '';
<<<<<<< HEAD
>>>>>>> Commit

<<<<<<< HEAD
<<<<<<< HEAD
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
=======
=======


>>>>>>> Save done
=======
>>>>>>> Add
  constructor(private router: Router, private messageService: MessageService, private sharedService: SharedService) {
>>>>>>> Update Calculator

  }
  ngOnInit(): void {
    this.calculatorList();
  }

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
    if (this.date == null)
    {
      this.showMessage('error','Select any date');
      return;
    }
    if (this.branchid.id == '')
    {
      this.showMessage('error',"Select any branch");
      return;
    }
    if (this.partyid.id == '')
    {
      this.showMessage('error','Select any party');
      return;
    }
    if (this.dealerid.id == '')
    {
      this.showMessage('error','Select any broker');
      return;
    }
    if (this.netcarat <= 0)
    {
      this.showMessage('error','Netcarat can not be less than or equal to zero');
      return;
    }
    if (this.NumberDetails.length == 0)
    {
      this.showMessage('error','Carat item can not be empty');
      return;
    }
    this.PageTitle = "View Details";
    this.showAddSection = false;
    this.showViewSection = true;
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
    this.showHomeSection = false;
=======
=======
=======
    this.showHomeSection = false;
<<<<<<< HEAD
>>>>>>> Save done
=======
    this.SizeDetails.forEach(element => {
      element.NumberDetails = this.NumberDetails.filter(e => e.SizeId == element.SizeId);
    });
>>>>>>> Add
    this.calulateSummary();
  }

  calculatorList(){
    
    this.sharedService.customGetApi("Calculator/GetCalculatorReport?CompanyId=" + this.comanyid + "&FinancialYearId=1&FromDate=20230501&ToDate=20230501")
    .subscribe((data: any) => {
          this.calculatorData = data;
          console.log(this.calculatorData);
        }, (ex: any) => {
          this.showMessage('error',ex);
      });
  }

  calulateSummary(){
    this.summaryTotAmount = 0;
>>>>>>> Commit
    this.summatydata.forEach(e => {
      let filteredSize = this.NumberDetails.filter((f) => {
        return f.SizeId == e.SizeId;
      });
      
      let totalAmount = filteredSize.reduce((acc, curr) => {
        return acc + curr.Amount;
      }, 0);      

      e.Amount = totalAmount;
      e.Percentage = (e.TotCarat / this.netcarat)*100;
      this.summaryTotAmount = this.summaryTotAmount + e.Amount;
    });
>>>>>>> Add changes
  }

<<<<<<< HEAD
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

<<<<<<< HEAD
  onAddIconClick() {
    console.log("add button click.");
    this.showAddSection = true;
    this.showViewSection = false;
    this.showHomeSection = false;
=======
=======
>>>>>>> Change Message
  getparty(){
    this.sharedService.customGetApi("Service/GetParty?companyid=" + this.comanyid).subscribe((t) => {
      if (t.success == true){
        if (t.data != null && t.data.length > 0){
          t.data = [
            { name: '-Select-', id: '' },
            ...t.data
          ];
          this.party = t.data;
        }
      }
    });      
  }

  getdealer(){
    this.sharedService.customGetApi("Service/GetDealer?companyid=" + this.comanyid).subscribe((t) => {
      if (t.success == true){
        if (t.data != null && t.data.length > 0){
          t.data = [
            { name: '-Select-', id: '' },
            ...t.data
          ];
          this.dealers = t.data;
        }
      }
    });      
  }

  getbranch(){
    this.sharedService.customGetApi("Service/GetBranch?companyid=" + this.comanyid).subscribe((t) => {
      if (t.success == true){
        if (t.data != null && t.data.length > 0){
          t.data = [
            { name: '-Select-', id: '' },
            ...t.data
          ];
          this.branches = t.data;
        }
      }
    });      
  }

  getsize(){
      this.sharedService.customGetApi("Service/GetSize").subscribe((t) => {
        if (t.success == true){
          if (t.data != null && t.data.length > 0){          
            t.data = [
              { name: '-Select-', id: '' },
              ...t.data
            ];
          }
        }
        this.sizes = t.data;
      });      
  }

  getnumber(){
    this.sharedService.customGetApi("Service/GetNumber").subscribe((t) => {
      if (t.success == true){
        if (t.success == true){
          if (t.data != null && t.data.length > 0){          
            t.data = [
              { name: '-Select-', id: '' },
              ...t.data
            ];
          }
        }
        this.numbers = t.data;
      }
    });      
  }

  getAllNumberPrice(){
    this.sharedService.customGetApi("Service/GetAllNumberPrice?companyId=" + this.comanyid + "&categoryId=0").subscribe((t) => {
      if (t.success == true){
       this.pricelist = t.data;
      }
    });      
  }

  handlesize(event: any) {
    this.selectedsize = event.value;
    var caratData = this.SizeDetails.filter(e => e.SizeId == this.selectedsize.id);
    if (caratData != null && caratData.length > 0){
      this.selectedtotalcarat = caratData[0].TotalCarat;
    }
    else{
      this.selectedtotalcarat = 0;
    }
  }

  viewdata(){
    debugger;
    //console.log(this.caratData);
  }

  handlenumber(event: any) {
    this.selectednumber = event.value.number;
  }
  handleparty(event: any){
    this.partyid = event.value;
  }

  handlebranch(event: any){
    this.branchid = event.value;
  }

  handledealer(event: any){
    this.dealerid = event.value;
  }

  handledate(event: any){
    this.date = event.value;
  }
  
  addItems(){
    if (this.selectedsize.id == '')
    {
      this.showMessage('error','Select any size');
      return;
    }
    if (this.selectedtotalcarat <= 0)
    {
      this.showMessage('error','Size total carat can not be less than or equal to zero');
      return;
    }
    if (this.selectednumber.id == '')
    {
      this.showMessage('error','Select any number');
      return;
    }
    if (this.selectedcarat <= 0)
    {
      this.showMessage('error','Number carat can not be less than or equal to zero');
      return;
    }
    if (this.NumberDetails.filter(e => e.SizeId == this.selectedsize.id && e.NumberId == this.selectednumber.id).length > 0)
    {
      this.showMessage('error','Selected number exist in selected size.');
      return;
    }
    if (this.SizeDetails.filter(e => e.SizeId == this.selectedsize.id).length == 0){
      this.SizeDetails.push({
        SizeId : this.selectedsize.id,
        SizeName: this.selectedsize.name,
        TotalCarat: this.selectedtotalcarat,
        NumberDetails: []
      });

      this.summatydata.push({
        SizeId: this.selectedsize.id,
        SizeName : this.selectedsize.name,
        Percentage : 0,
        Amount : 0,
        TotCarat : this.selectedtotalcarat
      });
    }
    else{
      let index = this.SizeDetails.findIndex((item) => item.SizeId === this.selectedsize.id);
      if (index !== -1) {
        this.SizeDetails[index].SizeId = this.selectedsize.id;
        this.SizeDetails[index].SizeName = this.selectedsize.name;
        this.SizeDetails[index].TotalCarat = this.selectedtotalcarat;
        this.SizeDetails[index].NumberDetails = []
      }

      index = this.summatydata.findIndex((item) => item.SizeId === this.selectedsize.id);
      if (index !== -1) {
        this.summatydata[index].SizeId = this.selectedsize.id;
        this.summatydata[index].SizeName = this.selectedsize.name;
        this.summatydata[index].Percentage = 0;
        this.summatydata[index].Amount = 0;
        this.summatydata[index].TotCarat =  this.selectedtotalcarat;
      }
    }
    var retdata = this.pricelist.filter(e => e.sizeId == this.selectedsize.id && e.numberId == this.selectednumber.id);
      this.NumberDetails.push({
        SizeId : this.selectedsize.id,
        NumberId : this.selectednumber.id,
        Carat : this.selectedcarat,
        Rate : (retdata != null && retdata.length > 0) ? retdata[0].price : 0,
        NumberName: this.selectednumber.name,
        Amount: this.selectedcarat * ((retdata != null && retdata.length > 0) ? retdata[0].price : 0),
        Percentage : (retdata != null && retdata.length > 0) ? (this.selectedcarat / (retdata[0].price)) * 100 : 0
    });
    this.showMessage('success','Items added successfully');
    this.selectednumber = this.numbers.filter(e => e.id == '');
    this.selectedcarat = 0;
    // if (this.selectedsizeonly.findIndex((s: any) => s == this.selectedsize) < 0){
    //   this.selectedsizeonly.push(this.selectedsize);
    // }    
>>>>>>> Update Calculator
  }
  getItemsBySize(SizeId: string){
    return this.NumberDetails.filter(item => item.SizeId === SizeId);
  }

  deleteitems(item: any){
    if (confirm("Are you sure you want to delete this item?")) {
      var index = this.NumberDetails.indexOf(item);
      if (index >= 0){
        this.NumberDetails.splice(index, 1);
      }
      if (this.NumberDetails.filter(e => e.SizeId == item.SizeId).length == 0){
        var ind = this.SizeDetails.findIndex(e => e.SizeId == item.SizeId);
        if (ind >= 0){
          this.SizeDetails.splice(ind,1);
        }
        var ind1 = this.summatydata.findIndex(e => e.SizeId == item.SizeId);
        if (ind1 >= 0){
          this.summatydata.splice(ind1,1);
        }
      }
      this.calulateSummary();
    }
  }

  public getSizeCaratTotal(SizeId: string): number {
    const sizeTotCarat = this.NumberDetails.filter(item => item.SizeId === SizeId).reduce((acc, curr) => {
      return acc + (+curr.Carat);
    }, 0);
    return sizeTotCarat;
  }

  public getSizeAmountTotal(SizeId: string): number {
    const sizeTotCarat = this.NumberDetails.filter(item => item.SizeId === SizeId).reduce((acc, curr) => {
      return acc + (+curr.Carat);
    }, 0);
    const sizeTotAmount = this.NumberDetails.filter(item => item.SizeId === SizeId).reduce((acc, curr) => {
      return acc + (+curr.Amount);
    }, 0);
    return sizeTotAmount/sizeTotCarat;
  }
  

  saveData(){
    if (this.date == null)
    {
      this.showMessage('error','Select any date');
      return;
    }
    if (this.branchid.id == '')
    {
      this.showMessage('error','Select any branch');
      return;
    }
    if (this.partyid.id == '')
    {
      this.showMessage('error','Select any party');
      return;
    }
    if (this.dealerid.id == '')
    {
      this.showMessage('error','Select any broker');
      return;
    }
    if (this.netcarat <= 0)
    {
      this.showMessage('error','Netcarat can not be less than or equal to zero');
      return;
    }
    if (this.NumberDetails.length == 0)
    {
      this.showMessage('error','Carat item can not be empty');
      return;
    }
    
    if (this.SizeDetails != null && this.SizeDetails.length > 0 && this.NumberDetails != null && this.NumberDetails.length > 0)
    {
      let totCarat: number = 0;
      this.SizeDetails.forEach(e => {
        totCarat = totCarat + (+e.TotalCarat);
      }); 
      this.loading = true;    
      if (this.netcarat == totCarat){
        const userId = localStorage.getItem('userid');
        this.SizeDetails.forEach(element => {
          element.NumberDetails = this.NumberDetails.filter(e => e.SizeId == element.SizeId);
        });
        if (confirm("Are you sure want to save this item?")){
          const data = {
              Date: this.date,
              CompanyId: this.comanyid,
              FinancialYearId: '1',
              BranchId: this.branchid.id,
              PartyId: this.partyid.id,
              BrokerId: this.dealerid.id,
              NetCarat: this.netcarat,
              Note: this.note,
              IsDelete: false,
              SizeDetails: this.SizeDetails,
              UserId: userId
          };

          this.sharedService.customPostApi("Calculator/Add",data)
          .subscribe((data: any) => {
                if (data.success == true){                  
                  this.showMessage('success',data.message);
                  this.showAddSection = false;
                  this.showHistory = true;
                  this.showViewSection = false;
                  this.PageTitle = "History";
                  this.NumberDetails = [];
                  this.SizeDetails = [];
                  this.summatydata = [];
                  this.selectednumber = this.numbers.filter(e => e.id == '');
                  this.selectedsize = this.sizes.filter(e => e.Id == '');
                  this.selectedcarat = 0;
                  this.netcarat = 0;
                  this.selectedtotalcarat = 0;
                  this.summaryTotAmount = 0;
                  this.date = new Date();
                  this.branchid = this.branches.filter(e => e.id == '');
                  this.partyid = this.party.filter(e => e.id == '');
                  this.dealerid = this.dealers.filter(e => e.id == '');
                  this.note = '';
                  this.loading = false;
                  this.calculatorList();
                }
                else{
                  this.loading = false;
                  this.showMessage('error','Something went wrong...');
                }
              }, (ex: any) => {
                this.loading = false;
                this.showMessage('error',ex);
            });
        }
      }
    }
  }
  onAddIconClick() {
    this.PageTitle = "Add Details"
    this.getparty();
    this.getdealer();
    this.getbranch();
    this.getsize();
    this.getnumber();
    this.getAllNumberPrice();
    this.showAddSection = true;
    this.showViewSection = false;
    this.showHomeSection = false;
    this.showHistory = false;
  }

  showMessage(type: string, message: string){
    this.messageService.add({severity: type, summary:message});
  }
}
