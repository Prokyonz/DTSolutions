import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

import { MessageService } from 'primeng/api';
import { SharedService } from '../../common/shared.service';
import { RememberCompany } from '../../shared/component/companyselection/companyselection.component';
import { DatePipe } from '@angular/common';

interface CalculatorMaster{
  srNo: number,
  Date: Date,
  companyId: string,
  financialYearId: string,
  branchId: string,
  PartyId: string,
  PartyName: string,
  BrokerId: string,
  BrokerName: string,
  NetCarat: number | null,
  Note: string,
  sizeDetails: SizeDetails[] | null,
  UserId: string              
}

interface NumberDetails {
  sizeId: string,
  numberId: string,
  carat: number,
  rate: number,
  numberName: string,
  percentage: number,
  amount: number
  //sizename: string
}

interface SizeDetails{
  sizeId: string,
  sizeName: string,
  totalCarat: number,
  numberDetails: NumberDetails[]
}

interface Summary {
  sizeId:string,
  sizeName:string,
  percentage: number,
  rate: number,
  amount: number,
  totCarat: number 
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
  providers: []
})

export class ViewctsComponent implements OnInit{
  showViewSection:boolean = false;
  showAddSection:boolean = false;
  showHomeSection:boolean = true;
  showHistory: boolean = true;
  isAddIcon = true;
  PageTitle:string = "History";
  loading: boolean = false;
  branches: any[] = [];
  party: any[] = [];
  dealers: any[] = [];
  sizes: any[] = [];
  numbers: any[] = [];
  //pricelist: any[] = [];
  comanyid: string = "";
  NumberDetails: NumberDetails[] = [];
  SizeDetails: SizeDetails[] = [];
  summatydata: Summary[] = [];
  //selectednumber: any;
  selectedsize: any;
  selectedcarat : number = 0;
  selectedrate : number = 0;
  netcarat: any;
  selectedtotalcarat: any;
  valueTextArea: string;
  summaryTotAmount = 0;
  summaryTotRate = 0;
  date: Date = new Date();
  branchid: any = [];
  partyid: any = [];
  dealerid: any = [];
  calculatorListData: CalculatorMaster[] = [];
  note: string = '';
  calculator: CalculatorMaster;
  isSaveButton: boolean = true;
  RememberCompany: RememberCompany = new RememberCompany();
  firstDate: string | null = '';
  endDate: string | null = '';
  srNo: number = 0;
  constructor(private router: Router, private messageService: MessageService, private sharedService: SharedService, private datePipe: DatePipe) {

  }
  ngOnInit(): void {
    
    this.getCompanyData();
    let currentDate = new Date(); // Get the current date
    currentDate = new Date(currentDate.getFullYear(), currentDate.getMonth(), 1);
    this.firstDate = this.datePipe.transform(currentDate, 'yyyy-MM-dd');
    this.endDate = this.datePipe.transform(new Date(), 'yyyy-MM-dd');   
    this.calculatorList(this.firstDate, this.endDate);
    
  }

  myfunction() {
    if(this.showViewSection == true && this.isSaveButton) {
      this.showAddSection = true;
      this.showViewSection = false;
      this.showHomeSection = false;
      this.PageTitle = "Add Details";      
    }
    else{
      
      if (!this.isSaveButton){
        this.isSaveButton = true;
        this.showAddSection = false;
        this.showViewSection = false;
        this.showHomeSection = false;
        this.showHistory = true;
        this.isAddIcon = true;
        this.PageTitle = "History";
        this.clearForm();
      }
      else{
        this.router.navigate(["dashboard"]);
      }
    }
  }

  showDetails() {
    if (this.date == null)
    {
      this.showMessage('error','Select any date');
      return;
    }
    // if (this.branchid.id == '')
    // {
    //   this.showMessage('error',"Select any branch");
    //   return;
    // }
    // if (this.partyid.id == '')
    // {
    //   this.showMessage('error','Select any party');
    //   return;
    // }
    // if (this.dealerid.id == '')
    // {
    //   this.showMessage('error','Select any broker');
    //   return;
    // }
    debugger;
    if (this.netcarat <= 0)
    {
      this.showMessage('error','Netcarat can not be less than or equal to zero');
      return;
    }
    if (this.NumberDetails.length == 0)
    {
      this.showMessage('error','Number details can not be empty');
      return;
    }
    this.isSaveButton = true;
    this.PageTitle = "View Details";
    this.showAddSection = false;
    this.showViewSection = true;
    this.showHomeSection = false;
    this.showHistory = false;
    this.isAddIcon = false;
    this.SizeDetails.forEach(element => {
      element.numberDetails = this.NumberDetails.filter(e => e.sizeId == element.sizeId);
    });
    this.calulateSummary();
  }

