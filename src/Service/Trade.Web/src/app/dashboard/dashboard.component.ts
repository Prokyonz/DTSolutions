import { Component, OnInit, Inject } from '@angular/core';
import { SharedService } from '../common/shared.service';
import { Message, MessageService } from 'primeng/api';
import { DatePipe } from '@angular/common';
import { RememberCompany } from '../shared/component/companyselection/companyselection.component';
import { LOCALE_ID, NgModule } from '@angular/core';
import { formatNumber } from '@angular/common';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.scss']
})

export class DashboardComponent implements OnInit {

  dashboardData: any;
  firstDate: string | null = '';
  endDate: string | null = '';
  RememberCompany: RememberCompany = new RememberCompany();
  purchaseData: any;
  salesData: any;
  paymentData: any;
  receiptData: any;

  constructor(private sharedService: SharedService, private messageService: MessageService,
    private datePipe: DatePipe,  @Inject(LOCALE_ID) public locale: string){}

  ngOnInit(): void {
    try {
      this.getCompanyData();
      let currentDate = new Date(); // Get the current date
      currentDate = new Date(currentDate.getFullYear(), currentDate.getMonth(), -1200);
      this.firstDate = this.datePipe.transform(currentDate, 'yyyy-MM-dd');
      this.endDate = this.datePipe.transform(new Date(), 'yyyy-MM-dd');   
      
      this.sharedService.customGetApi("Report/GetPurchaseTotal?CompanyId=" + this.RememberCompany.company.id + "&FinancialYearId=" + this.RememberCompany.financialyear.id +"&FromDate=" + this.firstDate + "&ToDate=" + this.endDate + "")
      .subscribe((data: any) => {
          this.purchaseData = formatNumber(data.data.totalAmount, this.locale, '7.1-5')
            console.log("this is the first thing");
          }, (ex: any) => {
            console.log(ex);
            this.showMessage('error',ex);
      });

      this.sharedService.customGetApi("Report/GetSaleReport?CompanyId=" + this.RememberCompany.company.id + "&FinancialYearId=" + this.RememberCompany.financialyear.id +"&FromDate=" + this.firstDate + "&ToDate=" + this.endDate + "")
      .subscribe((data: any) => {
          this.salesData = data.data.totalAmount;
            console.log("this is the first thing");
          }, (ex: any) => {
            console.log(ex);
            this.showMessage('error',ex);
      });

      this.sharedService.customGetApi("Report/GetPaymentOrReceiptTotal?CompanyId=" + this.RememberCompany.company.id + "&FinancialYearId=" + this.RememberCompany.financialyear.id +"&FromDate=" + this.firstDate + "&ToDate=" + this.endDate + "")
      .subscribe((data: any) => {
          this.paymentData = data.data.totalAmount;
          }, (ex: any) => {
            console.log(ex);
            this.showMessage('error',ex);
      });

      this.sharedService.customGetApi("Report/GetPaymentOrReceiptTotal?CompanyId=" + this.RememberCompany.company.id + "&FinancialYearId=" + this.RememberCompany.financialyear.id +"&FromDate=" + this.firstDate + "&ToDate=" + this.endDate + "")
      .subscribe((data: any) => {
          this.receiptData = data.data.totalAmount;
            console.log("this is the first thing");
          }, (ex: any) => {
            console.log(ex);
            this.showMessage('error',ex);
      });


    }catch(e) {
      console.log(e);
    }
  }
  
  openMenu() {

  }

  onSeach(event:any) {
    console.log(event);
  }

  showMessage(type: string, message: string){
    this.messageService.add({severity: type, summary:message});
  }

  getCompanyData(){    
    try {
      const data = localStorage.getItem("companyremember");      
      if (data != null) {
        this.RememberCompany = this.sharedService.JsonConvert<RememberCompany>(data)
      }
    } catch(e) {
      alert(JSON.stringify(e));
    }
  }

}
