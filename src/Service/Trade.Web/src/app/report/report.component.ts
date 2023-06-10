import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ConfirmEventType, ConfirmationService } from 'primeng/api';
import { Table } from 'primeng/table';
import { SharedService } from '../common/shared.service';
import { RememberCompany } from '../shared/component/companyselection/companyselection.component';
import { Message, MessageService } from 'primeng/api';
import { DatePipe } from '@angular/common';
import * as FileSaver from 'file-saver';
import 'jspdf-autotable';

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
  providers: [ConfirmationService, MessageService]
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
  dialogReportIndex: number = 0;
  ApproveRejectComment: string = '';
  ApproveRejectStatus: number = 0;
  reportItemId: string = '';
  firstDate: string | null = '';
  endDate: string | null = '';
  isFilerRequired: boolean = true;

  constructor(private rote: Router, private activateRoute: ActivatedRoute,
      private sharedService: SharedService, private messageService: MessageService, private datePipe: DatePipe) {
    this.reportIndex = +activateRoute.snapshot.params['id'];
    switch (this.reportIndex)
    {
      case 1:
        this.PageTitle = "Purchase Report"
        this.columnArray = [
          {"displayName":"Date","dataType":"Date","fieldName":"date","ishidefilter":true},
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
          {"displayName":"Due Date","dataType":"Date","fieldName":"dueDate","ishidefilter":true},
          {"displayName":"Total","dataType":"numeric","fieldName":"total"},
          {"displayName":"Remarks","dataType":"text","fieldName":"remarks","minWidth":"15"},
          {"displayName":"Message","dataType":"text","fieldName":"message","minWidth":"15"},
          {"displayName":"Approval Status","dataType":"text","fieldName":"approvalType"},          
          {"displayName":"Approve","dataType":"text","fieldName":"approvalType","minWidth":"10","reportid":"purId","ishidefilter":true},
          {"displayName":"Reject","dataType":"text","fieldName":"approvalType","minWidth":"10","reportid":"purId","ishidefilter":true}
          // {"displayName":"Approval Type","dataType":"boolean","fieldName":"approvalType","minWidth":"3"},
          // {"displayName":"Action","dataType":"action","fieldName":"approvalType","minWidth":"3"},
          // {"displayName":"Action","dataType":"action","fieldName":"approvalType","minWidth":"3"}
        ]
        break;
      case 2:
        this.PageTitle = "Sales Report"
        this.columnArray = [
          {"displayName":"Date","dataType":"Date","fieldName":"date","ishidefilter":true},
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
          {"displayName":"Due Date","dataType":"Date","fieldName":"dueDate","ishidefilter":true},
          {"displayName":"Total","dataType":"numeric","fieldName":"total"},
          {"displayName":"Remarks","dataType":"text","fieldName":"remarks","minWidth":"15"},
          {"displayName":"Message","dataType":"text","fieldName":"message","minWidth":"15"},  
          {"displayName":"Approval Status","dataType":"text","fieldName":"approvalType"},            
          {"displayName":"Approve","dataType":"text","fieldName":"approvalType","minWidth":"10","reportid":"id","ishidefilter":true},
          {"displayName":"Reject","dataType":"text","fieldName":"approvalType","minWidth":"10","reportid":"id","ishidefilter":true}              
          // {"displayName":"Approval Type","dataType":"boolean","fieldName":"approvalType","minWidth":"3"}
        ];
        break;
      case 3:
        this.PageTitle = "Payment Report"
        this.columnArray = [
          {"displayName":"Date","dataType":"Date","fieldName":"entryDate", "ishidefilter":true},
          {"displayName":"To Party","dataType":"text","fieldName":"toName","minWidth":"15"},
          {"displayName":"From Party","dataType":"text","fieldName":"fromName","minWidth":"15"},
          {"displayName":"Amount","dataType":"numeric","fieldName":"amount"},
          {"displayName":"Cheque No","dataType":"text","fieldName":"chequeNo"},
          {"displayName":"Cheque Date","dataType":"Date","fieldName":"chequeDate","minWidth":"15", "ishidefilter":true},
          {"displayName":"Remarks","dataType":"text","fieldName":"remarks","minWidth":"15"},  
          {"displayName":"Approval Status","dataType":"text","fieldName":"approvalType"},         
          {"displayName":"Approve","dataType":"text","fieldName":"approvalType","minWidth":"10","reportid":"groupId","ishidefilter":true},
          {"displayName":"Reject","dataType":"text","fieldName":"approvalType","minWidth":"10","reportid":"groupId","ishidefilter":true}
        ];
        break;
      case 4:
        this.PageTitle = "Receipt Report"
        this.columnArray = [
          {"displayName":"Date","dataType":"Date","fieldName":"entryDate", "ishidefilter":true},
          {"displayName":"From Party","dataType":"text","fieldName":"fromName","minWidth":"15"},
          {"displayName":"To Party","dataType":"text","fieldName":"toName","minWidth":"15"},          
          {"displayName":"Amount","dataType":"numeric","fieldName":"amount"},
          {"displayName":"Cheque No","dataType":"text","fieldName":"chequeNo"},
          {"displayName":"Cheque Date","dataType":"Date","fieldName":"chequeDate","minWidth":"15", "ishidefilter":true},
          {"displayName":"Remarks","dataType":"text","fieldName":"remarks","minWidth":"15"},
          {"displayName":"Approval Status","dataType":"text","fieldName":"approvalType"}, 
          {"displayName":"Approve","dataType":"text","fieldName":"approvalType","minWidth":"10","reportid":"groupId","ishidefilter":true},
          {"displayName":"Reject","dataType":"text","fieldName":"approvalType","minWidth":"10","reportid":"groupId","ishidefilter":true}
        ];
        break;
      case 5:
          this.PageTitle = "Contra Payment Report"
          this.columnArray = [
            {"displayName":"Date","dataType":"Date","fieldName":"entryDate", "ishidefilter":true},
            {"displayName":"From Party","dataType":"text","fieldName":"fromPartyName","minWidth":"15"},
            {"displayName":"To Party","dataType":"text","fieldName":"toPartyName","minWidth":"15"},                     
            {"displayName":"Cheque No","dataType":"text","fieldName":"chequeNo"},
            {"displayName":"Cheque Date","dataType":"Date","fieldName":"chequeDate","minWidth":"15", "ishidefilter":true},
            {"displayName":"Amount","dataType":"numeric","fieldName":"amount"},
            {"displayName":"Remarks","dataType":"text","fieldName":"remarks","minWidth":"15"},
          ];
          break;
      case 6:
        this.PageTitle = "Expense Report"
        this.columnArray = [
          {"displayName":"Date","dataType":"Date","fieldName":"entryDate", "ishidefilter":true},
          {"displayName":"SrNo","dataType":"numeric","fieldName":"srNo"},
          {"displayName":"Branch Name","dataType":"text","fieldName":"branchName","minWidth":"15"},                     
          {"displayName":"Amount","dataType":"numeric","fieldName":"amount"},
          {"displayName":"Remarks","dataType":"text","fieldName":"remarks","minWidth":"20"},         
        ];
        break;
      case 7:
          this.PageTitle = "Loan Report"
          this.isFilerRequired = false;
          this.columnArray = [
            {"displayName":"Sr","dataType":"numeric","fieldName":"sr"},
            {"displayName":"Party Name","dataType":"text","fieldName":"partyName","minWidth":"15"},
            {"displayName":"Cash/Bank Party Name","dataType":"text","fieldName":"cashBankName","minWidth":"25"},
            {"displayName":"Amount","dataType":"numeric","fieldName":"amount"},
            {"displayName":"Duration Type","dataType":"text","fieldName":"duratonType","minWidth":"15"},
            {"displayName":"Start Date","dataType":"Date","fieldName":"startDate", "ishidefilter":true},            
            {"displayName":"End Date","dataType":"Date","fieldName":"endDate", "ishidefilter":true}, 
            {"displayName":"Interest Rate","dataType":"numeric","fieldName":"interestRate"},
            {"displayName":"Total Interest","dataType":"numeric","fieldName":"totalInterest"},  
            {"displayName":"Net Amount","dataType":"numeric","fieldName":"netAmount"},
            {"displayName":"Updated Date","dataType":"Date","fieldName":"updatedDate", "ishidefilter":true}
          ];
        break;
      case 8:
        this.PageTitle = "Mixed Report"
        this.columnArray = [
          {"displayName":"Date","dataType":"Date","fieldName":"entryDate", "ishidefilter":true},
          {"displayName":"From Party Name","dataType":"text","fieldName":"fromName","minWidth":"15"},
          {"displayName":"To Name","dataType":"text","fieldName":"toName","minWidth":"15"},
          {"displayName":"Remarks","dataType":"text","fieldName":"remarks","minWidth":"20"}, 
          {"displayName":"Debit","dataType":"numeric","fieldName":"debit","minWidth":"15"},
          {"displayName":"Credit","dataType":"numeric","fieldName":"credit","minWidth":"15"},                  
        ];
        break;
      case 9:
        this.PageTitle = "PF Report"
        this.isFilerRequired = false;
        this.columnArray = [
          {"displayName":"Type","dataType":"text","fieldName":"type"},
          {"displayName":"Party Name","dataType":"text","fieldName":"partyName","minWidth":"15"},
          {"displayName":"Broker Name","dataType":"text","fieldName":"brokerName","minWidth":"15"},
          {"displayName":"Size","dataType":"numeric","fieldName":"size","minWidth":"15"}, 
          {"displayName":"Number","dataType":"numeric","fieldName":"number","minWidth":"15"},
          {"displayName":"Weight","dataType":"numeric","fieldName":"weight","minWidth":"15"},    
          {"displayName":"Net Weight","dataType":"numeric","fieldName":"netWeight","minWidth":"15"},  
          {"displayName":"Rate","dataType":"numeric","fieldName":"rate","minWidth":"15"},  
          {"displayName":"Amount","dataType":"numeric","fieldName":"amount","minWidth":"15"},    
          {"displayName":"Created Date","dataType":"Date","fieldName":"createdDate", "ishidefilter":true}             
        ];
        break;
      case 10:
        this.PageTitle = "Ledger Report"
        this.isFilerRequired = false;
        this.columnArray = [
          {"displayName":"Type","dataType":"text","fieldName":"type","minWidth":"15"},
          {"displayName":"Name","dataType":"text","fieldName":"name","minWidth":"15"},
          {"displayName":"Sub Type","dataType":"text","fieldName":"subType","minWidth":"15"},
          {"displayName":"Closing Balance","dataType":"numeric","fieldName":"closingBalance","minWidth":"20"},                  
        ];
        break;
      case 11:
        this.PageTitle = "Payable Report"
        this.columnArray = [
          {"displayName":"Date","dataType":"Date","fieldName":"entryDate", "ishidefilter":true},
          {"displayName":"Slip No","dataType":"numeric","fieldName":"slipNo"},
          {"displayName":"Type","dataType":"text","fieldName":"type","minWidth":"15"},
          {"displayName":"Name","dataType":"text","fieldName":"name","minWidth":"15"}, 
          {"displayName":"Broker","dataType":"text","fieldName":"brokerName","minWidth":"20"},
          {"displayName":"Total","dataType":"numeric","fieldName":"total"}
        ];
        break;
      case 12:
        this.PageTitle = "Receivable Report"
        this.columnArray = [
          {"displayName":"Date","dataType":"Date","fieldName":"entryDate", "ishidefilter":true},
          {"displayName":"Slip No","dataType":"numeric","fieldName":"slipNo"},
          {"displayName":"Type","dataType":"text","fieldName":"type","minWidth":"15"},
          {"displayName":"Name","dataType":"text","fieldName":"name","minWidth":"15"}, 
          {"displayName":"Broker","dataType":"text","fieldName":"brokerName","minWidth":"20"},
          {"displayName":"Total","dataType":"numeric","fieldName":"total"}                 
        ];
        break;
      case 13:
        this.PageTitle = "Cash Bank Report"
        this.columnArray = [
          {"displayName":"Date","dataType":"Date","fieldName":"entryDate", "ishidefilter":true},
          {"displayName":"From Party","dataType":"text","fieldName":"fromParty","minWidth":"15"},
          {"displayName":"To Party","dataType":"text","fieldName":"toParty","minWidth":"15"},
          {"displayName":"Remarks","dataType":"text","fieldName":"remarks","minWidth":"20"}, 
          {"displayName":"Debit","dataType":"numeric","fieldName":"debit","minWidth":"15"},
          {"displayName":"Credit","dataType":"numeric","fieldName":"credit","minWidth":"15"},                  
        ];
        break;
      case 14:
        this.PageTitle = "Salary Report"
        this.isFilerRequired = false;
        this.columnArray = [
          {"displayName":"Sr No","dataType":"numeric","fieldName":"srNo"},
          {"displayName":"Sr","dataType":"numeric","fieldName":"sr"},
          {"displayName":"To Party Name","dataType":"text","fieldName":"toPartyName","minWidth":"20"},
          {"displayName":"Date","dataType":"Date","fieldName":"salaryMonthDateTime", "ishidefilter":true},
          {"displayName":"Worked Days/Hrs","dataType":"numeric","fieldName":"workedDays","minWidth":"20"},
          {"displayName":"Month","dataType":"numeric","fieldName":"workedDays"},
          {"displayName":"OT Hrs(-)","dataType":"numeric","fieldName":"otMinusHrs"},
          {"displayName":"OT Rate(-)","dataType":"numeric","fieldName":"otMinusRate"},
          {"displayName":"OT Hrs(+)","dataType":"numeric","fieldName":"otPlusHrs"},
          {"displayName":"OT Rate(+)","dataType":"numeric","fieldName":"otPlusRate"},
          {"displayName":"Rounf(+/-)","dataType":"numeric","fieldName":"roundOfAmount"},
          {"displayName":"Total Salary","dataType":"numeric","fieldName":"salaryAmount"},
          {"displayName":"Remarks","dataType":"text","fieldName":"remarks","minWidth":"20"},
        ];
        break;
      default:
        break;
    }
  }

  ngOnInit() {
    this.loading = false;
    this.getCompanyData();
    let currentDate = new Date(); // Get the current date
    currentDate = new Date(currentDate.getFullYear(), currentDate.getMonth(), 1);
    this.firstDate = this.datePipe.transform(currentDate, 'yyyy-MM-dd');
    this.endDate = this.datePipe.transform(new Date(), 'yyyy-MM-dd');   
    this.purchseReport(this.firstDate, this.endDate);
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
    const StartDate = this.datePipe.transform(event.startDate, 'yyyy-MM-dd');
    const EndDate = this.datePipe.transform(event.endDate, 'yyyy-MM-dd');
    this.firstDate = StartDate;
    this.endDate = EndDate;
    this.purchseReport(StartDate, EndDate)
  }

  purchseReport(startDate : string | null, endDate : string | null){
    try {
      this.loading = true;
      switch (this.reportIndex)
      {
        case 1:
          this.sharedService.customGetApi("Report/GetPurchaseReport?CompanyId=" + this.RememberCompany.company.id + "&FinancialYearId=" + this.RememberCompany.financialyear.id +"&FromDate=" + startDate + "&ToDate=" + endDate + "")
            .subscribe((data: any) => {
                this.PurchaseReportList = data.data;
                this.loading = false;
              }, (ex: any) => {
                this.loading = false;
                this.showMessage('error',ex);
            });
          break;
          case 2:
            this.sharedService.customGetApi("Report/GetSaleReport?CompanyId=" + this.RememberCompany.company.id + "&FinancialYearId=" + this.RememberCompany.financialyear.id + "&FromDate=" + startDate + "&ToDate=" + endDate + "")
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
            this.sharedService.customGetApi("Report/GetPaymentReport?CompanyId=" + this.RememberCompany.company.id + "&FinancialYearId=" + this.RememberCompany.financialyear.id + "&FromDate=" + startDate + "&ToDate=" + endDate + "")
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
            this.sharedService.customGetApi("Report/GetReceiptReport?CompanyId=" + this.RememberCompany.company.id + "&FinancialYearId=" + this.RememberCompany.financialyear.id + "&FromDate=" + startDate + "&ToDate=" + endDate + "")
            .subscribe((data: any) => {
                  this.PurchaseReportList = data.data;
                  this.loading = false;
                  console.log(this.PurchaseReportList);
                }, (ex: any) => {
                  this.loading = false;
                  this.showMessage('error',ex);
              });
          break;
          case 5:
            this.sharedService.customGetApi("Report/GetContraPaymentReport?CompanyId=" + this.RememberCompany.company.id + "&FinancialYearId=" + this.RememberCompany.financialyear.id + "&FromDate=" + startDate + "&ToDate=" + endDate + "")
            .subscribe((data: any) => {
                  this.PurchaseReportList = data.data;
                  this.loading = false;
                  console.log(this.PurchaseReportList);
                }, (ex: any) => {
                  this.loading = false;
                  this.showMessage('error',ex);
              });
          break;
          case 6:
            this.sharedService.customGetApi("Report/GetExpenseReport?CompanyId=" + this.RememberCompany.company.id + "&FinancialYearId=" + this.RememberCompany.financialyear.id + "&FromDate=" + startDate + "&ToDate=" + endDate + "")
            .subscribe((data: any) => {
                  this.PurchaseReportList = data.data;
                  this.loading = false;
                  console.log(this.PurchaseReportList);
                }, (ex: any) => {
                  this.loading = false;
                  this.showMessage('error',ex);
              });
          break;
          case 7:
            this.sharedService.customGetApi("Report/GetLoanReport?CompanyId=" + this.RememberCompany.company.id)
            .subscribe((data: any) => {
                  this.PurchaseReportList = data.data;
                  this.loading = false;
                  console.log(this.PurchaseReportList);
                }, (ex: any) => {
                  this.loading = false;
                  this.showMessage('error',ex);
              });
          break;
          case 8:
            this.sharedService.customGetApi("Report/GetMixedReport?CompanyId=" + this.RememberCompany.company.id + "&FinancialYearId=" + this.RememberCompany.financialyear.id + "&FromDate=" + startDate + "&ToDate=" + endDate + "")
            .subscribe((data: any) => {
                  this.PurchaseReportList = data.data;
                  this.loading = false;
                  console.log(this.PurchaseReportList);
                }, (ex: any) => {
                  this.loading = false;
                  this.showMessage('error',ex);
              });
          break;
          case 9:
            this.sharedService.customGetApi("Report/GetPFReport?CompanyId=" + this.RememberCompany.company.id + "&FinancialYearId=" + this.RememberCompany.financialyear.id)
            .subscribe((data: any) => {
                  this.PurchaseReportList = data.data;
                  this.loading = false;
                  console.log(this.PurchaseReportList);
                }, (ex: any) => {
                  this.loading = false;
                  this.showMessage('error',ex);
              });
          break;
          case 10:
            this.sharedService.customGetApi("Report/GetLedgerReport?CompanyId=" + this.RememberCompany.company.id + "&FinancialYearId=" + this.RememberCompany.financialyear.id)
            .subscribe((data: any) => {
                  this.PurchaseReportList = data.data;
                  this.loading = false;
                  console.log(this.PurchaseReportList);
                }, (ex: any) => {
                  this.loading = false;
                  this.showMessage('error',ex);
              });
          break;
          case 11:
            this.sharedService.customGetApi("Report/GetPayableReport?CompanyId=" + this.RememberCompany.company.id + "&FinancialYearId=" + this.RememberCompany.financialyear.id)
            .subscribe((data: any) => {
                  this.PurchaseReportList = data.data;
                  this.loading = false;
                  console.log(this.PurchaseReportList);
                }, (ex: any) => {
                  this.loading = false;
                  this.showMessage('error',ex);
              });
          break;
          case 12:
            this.sharedService.customGetApi("Report/GetReceivableReport?CompanyId=" + this.RememberCompany.company.id + "&FinancialYearId=" + this.RememberCompany.financialyear.id)
            .subscribe((data: any) => {
                  this.PurchaseReportList = data.data;
                  this.loading = false;
                  console.log(this.PurchaseReportList);
                }, (ex: any) => {
                  this.loading = false;
                  this.showMessage('error',ex);
              });
          break;
          case 13:
            this.sharedService.customGetApi("Report/GetCashBankReport?CompanyId=" + this.RememberCompany.company.id + "&FinancialYearId=" + this.RememberCompany.financialyear.id + "&FromDate=" + startDate + "&ToDate=" + endDate + "")
            .subscribe((data: any) => {
                  this.PurchaseReportList = data.data;
                  this.loading = false;
                  console.log(this.PurchaseReportList);
                }, (ex: any) => {
                  this.loading = false;
                  this.showMessage('error',ex);
              });
          break;
          case 14:
          this.sharedService.customGetApi("Report/GetSalariesReport?CompanyId=" + this.RememberCompany.company.id + "&FinancialYearId=" + this.RememberCompany.financialyear.id)
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
    catch(e) {
      alert("Try catch error : " + JSON.stringify(e));
    }    
  }

  exportExcel() {
    import('xlsx').then((xlsx) => {
        const worksheet = xlsx.utils.json_to_sheet(this.PurchaseReportList);
        const workbook = { Sheets: { data: worksheet }, SheetNames: ['data'] };
        const excelBuffer: any = xlsx.write(workbook, { bookType: 'xlsx', type: 'array' });
        this.saveAsExcelFile(excelBuffer, 'report');
    });
  }

  saveAsExcelFile(buffer: any, fileName: string): void {
    let EXCEL_TYPE = 'application/vnd.openxmlformats-officedocument.spreadsheetml.sheet;charset=UTF-8';
    let EXCEL_EXTENSION = '.xlsx';
    const data: Blob = new Blob([buffer], {
        type: EXCEL_TYPE
    });
    FileSaver.saveAs(data, fileName + '_export_' + new Date().getTime() + EXCEL_EXTENSION);
  }

  exportPdf() {
    let exportColumns: any[];
    this.columnArray = [
      {"displayName":"Date","dataType":"Date","fieldName":"date"},
      {"displayName":"Branch","dataType":"text","fieldName":"branchName"},
      {"displayName":"SlipNo","dataType":"numeric","fieldName":"slipNo"},          
      {"displayName":"Party","dataType":"text","fieldName":"partyName"},
      {"displayName":"Broker","dataType":"text","fieldName":"brokerName"},
      {"displayName":"Kapan","dataType":"text","fieldName":"kapanName"},
      {"displayName":"NetCts","dataType":"numeric","fieldName":"netWeight"},
      {"displayName":"BuyRate","dataType":"numeric","fieldName":"buyingRate"},
      {"displayName":"Less","dataType":"numeric","fieldName":"lessWeight"},
      {"displayName":"CVDAmt","dataType":"numeric","fieldName":"cvdAmount"},
      {"displayName":"DueDays","dataType":"numeric","fieldName":"dueDays"},
      {"displayName":"PayDays","dataType":"numeric","fieldName":"paymentDays"},
      {"displayName":"DueDate","dataType":"Date","fieldName":"dueDate"},
      {"displayName":"Total","dataType":"numeric","fieldName":"total"},      
      {"displayName":"Status","dataType":"text","fieldName":"approvalType"},        
    ]
    exportColumns = this.columnArray.map((col) => (col.fieldName));
    import('jspdf').then((jsPDF) => {
        import('jspdf-autotable').then((x) => {
            
            const doc = new jsPDF.default('l', 'px', 'a4');

            const styles = {
              fontSize: 8, // Set font size to 5
            };

            const formatDate = (dateString: string) => {
              const date = new Date(dateString);
              const month = (date.getMonth() + 1).toString().padStart(2, '0');
              const day = date.getDate().toString().padStart(2, '0');
              const year = date.getFullYear();
              return `${month}-${day}-${year}`;
            };

            let extractedData : any[] = this.PurchaseReportList.map((item) => {
              const formattedItem = { ...item };
              formattedItem['date'] = formatDate(item['date']); // Assuming 'Date' is the key for the date field
              formattedItem['dueDate'] = formatDate(item['dueDate']); 
              return formattedItem;
            });

            extractedData = extractedData.map((item) =>
              exportColumns.map((column) => item[column])
            );

            // extractedData = extractedData.map((item) => {
            //   const formattedItem = { ...item };
            //   formattedItem['date'] = formatDate(item['date']); // Assuming 'Date' is the key for the date field
            //   formattedItem['dueDate'] = formatDate(item['dueDate']); 
            //   return formattedItem;
            // });
           
            debugger;

            (doc as any).autoTable({
              head: [this.columnArray.map((col) => (col.displayName))],
              body: extractedData,
              styles: styles,
            });
            doc.save('reports.pdf');
        });
    });
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

  onApproveClick(reportIndex: number, item : any, status : any) {
    this.visible = true;
    this.dialogReportIndex = reportIndex;
    this.reportItemId = item;
    this.ApproveRejectStatus = status;
  }

  onApproveReject(){  
    const data = {
      "ReportType":this.dialogReportIndex,
      "Id": this.reportItemId,
      "Comment": this.ApproveRejectComment,
      "Status": this.ApproveRejectStatus
    };
    this.loading = true;
    this.sharedService.customPostApi("Report/ApproveRejectStatus",data)
    .subscribe((data: any) => {
      debugger;
          if (data.success == true){
            if (this.ApproveRejectStatus == 1){                  
              this.showMessage('success','Approve successfully.');
            }
            else if (this.ApproveRejectStatus == 2){
              this.showMessage('success','Rejected successfully.');
            }
            this.loading = false;
            this.dialogReportIndex = 0;
            this.reportItemId = '';
            this.ApproveRejectComment = '';
            this.ApproveRejectStatus = 0;
            this.purchseReport(this.firstDate, this.endDate);
            // this.ngOnInit();          
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
