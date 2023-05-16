import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ConfirmEventType, ConfirmationService } from 'primeng/api';
import { Table } from 'primeng/table';
import { SharedService } from '../common/shared.service';
import { RememberCompany } from '../shared/component/companyselection/companyselection.component';
import { Message, MessageService } from 'primeng/api';
import { environment } from '../environments';

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
  styleUrls: ['./report.component.scss'],
  providers: [ConfirmationService]
})

export class ReportComponent implements OnInit {

  PageTitle: string = "Purchase Report";
  reportIndex: number = 0;
  RememberCompany: RememberCompany = new RememberCompany();
  PurchaseReportList : any[];
  columnArray: any[] = [];
  dataArray: any[];
  visible: boolean = false;
  loading: boolean = true;

  constructor(private rote: Router, private activateRoute: ActivatedRoute,private sharedService: SharedService, private messageService: MessageService) {
    this.reportIndex = +activateRoute.snapshot.params['id'];
    switch (this.reportIndex)
    {
      case 1:
        this.PageTitle = "Purchase Report"
        this.columnArray = [
          {"displayName":"Date","dataType":"Date","fieldName":"date"},
          {"displayName":"Branch Name","dataType":"text","fieldName":"branchName","minWidth":"15"},
          {"displayName":"Slip No","dataType":"numeric","fieldName":"slipNo"},          
          {"displayName":"Party Name","dataType":"text","fieldName":"partyName","minWidth":"15"},
          {"displayName":"Broker Name","dataType":"text","fieldName":"brokerName","minWidth":"15"},
          {"displayName":"Kapan Name","dataType":"text","fieldName":"kapanName","minWidth":"15"},
          {"displayName":"Net Cts","dataType":"numeric","fieldName":"netWeight"},
          {"displayName":"Buy Rate","dataType":"numeric","fieldName":"buyingRate"},
          {"displayName":"Less","dataType":"numeric","fieldName":"lessWeight"},
          {"displayName":"CVD Amt","dataType":"numeric","fieldName":"cvdAmount"},
          {"displayName":"Due Days","dataType":"numeric","fieldName":"dueDays"},
          {"displayName":"Pay Days","dataType":"numeric","fieldName":"paymentDays"},
          {"displayName":"Due Date","dataType":"Date","fieldName":"dueDate"},
          {"displayName":"Total","dataType":"numeric","fieldName":"total"},
          {"displayName":"Remarks","dataType":"text","fieldName":"remarks","minWidth":"15"},
          {"displayName":"Message","dataType":"text","fieldName":"message","minWidth":"15"},
          {"displayName":"Action","dataType":"approve","fieldName":"purId","minWidth":"10"},
          {"displayName":"Action","dataType":"reject","fieldName":"purId","minWidth":"10"},
          // {"displayName":"Approval Type","dataType":"boolean","fieldName":"approvalType","minWidth":"3"},
          // {"displayName":"Action","dataType":"action","fieldName":"approvalType","minWidth":"3"},
          // {"displayName":"Action","dataType":"action","fieldName":"approvalType","minWidth":"3"}
        ]
        break;
      case 2:
        this.PageTitle = "Sales Report"
        this.columnArray = [
          {"displayName":"Date","dataType":"Date","fieldName":"date"},
          {"displayName":"Branch Name","dataType":"text","fieldName":"branchName","minWidth":"15"},
          {"displayName":"Slip No","dataType":"numeric","fieldName":"slipNo"},          
          {"displayName":"Party Name","dataType":"text","fieldName":"partyName","minWidth":"15"},
          {"displayName":"Broker Name","dataType":"text","fieldName":"brokerName","minWidth":"15"},
          {"displayName":"Kapan Name","dataType":"text","fieldName":"kapanName","minWidth":"15"},
          {"displayName":"Net Cts","dataType":"numeric","fieldName":"netWeight"},
          {"displayName":"Sale Rate","dataType":"numeric","fieldName":"saleRate"},
          {"displayName":"Less","dataType":"numeric","fieldName":"lessWeight"},
          {"displayName":"CVD Amount","dataType":"numeric","fieldName":"cvdAmount"},
          {"displayName":"Pay Days","dataType":"numeric","fieldName":"paymentDays"},
          {"displayName":"Due Days","dataType":"numeric","fieldName":"dueDays"},          
          {"displayName":"Due Date","dataType":"Date","fieldName":"dueDate"},
          {"displayName":"Total","dataType":"numeric","fieldName":"total"},
          {"displayName":"Remarks","dataType":"text","fieldName":"remarks","minWidth":"15"},
          {"displayName":"Message","dataType":"text","fieldName":"message","minWidth":"15"}                   
          // {"displayName":"Approval Type","dataType":"boolean","fieldName":"approvalType","minWidth":"3"}
        ];
        break;
      case 3:
        this.PageTitle = "Payment Report"
        this.columnArray = [
          {"displayName":"Date","dataType":"Date","fieldName":"entryDate"},
          {"displayName":"To Party","dataType":"text","fieldName":"toName","minWidth":"15"},
          {"displayName":"From Party","dataType":"text","fieldName":"fromName","minWidth":"15"},
          {"displayName":"Amount","dataType":"numeric","fieldName":"amount"},
          {"displayName":"Cheque No","dataType":"text","fieldName":"chequeNo"},
          {"displayName":"Cheque Date","dataType":"Date","fieldName":"chequeDate","minWidth":"15"},
          {"displayName":"Remarks","dataType":"text","fieldName":"remarks","minWidth":"15"},
        ];
        break;
      case 4:
        this.PageTitle = "Receipt Report"
        this.columnArray = [
          {"displayName":"Date","dataType":"Date","fieldName":"entryDate"},
          {"displayName":"From Party","dataType":"text","fieldName":"fromName","minWidth":"15"},
          {"displayName":"To Party","dataType":"text","fieldName":"toName","minWidth":"15"},          
          {"displayName":"Amount","dataType":"numeric","fieldName":"amount"},
          {"displayName":"Cheque No","dataType":"text","fieldName":"chequeNo"},
          {"displayName":"Cheque Date","dataType":"Date","fieldName":"chequeDate","minWidth":"15"},
          {"displayName":"Remarks","dataType":"text","fieldName":"remarks","minWidth":"15"},
        ];
        break;
      default:
        break;
    }
  }