  getCompanyData(){
    const data = localStorage.getItem("companyremember");
    if (data != null){
      this.RememberCompany = this.sharedService.JsonConvert<RememberCompany>(data)
    }
  }

  calculatorList(startDate : string | null, endDate : string | null){
    this.sharedService.customGetApi("Calculator/GetCalculatorReport?CompanyId=" + this.RememberCompany.company.id + "&FinancialYearId=" + this.RememberCompany.financialyear.id +"&FromDate=" + startDate + "&ToDate=" + endDate + "")
    .subscribe((data: any) => {
          this.calculatorListData = data;
          console.log(this.calculatorListData);
        }, (ex: any) => {
          this.showMessage('error',ex);
      });
  }

  calulateSummary(){
    this.summaryTotAmount = 0;
    this.summaryTotRate = 0;
    this.summatydata.forEach(e => {
      let filteredSize = this.NumberDetails.filter((f) => {
        return f.sizeId == e.sizeId;
      });

      let totalCts = filteredSize.reduce((acc, curr) => {
        return acc + +curr.carat;
      }, 0);
      
      let totalAmount = filteredSize.reduce((acc, curr) => {
        return acc + curr.amount;
      }, 0);  
      
      // let totalRate = filteredSize.reduce((acc, curr) => {
      //   return acc + curr.rate;
      // }, 0);  

      e.amount = totalAmount;
      e.rate = totalAmount / totalCts;
      e.percentage = (e.totCarat / this.netcarat)*100;
      this.summaryTotAmount = this.summaryTotAmount + e.amount;
      this.summaryTotRate = this.summaryTotRate + (e.rate * e.percentage);
    });
    this.summaryTotRate = this.summaryTotRate / 100;
  }

  getparty(){
    this.party = [];
    this.sharedService.customGetApi("Service/GetParty-calculator?companyid=" + this.RememberCompany.company.id).subscribe((t) => {
      if (t.success == true){
        if (t.data != null && t.data.length > 0){
          t.data = [
            //{ name: '-Select-', id: '' },
            ...t.data
          ];

          t.data.forEach((item: any) => {
            this.party.push({ name: item});
          });

          //this.party = t.data;
        }
      }
    });      
  }

  getdealer(){
    this.dealers = [];
    this.sharedService.customGetApi("Service/GetDealer-calculator?companyid=" + this.RememberCompany.company.id).subscribe((t) => {
      if (t.success == true){
        if (t.data != null && t.data.length > 0){
          t.data = [
            //{ name: '-Select-', id: '' },
            ...t.data
          ];

          t.data.forEach((item: any) => {
            this.dealers.push({ name: item});
          });

          //this.dealers = t.data;
        }
      }
    });      
  }