  ngOnInit() {
    this.loading = false;
    this.getCompanyData();
    this.purchseReport();
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

  onSeach(event: any) {
    console.log(event);
  }

  purchseReport(){
    this.loading = true;
    switch (this.reportIndex)
    {
      case 1:
        this.sharedService.customGetApi("Report/GetPurchaseReport?CompanyId=" + this.RememberCompany.company.id + "&FinancialYearId=" + this.RememberCompany.financialyear.id +"&FromDate=2022-05-01&ToDate=2023-05-20")
        .subscribe((data: any) => {
              this.PurchaseReportList = data.data;
              this.loading = false;
              console.log(this.PurchaseReportList);
            }, (ex: any) => {
              this.loading = false;
              this.showMessage('error',ex);
          });
        break;
        case 2:
          this.sharedService.customGetApi("Report/GetSaleReport?CompanyId=" + this.RememberCompany.company.id + "&FinancialYearId=" + this.RememberCompany.financialyear.id +"&FromDate=2022-05-01&ToDate=2023-05-20")
          .subscribe((data: any) => {
                this.PurchaseReportList = data.data;
                this.loading = false;
                console.log(this.PurchaseReportList);
              }, (ex: any) => {
                this.loading = false;
                this.showMessage('error',ex);
            });
          break;
        case 3:
          this.sharedService.customGetApi("Report/GetPaymentReport?CompanyId=" + this.RememberCompany.company.id + "&FinancialYearId=" + this.RememberCompany.financialyear.id +"&FromDate=2022-05-01&ToDate=2023-05-20")
          .subscribe((data: any) => {
                this.PurchaseReportList = data.data;
                this.loading = false;
                console.log(this.PurchaseReportList);
              }, (ex: any) => {
                this.loading = false;
                this.showMessage('error',ex);
            });
        break;
        case 4:
          this.sharedService.customGetApi("Report/GetReceiptReport?CompanyId=" + this.RememberCompany.company.id + "&FinancialYearId=" + this.RememberCompany.financialyear.id +"&FromDate=2022-05-01&ToDate=2023-05-20")
          .subscribe((data: any) => {
                this.PurchaseReportList = data.data;
                this.loading = false;
                console.log(this.PurchaseReportList);
              }, (ex: any) => {
                this.loading = false;
                this.showMessage('error',ex);
            });
        break;
      default:
        break;
    }
    
  }

  showMessage(type: string, message: string){
    this.messageService.add({severity: type, summary:message});
  }

  getCompanyData(){    
    const data = localStorage.getItem("companyremember");
    if (data != null){
      this.RememberCompany = this.sharedService.JsonConvert<RememberCompany>(data)
    }
  }

    onApproveClick(reportIndex: number, item : any) {
      debugger;
        console.log("clicked");
        this.visible = true;
    }
}