  getbranch(){
    this.sharedService.customGetApi("Service/GetBranch?companyid=" + this.RememberCompany.company.id).subscribe((t) => {
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
              '-Select-',
              ...t.data
            ];
          }
        }
        this.sizes = t.data;
      });      
  }

  getnumber(){
    // this.sharedService.customGetApi("Service/GetNumber").subscribe((t) => {
    //   if (t.success == true){
    //     if (t.success == true){
    //       if (t.data != null && t.data.length > 0){          
    //         t.data = [
    //           '--select--',
    //           ...t.data
    //         ];
    //       }
    //     }
    //     this.numbers = t.data;
    //   }
    // });
    
    this.sharedService.customGetApi("Service/GetPriceBySize?size=" + this.selectedsize + "&companyid=" + this.RememberCompany.company.id).subscribe((t) => {
      if (t.success == true){
        if (t.data != null && t.data.length > 0){
          this.numbers = t.data;
        }
      }
    });      
  }

  isAnyCaratGreaterThanZero(): boolean {
    return this.numbers.some(item => item.carat > 0);
  }

  // getAllNumberPrice(){
  //   this.sharedService.customGetApi("Service/GetAllNumberPrice?companyId=" + this.RememberCompany.company.id + "&categoryId=0").subscribe((t) => {
  //     if (t.success == true){
  //       debugger;
  //      this.pricelist = t.data;
  //     }
  //   });      
  // }

  handlesize(event: any) {
    debugger;
    this.selectedsize = event.value;
    var caratData = this.SizeDetails.filter(e => e.sizeId == this.selectedsize);
    if (caratData != null && caratData.length > 0){
      this.selectedtotalcarat = caratData[0].totalCarat;
    }
    else{
      this.selectedtotalcarat = null;
    }
    //this.getnumber();
    
      this.sharedService.customGetApi("Service/GetPriceBySize?size=" +  encodeURIComponent(this.selectedsize) + "&companyid=" + this.RememberCompany.company.id).subscribe((t) => {
        if (t.success == true){
          if (t.data != null && t.data.length > 0){
            this.numbers = t.data;
            if (this.NumberDetails != null && this.NumberDetails.length > 0 && this.NumberDetails.filter(e => e.sizeId == this.selectedsize).length > 0){
              this.NumberDetails.filter(e => e.sizeId == this.selectedsize).forEach(e => {
                this.numbers.find(z => z.numberName == e.numberId).carat = e.carat;
                this.numbers.find(z => z.numberName == e.numberId).price = e.rate;
                this.numbers.find(z => z.numberName == e.numberId).total = e.amount;
              });
            }
          }
        }
      });    
    
  }

  calculateTotal(item: any) {
    // Assuming you want to calculate the total based on CTS and Rate
    item.total = item.carat * item.price;
  }

  handlerate(event: any) {
    // var retdata = this.pricelist.filter(e => e.sizeName == this.selectedsize && e.numberId == event.value.id);
    // this.selectedrate = (retdata != null && retdata.length > 0) ? retdata[0].price : 0;
    // this.selectedsize = event.value;
    // var caratData = this.SizeDetails.filter(e => e.sizeId == this.selectedsize.id);
    // if (caratData != null && caratData.length > 0){
    //   this.selectedtotalcarat = caratData[0].totalCarat;
    // }
    // else{
    //   this.selectedtotalcarat = 0;
    // }
  }

  viewdata(){
    
    //console.log(this.caratData);
  }

  onSeach(event: any) {
    const StartDate = this.datePipe.transform(event.startDate, 'yyyy-MM-dd');
    const EndDate = this.datePipe.transform(event.endDate, 'yyyy-MM-dd');
    this.firstDate = StartDate;
    this.endDate = EndDate;
    this.calculatorList(StartDate, EndDate)
  }

  // handlenumber(event: any) {
  //   this.selectednumber = event.value.number;
  // }
  handleparty(event: any){
    this.partyid = event.value;
  }

  handlebranch(event: any){
    debugger;
    this.branchid = event.value;
  }

  handledealer(event: any){
    this.dealerid = event.value;
  }

  handledate(event: any){
    this.date = event.value;
  }
  
  addItems(){
    if (this.selectedsize == null || this.selectedsize == '')
    {
      this.showMessage('error','Select any size');
      return;
    }
    if (this.selectedtotalcarat <= 0)
    {
      this.showMessage('error','Size total carat can not be less than or equal to zero');
      return;
    }
    if (this.numbers != null && this.numbers.length > 0 && this.numbers.filter(e => e.carat == 0 ).length == this.numbers.length){
      this.showMessage('error','add carat in any number');
      return;
    }
    if (this.SizeDetails.filter(e => e.sizeId == this.selectedsize).length == 0){
      this.SizeDetails.push({
        sizeId : this.selectedsize,
        sizeName: this.selectedsize,
        totalCarat: this.selectedtotalcarat,
        numberDetails: []
      });

      this.summatydata.push({
        sizeId: this.selectedsize,
        sizeName : this.selectedsize,
        percentage : 0,
        amount : 0,
        rate: 0,
        totCarat : this.selectedtotalcarat
      });
    }
    else{
        let index = this.SizeDetails.findIndex((item) => item.sizeId === this.selectedsize);
        if (index !== -1) {
          this.SizeDetails[index].sizeId = this.selectedsize;
          this.SizeDetails[index].sizeName = this.selectedsize;
          this.SizeDetails[index].totalCarat = this.selectedtotalcarat;
          this.SizeDetails[index].numberDetails = []
        }
  
        index = this.summatydata.findIndex((item) => item.sizeId === this.selectedsize);
        if (index !== -1) {
          this.summatydata[index].sizeId = this.selectedsize;
          this.summatydata[index].sizeName = this.selectedsize;
          this.summatydata[index].percentage = 0;
          this.summatydata[index].rate = 0;
          this.summatydata[index].amount = 0;
          this.summatydata[index].totCarat =  this.selectedtotalcarat;
        }
    }

    this.NumberDetails = this.NumberDetails.filter(item => item.sizeId !== this.selectedsize);
    this.numbers.forEach(e => {
      debugger;
      if (e.carat > 0){
        this.NumberDetails.push({
          sizeId : this.selectedsize,
          numberId : e.numberName,
          carat : e.carat,
          rate : e.price,
          numberName: e.numberName,
          amount: e.total,
          //sizename: this.selectedsize,
          percentage : (e.carat / this.selectedtotalcarat) * 100
        });
      }
    });

    this.numbers = [];

    // if (this.selectednumber.id == '')
    // {
    //   this.showMessage('error','Select any number');
    //   return;
    // }
    // if (this.selectedcarat <= 0)
    // {
    //   this.showMessage('error','Number carat can not be less than or equal to zero');
    //   return;
    // }
    // if (this.selectedrate <= 0)
    // {
    //   this.showMessage('error','Number rate can not be less than or equal to zero');
    //   return;
    // }

    // && e.numberId == this.selectednumber.id

    // if (this.NumberDetails.filter(e => e.sizeId == this.selectedsize.id).length > 0)
    // {
    //   this.showMessage('error','Selected number exist in selected size.');
    //   return;
    // }
    // if (this.SizeDetails.filter(e => e.sizeId == this.selectedsize).length == 0){
    //   this.SizeDetails.push({
    //     sizeId : this.selectedsize.id,
    //     sizeName: this.selectedsize.name,
    //     totalCarat: this.selectedtotalcarat,
    //     numberDetails: []
    //   });

    //   this.summatydata.push({
    //     sizeId: this.selectedsize.id,
    //     sizeName : this.selectedsize.name,
    //     percentage : 0,
    //     amount : 0,
    //     rate: 0,
    //     totCarat : this.selectedtotalcarat
    //   });
    // }
    // else{
    //   let index = this.SizeDetails.findIndex((item) => item.sizeId === this.selectedsize.id);
    //   if (index !== -1) {
    //     this.SizeDetails[index].sizeId = this.selectedsize.id;
    //     this.SizeDetails[index].sizeName = this.selectedsize.name;
    //     this.SizeDetails[index].totalCarat = this.selectedtotalcarat;
    //     this.SizeDetails[index].numberDetails = []
    //   }

    //   index = this.summatydata.findIndex((item) => item.sizeId === this.selectedsize.id);
    //   if (index !== -1) {
    //     this.summatydata[index].sizeId = this.selectedsize.id;
    //     this.summatydata[index].sizeName = this.selectedsize.name;
    //     this.summatydata[index].percentage = 0;
    //     this.summatydata[index].rate = 0;
    //     this.summatydata[index].amount = 0;
    //     this.summatydata[index].totCarat =  this.selectedtotalcarat;
    //   }
    // }
   
    // this.NumberDetails.push({
    //   sizeId : this.selectedsize.id,
    //   //numberId : this.selectednumber.id,
    //   carat : this.selectedcarat,
    //   rate : this.selectedrate,
    //   numberName: '',
    //   amount: this.selectedcarat * this.selectedrate,
    //   percentage : (this.selectedcarat / this.selectedtotalcarat) * 100
    // });
    debugger;
    

    this.showMessage('success','Items added successfully');
    this.selectedtotalcarat = 0;
    this.selectedsize = "-Select-"
    //this.selectednumber = this.numbers.filter(e => e.id == '');
    //this.selectedcarat = 0;
    //this.selectedrate = 0;
    // if (this.selectedsizeonly.findIndex((s: any) => s == this.selectedsize) < 0){
    //   this.selectedsizeonly.push(this.selectedsize);
    // }    
  }
  getItemsBySize(sizeId: string){
    return this.NumberDetails.filter(item => item.sizeId === sizeId);
  }

  deleteitems(item: any){
    if (confirm("Are you sure you want to delete this item?")) {
      var index = this.NumberDetails.indexOf(item);
      if (index >= 0){
        this.NumberDetails.splice(index, 1);
      }
      if (this.NumberDetails.filter(e => e.sizeId == item.sizeId).length == 0){
        var ind = this.SizeDetails.findIndex(e => e.sizeId == item.sizeId);
        if (ind >= 0){
          this.SizeDetails.splice(ind,1);
        }
        var ind1 = this.summatydata.findIndex(e => e.sizeId == item.sizeId);
        if (ind1 >= 0){
          this.summatydata.splice(ind1,1);
        }
      }
      this.calulateSummary();
    }
  }

  edititem(items: any) {
    this.onAddIconClick();  
    this.PageTitle = "Edit Item";
    this.srNo = items.srNo;
    setTimeout(() => {
      this.date = new Date(items.date);
      this.netcarat = items.netCarat;
      this.note = items.note;
      
      setTimeout(() => {
        this.partyid = items.partyName;
        this.dealerid = items.brokerName;
        //this.partyid.id = items.partyId;
        this.branchid.id = items.branchId;
        this.branchid.name = items.branchName;
        // this.dealerid.id = items.brokerId;
        // this.dealerid.name = items.brokerName;


        this.calculatorListData.filter(e => e.srNo == items.srNo && e.companyId == items.companyId && e.branchId == items.branchId &&
          e.financialYearId == items.financialYearId).forEach(e => {
            debugger;
            this.selectedsize =  e.sizeDetails != null ? (e.sizeDetails.length > 0 ? e.sizeDetails[0].sizeId : '') : '';
            this.selectedtotalcarat = e.sizeDetails != null ? (e.sizeDetails.length > 0 ? e.sizeDetails[0].totalCarat : '') : '';
            e.sizeDetails?.forEach(item => {
              
              this.SizeDetails.push(item);
              this.summatydata.push({
                sizeId: item.sizeId,
                sizeName: item.sizeId,
                percentage: 0,
                amount: 0,
                rate: 0,
                totCarat: item.totalCarat
              });
              item.numberDetails.forEach(s => {
                this.NumberDetails.push({
                  sizeId: s.sizeId,
                  numberId: s.numberId,
                  carat: s.carat,
                  rate: s.rate,
                  numberName: s.numberId,
                  amount: s.amount,
                  percentage: s.percentage
                });
              });
          });           
        });
        
        this.sharedService.customGetApi("Service/GetPriceBySize?size=" +  encodeURIComponent(this.selectedsize) + "&companyid=" + this.RememberCompany.company.id).subscribe((t) => {
          if (t.success == true){
            if (t.data != null && t.data.length > 0){
              this.numbers = t.data;
              if (this.NumberDetails != null && this.NumberDetails.length > 0 && this.NumberDetails.filter(e => e.sizeId == this.selectedsize).length > 0){
                this.NumberDetails.filter(f => f.sizeId == this.selectedsize).forEach(f => {
                  this.numbers.find(z => z.numberName == f.numberId).carat = f.carat;
                  this.numbers.find(z => z.numberName == f.numberId).price = f.rate;
                  this.numbers.find(z => z.numberName == f.numberId).total = f.amount;
                });
              }
            }
          }
        });


      }, 1000); // Adjust the delay as needed
    }, 500);
  }
  

  viewitem(items: any){
    debugger;
    this.date = new Date(items.date);
    this.branchid.id = items.branchId;
    this.branchid.name = items.branchName;
    this.dealerid.id = items.brokerId;
    this.dealerid.name = items.brokerName;
    this.partyid.id = items.partyId;
    this.partyid.name = items.partyName;
    
    this.netcarat = items.netCarat;
    this.note = items.note;
    this.calculatorListData.filter(e => e.srNo == items.srNo && e.companyId == items.companyId && e.branchId == items.branchId &&
        e.financialYearId == items.financialYearId).forEach(e => {
        e.sizeDetails?.forEach(item => {
        this.SizeDetails.push(item);
        this.summatydata.push({
          sizeId: item.sizeId,
          sizeName : item.sizeId,
          percentage : 0,
          amount : 0,
          rate : 0,
          totCarat : item.totalCarat
        });
        item.numberDetails.forEach(s => {
          this.NumberDetails.push({
            sizeId : s.sizeId,
            numberId : s.numberId,
            carat : s.carat,
            rate : s.rate,
            numberName: s.numberId,
            amount: s.amount,
            percentage : s.percentage
          });
        })
      })
    });
    this.showDetails();
    this.isSaveButton = false;
  }

  public getSizeCaratTotal(sizeId: string): number {
    const sizeTotCarat = this.NumberDetails.filter(item => item.sizeId === sizeId).reduce((acc, curr) => {
      return acc + (+curr.carat);
    }, 0);
    return sizeTotCarat;
  }

  public getSizeAmountTotal(sizeId: string): number {
    const sizeTotCarat = this.NumberDetails.filter(item => item.sizeId === sizeId).reduce((acc, curr) => {
      return acc + (+curr.carat);
    }, 0);
    const sizeTotAmount = this.NumberDetails.filter(item => item.sizeId === sizeId).reduce((acc, curr) => {
      return acc + (+curr.amount);
    }, 0);
    return sizeTotAmount/sizeTotCarat;
  }
  

  saveData(){
    if (this.date == null)
    {
      this.showMessage('error','Select any date');
      return;
    }
    // if (this.branchid.id == '')
    // {
    //   this.showMessage('error','Select any branch');
    //   return;
    // }
    // if (this.partyid.id == '')
    // {
    //   this.showMessage('error','Select any party');
    //   return;
    // }
    // if (this.dealerid.id == '')
    // {
    //   this.showMessage('error','Select any broker');
    //   return;
    // }
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
        totCarat = totCarat + (+e.totalCarat);
      }); 
      this.loading = true;    
      //if (this.netcarat == totCarat){
        const userId = localStorage.getItem('userid');
        this.SizeDetails.forEach(element => {
          element.numberDetails = this.NumberDetails.filter(e => e.sizeId == element.sizeId);
        });
        if (confirm("Are you sure want to save this item?")){
          const data = {
              SrNo: this.srNo,
              Date: this.date,
              CompanyId: this.RememberCompany.company.id,
              FinancialYearId: this.RememberCompany.financialyear.id,
              BranchId: this.branchid.id,
              PartyId: this.partyid.name != null ? this.partyid.name : this.partyid, //this.partyid.id, removed the property becase we are storing the actual name entered by user.
              BrokerId: this.dealerid.name != null ? this.dealerid.name : this.dealerid, //this.dealerid.id, removed the property becase we are storing the actual name entered by user.
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
                  this.isAddIcon = true;
                  this.showViewSection = false;
                  this.PageTitle = "History";
                  this.clearForm();
                  this.calculatorList(this.firstDate, this.endDate);
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
      // }
      // else{
      //   this.loading = false;
      //   this.showMessage('error','Net carat and Total carat always same.');
      // }
    }
  }
  onAddIconClick() {
    this.PageTitle = "Add Details"
    this.isSaveButton = true;
    this.getparty();
    this.getdealer();
    this.getbranch();
    this.getsize();
    //this.getnumber();
    //this.getAllNumberPrice();
    this.showAddSection = true;
    this.showViewSection = false;
    this.showHomeSection = false;
    this.showHistory = false;
    this.isAddIcon = false;
  }

  showMessage(type: string, message: string){
    this.messageService.add({severity: type, summary:message});
  }

  clearForm(){
    this.NumberDetails = [];
    this.SizeDetails = [];
    this.summatydata = [];
    //this.selectednumber = this.numbers.filter(e => e.id == '');
    this.selectedsize = this.sizes.filter(e => e.Id == '');
    this.selectedcarat = 0;
    this.selectedrate = 0;
    this.netcarat = null;
    this.selectedtotalcarat = null;
    this.summaryTotAmount = 0;
    this.date = new Date();
    this.branchid = this.branches.filter(e => e.id == '');
    this.partyid = this.party.filter(e => e.id == '');
    this.dealerid = this.dealers.filter(e => e.id == '');
    this.note = '';
    this.loading = false;
    this.srNo = 0;
  }
}
