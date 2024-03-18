import { Component, OnInit, ViewChild } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ConfirmEventType, ConfirmationService } from 'primeng/api';
import { Table } from 'primeng/table';
import { SharedService } from '../common/shared.service';
import { RememberCompany } from '../shared/component/companyselection/companyselection.component';
import { Message, MessageService } from 'primeng/api';
import { DatePipe } from '@angular/common';
import * as FileSaver from 'file-saver';
import 'jspdf-autotable';
import { Filesystem, Directory, Encoding, DownloadFileOptions } from '@capacitor/filesystem';
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

  @ViewChild('dt1') dataTable: Table; // Assuming your p-table component has a template reference variable named 'dataTable'
  PageTitle: string = "Purchase Report";
  reportIndex: number = 0;
  RememberCompany: RememberCompany = new RememberCompany();
  PurchaseReportList: any[];
  columnArray: any[] = [];
  childColumnArray: any[] = [];
  childReportList: any[];
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
  filterColumn: string[] = [];
  isApproveButton: boolean = false;
  selectedRowIndex: number;
  dataChild: any[] = [];
  isChildReport: boolean = false;
  childTotalColumn: number = 0;
  childFilterColumn: string[] = [];
  constructor(private rote: Router, private activateRoute: ActivatedRoute,
    private sharedService: SharedService, private messageService: MessageService, private datePipe: DatePipe) {
    this.reportIndex = +activateRoute.snapshot.params['id'];
    switch (this.reportIndex) {
      case 1:
        this.PageTitle = "Purchase Report";
        this.isChildReport = true;
        this.sharedService.customGetApi("Auth/GetPermission?userid=" + localStorage.getItem("userid") + "&keyname=purchase_approval")
          .subscribe((data: any) => {
            debugger;
            this.isApproveButton = data.success;

            this.columnArray = [
              { "displayName": "Kapan Name", "dataType": "text", "fieldName": "kapanName", "minWidth": "15" },
              { "displayName": "Date", "dataType": "Date", "fieldName": "date", "ishidefilter": true },
              { "displayName": "Slip No", "dataType": "numeric", "fieldName": "slipNo" },
              { "displayName": "Party Name", "dataType": "text", "fieldName": "partyName", "minWidth": "15" },
              { "displayName": "Broker Name", "dataType": "text", "fieldName": "brokerName", "minWidth": "15" },
              { "displayName": "Branch Name", "dataType": "text", "fieldName": "branchName", "minWidth": "15" },
              { "displayName": "Buyer Name", "dataType": "text", "fieldName": "buyerName", "minWidth": "15" },
              { "displayName": "Net Cts", "dataType": "numeric", "fieldName": "netWeight" },
              { "displayName": "Buy Rate", "dataType": "numeric", "fieldName": "buyingRate" },
              { "displayName": "Less", "dataType": "numeric", "fieldName": "lessWeight" },
              { "displayName": "Total", "dataType": "numeric", "fieldName": "total" },
              { "displayName": "CVD Amt", "dataType": "numeric", "fieldName": "cvdAmount" },
              { "displayName": "Due Days", "dataType": "numeric", "fieldName": "dueDays" },
              { "displayName": "Pay Days", "dataType": "numeric", "fieldName": "paymentDays" },
              { "displayName": "Due Date", "dataType": "Date", "fieldName": "dueDate", "ishidefilter": true },
              { "displayName": "Pay Date", "dataType": "Date", "fieldName": "paymentDueDate", "ishidefilter": true },
              { "displayName": "Remarks", "dataType": "text", "fieldName": "remarks", "minWidth": "15" },
              { "displayName": "Message", "dataType": "text", "fieldName": "message", "minWidth": "15" },
              { "displayName": "Approval Status", "dataType": "text", "fieldName": "approvalType" },
              { "displayName": "Approve", "dataType": "text", "fieldName": "approvalType", "minWidth": "10", "reportid": "purId", "ishidefilter": true },
              { "displayName": "Reject", "dataType": "text", "fieldName": "approvalType", "minWidth": "10", "reportid": "purId", "ishidefilter": true }
              // {"displayName":"Approval Type","dataType":"boolean","fieldName":"approvalType","minWidth":"3"},
              // {"displayName":"Action","dataType":"action","fieldName":"approvalType","minWidth":"3"},
              // {"displayName":"Action","dataType":"action","fieldName":"approvalType","minWidth":"3"}
            ]
          });
        break;
      case 2:
        this.PageTitle = "Sales Report";
        this.isChildReport = true;
        this.sharedService.customGetApi("Auth/GetPermission?userid=" + localStorage.getItem("userid") + "&keyname=sales_approval")
          .subscribe((data: any) => {
            this.isApproveButton = data.success;
            this.columnArray = [
              { "displayName": "Date", "dataType": "Date", "fieldName": "date", "ishidefilter": true },
              { "displayName": "Branch Name", "dataType": "text", "fieldName": "branchName", "minWidth": "15" },
              { "displayName": "Slip No", "dataType": "numeric", "fieldName": "slipNo" },
              { "displayName": "Party Name", "dataType": "text", "fieldName": "partyName", "minWidth": "15" },
              { "displayName": "Broker Name", "dataType": "text", "fieldName": "brokerName", "minWidth": "15" },
              { "displayName": "Kapan Name", "dataType": "text", "fieldName": "kapanName", "minWidth": "15" },
              { "displayName": "Net Cts", "dataType": "numeric", "fieldName": "netWeight" },
              { "displayName": "Sale Rate", "dataType": "numeric", "fieldName": "saleRate" },
              { "displayName": "Less", "dataType": "numeric", "fieldName": "lessWeight" },
              { "displayName": "CVD Amount", "dataType": "numeric", "fieldName": "cvdAmount" },
              { "displayName": "Pay Days", "dataType": "numeric", "fieldName": "paymentDays" },
              { "displayName": "Due Days", "dataType": "numeric", "fieldName": "dueDays" },
              { "displayName": "Due Date", "dataType": "Date", "fieldName": "dueDate", "ishidefilter": true },
              { "displayName": "Total", "dataType": "numeric", "fieldName": "total" },
              { "displayName": "Remarks", "dataType": "text", "fieldName": "remarks", "minWidth": "15" },
              { "displayName": "Message", "dataType": "text", "fieldName": "message", "minWidth": "15" },
              { "displayName": "Approval Status", "dataType": "text", "fieldName": "approvalType" },
              { "displayName": "Approve", "dataType": "text", "fieldName": "approvalType", "minWidth": "10", "reportid": "id", "ishidefilter": true },
              { "displayName": "Reject", "dataType": "text", "fieldName": "approvalType", "minWidth": "10", "reportid": "id", "ishidefilter": true }
              // {"displayName":"Approval Type","dataType":"boolean","fieldName":"approvalType","minWidth":"3"}
            ];
          });
        break;
      case 3:
        this.PageTitle = "Payment Report";
        this.sharedService.customGetApi("Auth/GetPermission?userid=" + localStorage.getItem("userid") + "&keyname=payment_approval")
          .subscribe((data: any) => {
            this.isApproveButton = data.success;
            debugger;
            this.columnArray = [
              { "displayName": "Date", "dataType": "Date", "fieldName": "entryDate", "ishidefilter": true },
              { "displayName": "To Party", "dataType": "text", "fieldName": "toName", "minWidth": "15" },
              { "displayName": "From Party", "dataType": "text", "fieldName": "fromName", "minWidth": "15" },
              { "displayName": "Amount", "dataType": "numeric", "fieldName": "amount" },
              { "displayName": "Cheque No", "dataType": "text", "fieldName": "chequeNo" },
              { "displayName": "Cheque Date", "dataType": "Date", "fieldName": "chequeDate", "minWidth": "15", "ishidefilter": true },
              { "displayName": "Remarks", "dataType": "text", "fieldName": "remarks", "minWidth": "15" },
              { "displayName": "Approval Status", "dataType": "text", "fieldName": "approvalType" },
              { "displayName": "Approve", "dataType": "text", "fieldName": "approvalType", "minWidth": "10", "reportid": "groupId", "ishidefilter": true },
              { "displayName": "Reject", "dataType": "text", "fieldName": "approvalType", "minWidth": "10", "reportid": "groupId", "ishidefilter": true }
            ];
          });
        break;
      case 4:
        this.PageTitle = "Receipt Report";
        this.sharedService.customGetApi("Auth/GetPermission?userid=" + localStorage.getItem("userid") + "&keyname=receipt_approval")
          .subscribe((data: any) => {
            this.isApproveButton = data.success;
            this.columnArray = [
              { "displayName": "Date", "dataType": "Date", "fieldName": "entryDate", "ishidefilter": true },
              { "displayName": "To Party", "dataType": "text", "fieldName": "toName", "minWidth": "15" },
              { "displayName": "From Party", "dataType": "text", "fieldName": "fromName", "minWidth": "15" },
              { "displayName": "Amount", "dataType": "numeric", "fieldName": "amount" },
              { "displayName": "Cheque No", "dataType": "text", "fieldName": "chequeNo" },
              { "displayName": "Cheque Date", "dataType": "Date", "fieldName": "chequeDate", "minWidth": "15", "ishidefilter": true },
              { "displayName": "Remarks", "dataType": "text", "fieldName": "remarks", "minWidth": "15" },
              { "displayName": "Approval Status", "dataType": "text", "fieldName": "approvalType" },
              { "displayName": "Approve", "dataType": "text", "fieldName": "approvalType", "minWidth": "10", "reportid": "groupId", "ishidefilter": true },
              { "displayName": "Reject", "dataType": "text", "fieldName": "approvalType", "minWidth": "10", "reportid": "groupId", "ishidefilter": true }
            ];
          });
        break;
      case 5:
        this.PageTitle = "Contra Payment Report";
        this.isFilerRequired = false;
        this.columnArray = [
          { "displayName": "Date", "dataType": "Date", "fieldName": "entryDate", "ishidefilter": true },
          { "displayName": "From Party", "dataType": "text", "fieldName": "fromPartyName", "minWidth": "15" },
          { "displayName": "To Party", "dataType": "text", "fieldName": "toPartyName", "minWidth": "15" },
          { "displayName": "Cheque No", "dataType": "text", "fieldName": "chequeNo" },
          { "displayName": "Cheque Date", "dataType": "Date", "fieldName": "chequeDate", "minWidth": "15", "ishidefilter": true },
          { "displayName": "Amount", "dataType": "numeric", "fieldName": "amount" },
          { "displayName": "Remarks", "dataType": "text", "fieldName": "remarks", "minWidth": "15" },
        ];
        break;
      case 6:
        this.PageTitle = "Expense Report";
        this.columnArray = [
          { "displayName": "Date", "dataType": "Date", "fieldName": "entryDate", "ishidefilter": true },
          { "displayName": "SrNo", "dataType": "numeric", "fieldName": "srNo" },
          { "displayName": "Branch Name", "dataType": "text", "fieldName": "branchName", "minWidth": "15" },
          { "displayName": "From Party", "dataType": "text", "fieldName": "fromPartyName", "minWidth": "15" },
          { "displayName": "To Party", "dataType": "text", "fieldName": "toPartyName", "minWidth": "15" },
          { "displayName": "Amount", "dataType": "numeric", "fieldName": "amount" },
          { "displayName": "Remarks", "dataType": "text", "fieldName": "remarks", "minWidth": "20" },
        ];
        break;
      case 7:
        this.PageTitle = "Loan Report";
        this.isFilerRequired = false;
        this.columnArray = [
          { "displayName": "Sr", "dataType": "numeric", "fieldName": "sr" },
          { "displayName": "Party Name", "dataType": "text", "fieldName": "partyName", "minWidth": "15" },
          { "displayName": "Cash/Bank Party Name", "dataType": "text", "fieldName": "cashBankName", "minWidth": "25" },
          { "displayName": "Amount", "dataType": "numeric", "fieldName": "amount" },
          { "displayName": "Duration Type", "dataType": "text", "fieldName": "duratonType", "minWidth": "15" },
          { "displayName": "Start Date", "dataType": "Date", "fieldName": "startDate", "ishidefilter": true },
          { "displayName": "End Date", "dataType": "Date", "fieldName": "endDate", "ishidefilter": true },
          { "displayName": "Interest Rate", "dataType": "numeric", "fieldName": "interestRate" },
          { "displayName": "Total Interest", "dataType": "numeric", "fieldName": "totalInterest" },
          { "displayName": "Net Amount", "dataType": "numeric", "fieldName": "netAmount" },
          { "displayName": "Updated Date", "dataType": "Date", "fieldName": "updatedDate", "ishidefilter": true }
        ];
        break;
      case 8:
        this.PageTitle = "Rojmel Report";
        this.columnArray = [
          { "displayName": "Date", "dataType": "Date", "fieldName": "entryDate", "ishidefilter": true },
          { "displayName": "From Party Name", "dataType": "text", "fieldName": "fromName", "minWidth": "15" },
          { "displayName": "To Name", "dataType": "text", "fieldName": "toName", "minWidth": "15" },
          { "displayName": "Remarks", "dataType": "text", "fieldName": "remarks", "minWidth": "20" },
          { "displayName": "Debit", "dataType": "numeric", "fieldName": "debit", "minWidth": "15" },
          { "displayName": "Credit", "dataType": "numeric", "fieldName": "credit", "minWidth": "15" },
        ];
        break;
      case 9:
        this.PageTitle = "PF Report";
        this.isFilerRequired = false;
        this.columnArray = [
          { "displayName": "Type", "dataType": "text", "fieldName": "type" },
          { "displayName": "Party Name", "dataType": "text", "fieldName": "partyName", "minWidth": "15" },
          { "displayName": "Broker Name", "dataType": "text", "fieldName": "brokerName", "minWidth": "15" },
          { "displayName": "Size", "dataType": "numeric", "fieldName": "size", "minWidth": "15" },
          { "displayName": "Number", "dataType": "numeric", "fieldName": "number", "minWidth": "15" },
          { "displayName": "Weight", "dataType": "numeric", "fieldName": "weight", "minWidth": "15" },
          { "displayName": "Net Weight", "dataType": "numeric", "fieldName": "netWeight", "minWidth": "15" },
          { "displayName": "Rate", "dataType": "numeric", "fieldName": "rate", "minWidth": "15" },
          { "displayName": "Amount", "dataType": "numeric", "fieldName": "amount", "minWidth": "15" },
          { "displayName": "Created Date", "dataType": "Date", "fieldName": "createdDate", "ishidefilter": true }
        ];
        break;
      case 10:
        this.PageTitle = "Ledger Report";
        this.isFilerRequired = false;
        this.isChildReport = true;
        this.columnArray = [
          { "displayName": "Type", "dataType": "text", "fieldName": "type", "minWidth": "15" },
          { "displayName": "Name", "dataType": "text", "fieldName": "name", "minWidth": "15" },
          { "displayName": "Sub Type", "dataType": "text", "fieldName": "subType", "minWidth": "15" },
          { "displayName": "Closing Balance", "dataType": "numeric", "fieldName": "closingBalance", "minWidth": "20" },
        ];
        break;
      case 11:
        this.PageTitle = "Payable Report";
        this.isFilerRequired = false;
        this.columnArray = [
          { "displayName": "Date", "dataType": "Date", "fieldName": "entryDate", "ishidefilter": true },
          { "displayName": "Slip No", "dataType": "numeric", "fieldName": "slipNo" },
          { "displayName": "Type", "dataType": "text", "fieldName": "type", "minWidth": "15" },
          { "displayName": "Name", "dataType": "text", "fieldName": "name", "minWidth": "15" },
          { "displayName": "Broker", "dataType": "text", "fieldName": "brokerName", "minWidth": "20" },
          { "displayName": "Total", "dataType": "numeric", "fieldName": "total" }
        ];
        break;
      case 12:
        this.PageTitle = "Receivable Report";
        this.isFilerRequired = false;
        this.columnArray = [
          { "displayName": "Date", "dataType": "Date", "fieldName": "entryDate", "ishidefilter": true },
          { "displayName": "Slip No", "dataType": "numeric", "fieldName": "slipNo" },
          { "displayName": "Type", "dataType": "text", "fieldName": "type", "minWidth": "15" },
          { "displayName": "Name", "dataType": "text", "fieldName": "name", "minWidth": "15" },
          { "displayName": "Broker", "dataType": "text", "fieldName": "brokerName", "minWidth": "20" },
          { "displayName": "Total", "dataType": "numeric", "fieldName": "total" }
        ];
        break;
      case 13:
        this.PageTitle = "Cash Bank Report";
        this.columnArray = [
          { "displayName": "Date", "dataType": "Date", "fieldName": "entryDate", "ishidefilter": true },
          { "displayName": "From Party", "dataType": "text", "fieldName": "fromParty", "minWidth": "15" },
          { "displayName": "To Party", "dataType": "text", "fieldName": "toParty", "minWidth": "15" },
          { "displayName": "Remarks", "dataType": "text", "fieldName": "remarks", "minWidth": "20" },
          { "displayName": "Debit", "dataType": "numeric", "fieldName": "debit", "minWidth": "15" },
          { "displayName": "Credit", "dataType": "numeric", "fieldName": "credit", "minWidth": "15" },
        ];
        break;
      case 14:
        this.PageTitle = "Salary Report";
        this.isFilerRequired = false;
        this.columnArray = [
          { "displayName": "Sr No", "dataType": "numeric", "fieldName": "srNo" },
          { "displayName": "Sr", "dataType": "numeric", "fieldName": "sr" },
          { "displayName": "To Party Name", "dataType": "text", "fieldName": "toPartyName", "minWidth": "20" },
          { "displayName": "Date", "dataType": "Date", "fieldName": "salaryMonthDateTime", "ishidefilter": true },
          { "displayName": "Worked Days/Hrs", "dataType": "numeric", "fieldName": "workedDays", "minWidth": "20" },
          { "displayName": "Month", "dataType": "numeric", "fieldName": "workedDays" },
          { "displayName": "OT Hrs(-)", "dataType": "numeric", "fieldName": "otMinusHrs" },
          { "displayName": "OT Rate(-)", "dataType": "numeric", "fieldName": "otMinusRate" },
          { "displayName": "OT Hrs(+)", "dataType": "numeric", "fieldName": "otPlusHrs" },
          { "displayName": "OT Rate(+)", "dataType": "numeric", "fieldName": "otPlusRate" },
          { "displayName": "Rounf(+/-)", "dataType": "numeric", "fieldName": "roundOfAmount" },
          { "displayName": "Total Salary", "dataType": "numeric", "fieldName": "salaryAmount" },
          { "displayName": "Remarks", "dataType": "text", "fieldName": "remarks", "minWidth": "20" },
        ];
        break;
      case 15:
        this.PageTitle = "Rejection In/Receive"
        this.isFilerRequired = false;
        this.columnArray = [
          { "displayName": "Date", "dataType": "Date", "fieldName": "entryDate", "ishidefilter": true },
          { "displayName": "SrNo", "dataType": "numeric", "fieldName": "srNo" },
          { "displayName": "Slip No", "dataType": "text", "fieldName": "slipNo" },
          { "displayName": "Party Name", "dataType": "text", "fieldName": "partyName", "minWidth": "20" },
          { "displayName": "Broker Name", "dataType": "text", "fieldName": "brokerName", "minWidth": "20" },
          { "displayName": "Size Name", "dataType": "text", "fieldName": "sizeName" },
          { "displayName": "Charni Size Name", "dataType": "text", "fieldName": "charniSizeName", "minWidth": "20" },
          { "displayName": "Gala Size Name", "dataType": "text", "fieldName": "galaSizeName", "minWidth": "20" },
          { "displayName": "Number Size Name", "dataType": "text", "fieldName": "numberSizeName", "minWidth": "20" },
          { "displayName": "Purity Name", "dataType": "text", "fieldName": "purityName", "minWidth": "20" },
          { "displayName": "Rate  ", "dataType": "numeric", "fieldName": "rate" },
          { "displayName": "Carat", "dataType": "numeric", "fieldName": "totalCarat" },
          { "displayName": "Amount", "dataType": "numeric", "fieldName": "amount" },
          { "displayName": "Remarks", "dataType": "text", "fieldName": "remarks", "minWidth": "20" },
        ];
        break;
      case 16:
        this.PageTitle = "Rejection Out/Send"
        this.isFilerRequired = false;
        this.columnArray = [
          { "displayName": "Date", "dataType": "Date", "fieldName": "entryDate", "ishidefilter": true },
          { "displayName": "SrNo", "dataType": "numeric", "fieldName": "srNo" },
          { "displayName": "Slip No", "dataType": "text", "fieldName": "slipNo" },
          { "displayName": "Party Name", "dataType": "text", "fieldName": "partyName", "minWidth": "20" },
          { "displayName": "Broker Name", "dataType": "text", "fieldName": "brokerName", "minWidth": "20" },
          { "displayName": "Size Name", "dataType": "text", "fieldName": "sizeName" },
          { "displayName": "Charni Size Name", "dataType": "text", "fieldName": "charniSizeName", "minWidth": "20" },
          { "displayName": "Gala Size Name", "dataType": "text", "fieldName": "galaSizeName", "minWidth": "20" },
          { "displayName": "Number Size Name", "dataType": "text", "fieldName": "numberSizeName", "minWidth": "20" },
          { "displayName": "Purity Name", "dataType": "text", "fieldName": "purityName", "minWidth": "20" },
          { "displayName": "Rate  ", "dataType": "numeric", "fieldName": "rate" },
          { "displayName": "Carat", "dataType": "numeric", "fieldName": "totalCarat" },
          { "displayName": "Amount", "dataType": "numeric", "fieldName": "amount" },
          { "displayName": "Remarks", "dataType": "text", "fieldName": "remarks", "minWidth": "20" },
        ];
        break;
      case 17:
        this.PageTitle = "Stock Report"
        this.isFilerRequired = false;
        this.isChildReport = true;
        this.columnArray = [
          { "displayName": "Type", "dataType": "text", "fieldName": "name", "minWidth": "10" },
          { "displayName": "Total Weight", "dataType": "numeric", "fieldName": "totalWeight", "minWidth": "20" },
          { "displayName": "Rate", "dataType": "numeric", "fieldName": "rate" },
          { "displayName": "Total Amount", "dataType": "numeric", "fieldName": "totalAmount", "minWidth": "20" }
        ];
        break;
      case 18:
        this.PageTitle = "Opening Stock Report"
        this.isFilerRequired = false;
        this.isChildReport = false;
        this.columnArray = [
          { "displayName": "SrNo", "dataType": "numeric", "fieldName": "srNo" },
          { "displayName": "Branch", "dataType": "text", "fieldName": "branchName", "minWidth": "15" },
          { "displayName": "Kapan", "dataType": "text", "fieldName": "kapanName", "minWidth": "15" },
          { "displayName": "Size", "dataType": "text", "fieldName": "sizeName", "minWidth": "10" },
          { "displayName": "Number", "dataType": "text", "fieldName": "numberName", "minWidth": "10" },
          { "displayName": "Total Cts", "dataType": "numeric", "fieldName": "totalCts" },
          { "displayName": "Rate", "dataType": "numeric", "fieldName": "rate" },
          { "displayName": "Amount", "dataType": "numeric", "fieldName": "amount" },
          { "displayName": "Remarks", "dataType": "text", "fieldName": "remarks", "minWidth": "20" },
          { "displayName": "Update Date", "dataType": "Date", "fieldName": "updatedDate", "ishidefilter": true }
        ];
        break;
      case 19:
        this.PageTitle = "Weekly Report"
        this.isFilerRequired = false;
        this.isChildReport = true;
        this.columnArray = [
          { "displayName": "Week No", "dataType": "text", "fieldName": "weekNo" },
          { "displayName": "Period", "dataType": "text", "fieldName": "period", "minWidth": "20" },
          { "displayName": "Amount", "dataType": "numeric", "fieldName": "amount", "minWidth": "20" }
        ];
        break;
      case 20:
        this.PageTitle = "Balance Sheet"
        this.isFilerRequired = false;
        this.columnArray = [
          { "displayName": "Col Type", "dataType": "text", "fieldName": "colType" },
          { "displayName": "Account Name", "dataType": "text", "fieldName": "type", "minWidth": "20" },
          { "displayName": "Amount", "dataType": "numeric", "fieldName": "amount", "minWidth": "20" }
        ];
        break;
      case 21:
        this.PageTitle = "Profit Loss Report"
        this.isFilerRequired = false;
        this.columnArray = [
          { "displayName": "Col Type", "dataType": "text", "fieldName": "colType" },
          { "displayName": "Account Name", "dataType": "text", "fieldName": "type", "minWidth": "20" },
          { "displayName": "Amount", "dataType": "numeric", "fieldName": "amount", "minWidth": "20" }
        ];
        break;
      default:
        break;
    }
    console.log("filterData:" + this.filterColumn);
  }

  ngOnInit() {
    this.loading = false;
    this.getCompanyData();
    let currentDate = new Date(); // Get the current date
    currentDate = new Date(currentDate.getFullYear(), currentDate.getMonth(), 1);
    this.firstDate = this.datePipe.transform(currentDate, 'yyyy-MM-dd');
    this.endDate = this.datePipe.transform(new Date(), 'yyyy-MM-dd');
    this.firstDate = this.datePipe.transform(this.RememberCompany.financialyear.startDate, 'yyyy-MM-dd');
    this.endDate = this.datePipe.transform(this.RememberCompany.financialyear.endDate, 'yyyy-MM-dd');
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
    this.childColumnArray = [];
    this.childReportList = [];
    this.childTotalColumn = 0;
    this.childFilterColumn = [];
    this.selectedRowIndex = -1;
    this.purchseReport(StartDate, EndDate)
  }

  purchseReport(startDate: string | null, endDate: string | null) {
    try {
      this.loading = true;
      switch (this.reportIndex) {
        case 1:

          this.sharedService.customGetApi("Report/GetPurchaseReport?CompanyId=" + this.RememberCompany.company.id + "&FinancialYearId=" + this.RememberCompany.financialyear.id + "&FromDate=" + startDate + "&ToDate=" + endDate + "")
            .subscribe((data: any) => {
              this.PurchaseReportList = data.data;
              this.loading = false;
            }, (ex: any) => {
              this.loading = false;
              this.showMessage('error', ex);
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
              this.showMessage('error', ex);
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
              this.showMessage('error', ex);
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
              this.showMessage('error', ex);
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
              this.showMessage('error', ex);
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
              this.showMessage('error', ex);
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
              this.showMessage('error', ex);
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
              this.showMessage('error', ex);
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
              this.showMessage('error', ex);
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
              this.showMessage('error', ex);
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
              this.showMessage('error', ex);
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
              this.showMessage('error', ex);
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
              this.showMessage('error', ex);
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
              this.showMessage('error', ex);
            });
          break;
        case 15:
          this.sharedService.customGetApi("Report/GetRejectionInReport?CompanyId=" + this.RememberCompany.company.id + "&FinancialYearId=" + this.RememberCompany.financialyear.id)
            .subscribe((data: any) => {
              this.PurchaseReportList = data.data;
              this.loading = false;
              console.log(this.PurchaseReportList);
            }, (ex: any) => {
              this.loading = false;
              this.showMessage('error', ex);
            });
          break;
        case 16:
          this.sharedService.customGetApi("Report/GetRejectionOutReport?CompanyId=" + this.RememberCompany.company.id + "&FinancialYearId=" + this.RememberCompany.financialyear.id)
            .subscribe((data: any) => {
              this.PurchaseReportList = data.data;
              this.loading = false;
              console.log(this.PurchaseReportList);
            }, (ex: any) => {
              this.loading = false;
              this.showMessage('error', ex);
            });
          break;
        case 17:
          this.sharedService.customGetApi("Report/GetStockReport?CompanyId=" + this.RememberCompany.company.id + "&FinancialYearId=" + this.RememberCompany.financialyear.id)
            .subscribe((data: any) => {
              this.PurchaseReportList = data.data;
              this.loading = false;
              console.log(this.PurchaseReportList);
            }, (ex: any) => {
              this.loading = false;
              this.showMessage('error', ex);
            });
          break;
        case 18:
          this.sharedService.customGetApi("Report/GetOpeningStockReport?CompanyId=" + this.RememberCompany.company.id + "&FinancialYearId=" + this.RememberCompany.financialyear.id)
            .subscribe((data: any) => {
              this.PurchaseReportList = data.data;
              this.loading = false;
              console.log(this.PurchaseReportList);
            }, (ex: any) => {
              this.loading = false;
              this.showMessage('error', ex);
            });
          break;
        case 19:
          this.sharedService.customGetApi("Report/GetWeeklyPurchaseReport?CompanyId=" + this.RememberCompany.company.id + "&FinancialYearId=" + this.RememberCompany.financialyear.id)
            .subscribe((data: any) => {
              this.PurchaseReportList = data.data;
              this.loading = false;
              console.log(this.PurchaseReportList);
            }, (ex: any) => {
              this.loading = false;
              this.showMessage('error', ex);
            });
          break;
        case 20:
          this.sharedService.customGetApi("Report/GetBalanceSheetReport?CompanyId=" + this.RememberCompany.company.id + "&FinancialYearId=" + this.RememberCompany.financialyear.id)
            .subscribe((data: any) => {
              this.PurchaseReportList = data.data;
              this.loading = false;
              console.log(this.PurchaseReportList);
            }, (ex: any) => {
              this.loading = false;
              this.showMessage('error', ex);
            });
          break;
        case 21:
          this.sharedService.customGetApi("Report/GetProfitLossReport?CompanyId=" + this.RememberCompany.company.id + "&FinancialYearId=" + this.RememberCompany.financialyear.id)
            .subscribe((data: any) => {
              this.PurchaseReportList = data.data;
              this.loading = false;
              console.log(this.PurchaseReportList);
            }, (ex: any) => {
              this.loading = false;
              this.showMessage('error', ex);
            });
          break;
        default:
          break;
      }
      this.filterColumn = this.columnArray.filter(e => e.dataType == "text" || e.dataType == "numeric").map(column => column.fieldName).filter(Boolean);

    }
    catch (e) {
      alert("Try catch error : " + JSON.stringify(e));
    }
  }

  childReportSearch(event: any): string {
    return event.target.value;
  }

  showDetail(rowIndex: number, itemData: any) {
    if (this.selectedRowIndex === rowIndex) {
      this.childColumnArray = [];
      this.childReportList = [];
      this.childTotalColumn = 0;
      this.childFilterColumn = [];
      this.selectedRowIndex = -1; // Hide the detail table if the button is clicked again
    } else {
      this.selectedRowIndex = rowIndex; // Show the detail table for the selected row
      switch (this.reportIndex) {
        case 1:
          this.loading = true;
          this.sharedService.customGetApi("Report/GetPurcahseDetailReport?purchaseId=" + itemData.purId)
            .subscribe((data: any) => {
              this.childColumnArray = [
                { "displayName": "Shape Name", "dataType": "text", "fieldName": "shapeName", "minWidth": "15" },
                { "displayName": "Size Name", "dataType": "text", "fieldName": "sizeName", "minWidth": "15" },
                { "displayName": "Purity Name", "dataType": "text", "fieldName": "purityName", "minWidth": "15" },
                { "displayName": "Weight", "dataType": "numeric", "fieldName": "weight" },
                { "displayName": "Tip Weight", "dataType": "numeric", "fieldName": "tipWeight" },
                { "displayName": "CVD Weight", "dataType": "numeric", "fieldName": "cvdWeight" },
                { "displayName": "CVD Amount", "dataType": "numeric", "fieldName": "cvdAmount" },
                { "displayName": "Net Weight", "dataType": "numeric", "fieldName": "netWeight" },
                { "displayName": "Buying Rate", "dataType": "numeric", "fieldName": "buyingRate" },
                { "displayName": "Amount", "dataType": "numeric", "fieldName": "amount" },
              ];
              this.childReportList = data.data;
              if (this.columnArray.length > 0)
                this.childTotalColumn = this.columnArray.length
              else
                this.childTotalColumn = this.childColumnArray.length;
              this.loading = false;
              console.log(data.data);
            }, (ex: any) => {
              this.loading = false;
              this.showMessage('error', ex);
            });
          break;
        case 2:
          this.loading = true;
          this.sharedService.customGetApi("Report/GetSaleDetailReport?salesId=" + itemData.id)
            .subscribe((data: any) => {
              this.childColumnArray = [
                { "displayName": "Shape Name", "dataType": "text", "fieldName": "shapeName", "minWidth": "15" },
                { "displayName": "Size Name", "dataType": "text", "fieldName": "sizeName", "minWidth": "15" },
                { "displayName": "Purity Name", "dataType": "text", "fieldName": "purityName", "minWidth": "15" },
                { "displayName": "Charni Size Name", "dataType": "text", "fieldName": "charniSizeName", "minWidth": "20" },
                { "displayName": "Number Size Name", "dataType": "text", "fieldName": "numberSizeName", "minWidth": "20" },
                { "displayName": "Gala Size Name", "dataType": "text", "fieldName": "galaSizeName", "minWidth": "20" },
                { "displayName": "Weight", "dataType": "numeric", "fieldName": "weight" },
                { "displayName": "Tip Weight", "dataType": "numeric", "fieldName": "tipWeight" },
                { "displayName": "CVD Weight", "dataType": "numeric", "fieldName": "cvdWeight" },
                { "displayName": "CVD Amount", "dataType": "numeric", "fieldName": "cvdAmount" },
                { "displayName": "Net Weight", "dataType": "numeric", "fieldName": "netWeight" },
                { "displayName": "Sale Rate", "dataType": "numeric", "fieldName": "saleRate" },
                { "displayName": "Amount", "dataType": "numeric", "fieldName": "amount" },
              ];
              this.childReportList = data.data;
              if (this.columnArray.length > 0)
                this.childTotalColumn = this.columnArray.length
              else
                this.childTotalColumn = this.childColumnArray.length;
              this.loading = false;
              console.log(data.data);
            }, (ex: any) => {
              this.loading = false;
              this.showMessage('error', ex);
            });
          break;
        case 10:
          this.loading = true;
          this.sharedService.customGetApi("Report/GetLedgerDetail?CompanyId=" + this.RememberCompany.company.id + "&FinancialYearId=" + this.RememberCompany.financialyear.id + "&ledgerId=" + itemData.ledgerId)
            .subscribe((data: any) => {
              this.childColumnArray = [
                { "displayName": "Slip No", "dataType": "numeric", "fieldName": "slipNo" },
                { "displayName": "Entry Date", "dataType": "Date", "fieldName": "date", "ishidefilter": true },
                { "displayName": "Entry Type", "dataType": "text", "fieldName": "entryType", "minWidth": "15" },
                { "displayName": "From Party Name", "dataType": "text", "fieldName": "fromPartyName", "minWidth": "15" },
                { "displayName": "To Party Name", "dataType": "text", "fieldName": "toPartyName", "minWidth": "15" },
                { "displayName": "Remarks", "dataType": "text", "fieldName": "remarks", "minWidth": "15" },
                { "displayName": "Debit", "dataType": "numeric", "fieldName": "debit" },
                { "displayName": "Credit", "dataType": "numeric", "fieldName": "credit" },
              ];
              this.childReportList = data.data;
              if (this.columnArray.length > 0)
                this.childTotalColumn = this.columnArray.length
              else
                this.childTotalColumn = this.childColumnArray.length;
              this.loading = false;
              console.log(data.data);
            }, (ex: any) => {
              this.loading = false;
              this.showMessage('error', ex);
            })
          break;
        case 17:
          if (itemData.name == "Kapan") {
            this.loading = true;
            this.sharedService.customGetApi("Report/GetStockKapanReport?CompanyId=" + this.RememberCompany.company.id + "&FinancialYearId=" + this.RememberCompany.financialyear.id)
              .subscribe((data: any) => {
                this.childColumnArray = [
                  { "displayName": "Branch", "dataType": "text", "fieldName": "branchName", "minWidth": "15" },
                  { "displayName": "Kapan Name", "dataType": "text", "fieldName": "name", "minWidth": "15" },
                  { "displayName": "Operation Type", "dataType": "text", "fieldName": "party", "minWidth": "15" },
                  { "displayName": "Inward Weight", "dataType": "numeric", "fieldName": "inwardNetWeight" },
                  { "displayName": "Inward Rate", "dataType": "numeric", "fieldName": "inwardRate" },
                  { "displayName": "Inward Amount", "dataType": "numeric", "fieldName": "inwardAmount" },
                  { "displayName": "Outward Weight", "dataType": "numeric", "fieldName": "outwardNetWeight" },
                  { "displayName": "Outward Rate", "dataType": "numeric", "fieldName": "outwardRate" },
                  { "displayName": "Outward Amount", "dataType": "numeric", "fieldName": "outwardAmount" },
                  { "displayName": "Closing Net Weight", "dataType": "numeric", "fieldName": "closingNetWeight" },
                  { "displayName": "Closing Rate", "dataType": "numeric", "fieldName": "closingRate" },
                  { "displayName": "Closing Amount", "dataType": "numeric", "fieldName": "closingAmount" },
                ];

                this.childReportList = data.data;
                this.childTotalColumn = this.childColumnArray.length;
                //this.childFilterColumn = this.childColumnArray.filter(e => e.dataType == "text" || e.dataType == "numeric").map(column => column.fieldName).filter(Boolean);
                this.loading = false;
                console.log(data.data);
              }, (ex: any) => {
                this.loading = false;
                this.showMessage('error', ex);
              });
          }
          else if (itemData.name == "Number") {
            this.loading = true;
            this.sharedService.customGetApi("Report/GetStockNumberReport?CompanyId=" + this.RememberCompany.company.id + "&FinancialYearId=" + this.RememberCompany.financialyear.id)
              .subscribe((data: any) => {
                this.childColumnArray = [
                  { "displayName": "Branch Name", "dataType": "text", "fieldName": "branchName", "minWidth": "15" },
                  { "displayName": "Kapan", "dataType": "text", "fieldName": "kapan", "minWidth": "10" },
                  { "displayName": "Number", "dataType": "text", "fieldName": "number", "minWidth": "10" },
                  { "displayName": "Size", "dataType": "text", "fieldName": "size", "minWidth": "10" },
                  { "displayName": "Operation Type", "dataType": "text", "fieldName": "operationType", "minWidth": "15" },
                  { "displayName": "Category", "dataType": "text", "fieldName": "category", "minWidth": "10" },
                  { "displayName": "Inward Weight", "dataType": "numeric", "fieldName": "inwardNetWeight" },
                  { "displayName": "Inward Rate", "dataType": "numeric", "fieldName": "inwardRate" },
                  { "displayName": "Inward Amount", "dataType": "numeric", "fieldName": "inwardAmount" },
                  { "displayName": "Outward Weight", "dataType": "numeric", "fieldName": "outwardNetWeight" },
                  { "displayName": "Outward Rate", "dataType": "numeric", "fieldName": "outwardRate" },
                  { "displayName": "Outward Amount", "dataType": "numeric", "fieldName": "outwardAmount" },
                  { "displayName": "Closing Net Weight", "dataType": "numeric", "fieldName": "closingNetWeight" },
                  { "displayName": "Closing Rate", "dataType": "numeric", "fieldName": "closingRate" },
                  { "displayName": "Closing Amount", "dataType": "numeric", "fieldName": "closingAmount" },
                ];

                this.childReportList = data.data;
                if (this.columnArray.length > 0)
                  this.childTotalColumn = this.columnArray.length
                else
                  this.childTotalColumn = this.childColumnArray.length;
                //this.childFilterColumn = this.childColumnArray.filter(e => e.dataType == "text" || e.dataType == "numeric").map(column => column.fieldName).filter(Boolean);
                this.loading = false;
                console.log(data.data);
              }, (ex: any) => {
                this.loading = false;
                this.showMessage('error', ex);
              });
          }
          break;
        case 19:
          this.loading = true;
          this.sharedService.customGetApi("Report/GetWeeklyPurchaseDetailReport?currentWeek=" + itemData.weekNo + "&CompanyId=" + this.RememberCompany.company.id + "&FinancialYearId=" + this.RememberCompany.financialyear.id)
            .subscribe((data: any) => {
              this.childColumnArray = [
                { "displayName": "Date", "dataType": "Date", "fieldName": "date", "ishidefilter": true },
                { "displayName": "Slip No", "dataType": "text", "fieldName": "slipNo", "minWidth": "10" },
                { "displayName": "Party Name", "dataType": "text", "fieldName": "partyName", "minWidth": "15" },
                { "displayName": "Brok.Name", "dataType": "text", "fieldName": "brokerName", "minWidth": "15" },
                { "displayName": "Kapan Name", "dataType": "text", "fieldName": "kapanName", "minWidth": "15" },
                { "displayName": "Net Cts", "dataType": "numeric", "fieldName": "netWeight" },
                { "displayName": "Buy Rate", "dataType": "numeric", "fieldName": "buyingRate" },
                { "displayName": "Less", "dataType": "numeric", "fieldName": "lessWeight" },
                { "displayName": "CVD Amt", "dataType": "numeric", "fieldName": "cvdAmount" },
                { "displayName": "Due Days", "dataType": "numeric", "fieldName": "dueDays" },
                { "displayName": "Pay Days", "dataType": "numeric", "fieldName": "paymentDays" },
                { "displayName": "Due Date", "dataType": "Date", "fieldName": "dueDate", "ishidefilter": true },
                { "displayName": "Total", "dataType": "numeric", "fieldName": "total" },
                { "displayName": "Adjust Amount", "dataType": "numeric", "fieldName": "adjustAmount" }
              ];
              this.childReportList = data.data;
              if (this.columnArray.length > 0)
                this.childTotalColumn = this.columnArray.length
              else
                this.childTotalColumn = this.childColumnArray.length;
              this.loading = false;
            }, (ex: any) => {
              this.loading = false;
              this.showMessage('error', ex);
            });
          break;
      }

    }
  }


  exportExcel() {
    // import('xlsx').then((xlsx) => {
    //   const worksheet = xlsx.utils.json_to_sheet(this.PurchaseReportList);
    //   const workbook = { Sheets: { data: worksheet }, SheetNames: ['data'] };
    //   const excelBuffer: any = xlsx.write(workbook, { bookType: 'xlsx', type: 'array' });
    //   this.saveAsExcelFile(excelBuffer, 'report');
    // });

   

    let exportColumns: any[];
    let colArray: any[] = [];
    switch (this.reportIndex) {
      case 1:
        this.loading = true;
        colArray = [
          { "displayName": "Date", "dataType": "Date", "fieldName": "date" },
          { "displayName": "Branch", "dataType": "text", "fieldName": "branchName" },
          { "displayName": "SlipNo", "dataType": "numeric", "fieldName": "slipNo" },
          { "displayName": "Party", "dataType": "text", "fieldName": "partyName" },
          { "displayName": "Broker", "dataType": "text", "fieldName": "brokerName" },
          { "displayName": "Kapan", "dataType": "text", "fieldName": "kapanName" },
          { "displayName": "NetCts", "dataType": "numeric", "fieldName": "netWeight" },
          { "displayName": "BuyRate", "dataType": "numeric", "fieldName": "buyingRate" },
          { "displayName": "Less", "dataType": "numeric", "fieldName": "lessWeight" },
          { "displayName": "CVDAmt", "dataType": "numeric", "fieldName": "cvdAmount" },
          { "displayName": "DueDays", "dataType": "numeric", "fieldName": "dueDays" },
          { "displayName": "PayDays", "dataType": "numeric", "fieldName": "paymentDays" },
          { "displayName": "DueDate", "dataType": "Date", "fieldName": "dueDate" },
          { "displayName": "Total", "dataType": "numeric", "fieldName": "total" },
          { "displayName": "Status", "dataType": "text", "fieldName": "approvalType" },
        ];
        break;
      case 2:
        colArray = [
          { "displayName": "Date", "dataType": "Date", "fieldName": "date", "ishidefilter": true },
          { "displayName": "Branch Name", "dataType": "text", "fieldName": "branchName", "minWidth": "15" },
          { "displayName": "Slip No", "dataType": "numeric", "fieldName": "slipNo" },
          { "displayName": "Party Name", "dataType": "text", "fieldName": "partyName", "minWidth": "15" },
          { "displayName": "Broker Name", "dataType": "text", "fieldName": "brokerName", "minWidth": "15" },
          { "displayName": "Kapan Name", "dataType": "text", "fieldName": "kapanName", "minWidth": "15" },
          { "displayName": "Net Cts", "dataType": "numeric", "fieldName": "netWeight" },
          { "displayName": "Sale Rate", "dataType": "numeric", "fieldName": "saleRate" },
          { "displayName": "Less", "dataType": "numeric", "fieldName": "lessWeight" },
          { "displayName": "CVD Amount", "dataType": "numeric", "fieldName": "cvdAmount" },
          { "displayName": "Pay Days", "dataType": "numeric", "fieldName": "paymentDays" },
          { "displayName": "Due Days", "dataType": "numeric", "fieldName": "dueDays" },
          { "displayName": "Due Date", "dataType": "Date", "fieldName": "dueDate", "ishidefilter": true },
          { "displayName": "Total", "dataType": "numeric", "fieldName": "total" },
          { "displayName": "Remarks", "dataType": "text", "fieldName": "remarks", "minWidth": "15" },
          { "displayName": "Message", "dataType": "text", "fieldName": "message", "minWidth": "15" }
          // {"displayName":"Approval Type","dataType":"boolean","fieldName":"approvalType","minWidth":"3"}
        ];
        break;
      case 3:
        colArray = [
          { "displayName": "Date", "dataType": "Date", "fieldName": "entryDate", "ishidefilter": true },
          { "displayName": "To Party", "dataType": "text", "fieldName": "toName", "minWidth": "15" },
          { "displayName": "From Party", "dataType": "text", "fieldName": "fromName", "minWidth": "15" },
          { "displayName": "Amount", "dataType": "numeric", "fieldName": "amount" },
          { "displayName": "Cheque No", "dataType": "text", "fieldName": "chequeNo" },
          { "displayName": "Cheque Date", "dataType": "Date", "fieldName": "chequeDate", "minWidth": "15", "ishidefilter": true },
          { "displayName": "Remarks", "dataType": "text", "fieldName": "remarks", "minWidth": "15" },
          { "displayName": "Approval Status", "dataType": "text", "fieldName": "approvalType" },
          // { "displayName": "Approve", "dataType": "text", "fieldName": "approvalType", "minWidth": "10", "reportid": "groupId", "ishidefilter": true },
          // { "displayName": "Reject", "dataType": "text", "fieldName": "approvalType", "minWidth": "10", "reportid": "groupId", "ishidefilter": true }
        ];
        break;
      case 4:
        colArray = [
          { "displayName": "Date", "dataType": "Date", "fieldName": "entryDate", "ishidefilter": true },
          { "displayName": "To Party", "dataType": "text", "fieldName": "toName", "minWidth": "15" },
          { "displayName": "From Party", "dataType": "text", "fieldName": "fromName", "minWidth": "15" },
          { "displayName": "Amount", "dataType": "numeric", "fieldName": "amount" },
          { "displayName": "Cheque No", "dataType": "text", "fieldName": "chequeNo" },
          { "displayName": "Cheque Date", "dataType": "Date", "fieldName": "chequeDate", "minWidth": "15", "ishidefilter": true },
          { "displayName": "Remarks", "dataType": "text", "fieldName": "remarks", "minWidth": "15" },
          { "displayName": "Approval Status", "dataType": "text", "fieldName": "approvalType" },
        ];
        break;
      case 5:
        colArray = [
          { "displayName": "Date", "dataType": "Date", "fieldName": "entryDate", "ishidefilter": true },
          { "displayName": "From Party", "dataType": "text", "fieldName": "fromPartyName", "minWidth": "15" },
          { "displayName": "To Party", "dataType": "text", "fieldName": "toPartyName", "minWidth": "15" },
          { "displayName": "Cheque No", "dataType": "text", "fieldName": "chequeNo" },
          { "displayName": "Cheque Date", "dataType": "Date", "fieldName": "chequeDate", "minWidth": "15", "ishidefilter": true },
          { "displayName": "Amount", "dataType": "numeric", "fieldName": "amount" },
          { "displayName": "Remarks", "dataType": "text", "fieldName": "remarks", "minWidth": "15" },
        ];
        break;
      case 6:
        colArray = [
          { "displayName": "Date", "dataType": "Date", "fieldName": "entryDate", "ishidefilter": true },
          { "displayName": "SrNo", "dataType": "numeric", "fieldName": "srNo" },
          { "displayName": "Branch Name", "dataType": "text", "fieldName": "branchName", "minWidth": "15" },
          { "displayName": "From Party", "dataType": "text", "fieldName": "fromPartyName", "minWidth": "15" },
          { "displayName": "To Party", "dataType": "text", "fieldName": "toPartyName", "minWidth": "15" },
          { "displayName": "Amount", "dataType": "numeric", "fieldName": "amount" },
          { "displayName": "Remarks", "dataType": "text", "fieldName": "remarks", "minWidth": "20" },
        ];
        break;
      case 7:
        colArray = [
          { "displayName": "Sr", "dataType": "numeric", "fieldName": "sr" },
          { "displayName": "Party Name", "dataType": "text", "fieldName": "partyName", "minWidth": "15" },
          { "displayName": "Cash/Bank Party Name", "dataType": "text", "fieldName": "cashBankName", "minWidth": "25" },
          { "displayName": "Amount", "dataType": "numeric", "fieldName": "amount" },
          { "displayName": "Duration Type", "dataType": "text", "fieldName": "duratonType", "minWidth": "15" },
          { "displayName": "Start Date", "dataType": "Date", "fieldName": "startDate", "ishidefilter": true },
          { "displayName": "End Date", "dataType": "Date", "fieldName": "endDate", "ishidefilter": true },
          { "displayName": "Interest Rate", "dataType": "numeric", "fieldName": "interestRate" },
          { "displayName": "Total Interest", "dataType": "numeric", "fieldName": "totalInterest" },
          { "displayName": "Net Amount", "dataType": "numeric", "fieldName": "netAmount" },
          { "displayName": "Updated Date", "dataType": "Date", "fieldName": "updatedDate", "ishidefilter": true }
        ];
        break;
      case 8:
        colArray = [
          { "displayName": "Date", "dataType": "Date", "fieldName": "entryDate", "ishidefilter": true },
          { "displayName": "From Party Name", "dataType": "text", "fieldName": "fromName", "minWidth": "15" },
          { "displayName": "To Name", "dataType": "text", "fieldName": "toName", "minWidth": "15" },
          { "displayName": "Remarks", "dataType": "text", "fieldName": "remarks", "minWidth": "20" },
          { "displayName": "Debit", "dataType": "numeric", "fieldName": "debit", "minWidth": "15" },
          { "displayName": "Credit", "dataType": "numeric", "fieldName": "credit", "minWidth": "15" },
        ];
        break;
      case 9:
        colArray = [
          { "displayName": "Type", "dataType": "text", "fieldName": "type" },
          { "displayName": "Party Name", "dataType": "text", "fieldName": "partyName", "minWidth": "15" },
          { "displayName": "Broker Name", "dataType": "text", "fieldName": "brokerName", "minWidth": "15" },
          { "displayName": "Size", "dataType": "numeric", "fieldName": "size", "minWidth": "15" },
          { "displayName": "Number", "dataType": "numeric", "fieldName": "number", "minWidth": "15" },
          { "displayName": "Weight", "dataType": "numeric", "fieldName": "weight", "minWidth": "15" },
          { "displayName": "Net Weight", "dataType": "numeric", "fieldName": "netWeight", "minWidth": "15" },
          { "displayName": "Rate", "dataType": "numeric", "fieldName": "rate", "minWidth": "15" },
          { "displayName": "Amount", "dataType": "numeric", "fieldName": "amount", "minWidth": "15" },
          { "displayName": "Created Date", "dataType": "Date", "fieldName": "createdDate", "ishidefilter": true }
        ];
        break;
      case 10:
        colArray = [
          { "displayName": "Type", "dataType": "text", "fieldName": "type", "minWidth": "15" },
          { "displayName": "Name", "dataType": "text", "fieldName": "name", "minWidth": "15" },
          { "displayName": "Sub Type", "dataType": "text", "fieldName": "subType", "minWidth": "15" },
          { "displayName": "Closing Balance", "dataType": "numeric", "fieldName": "closingBalance", "minWidth": "20" },
        ];
        break;
      case 11:
        colArray = [
          { "displayName": "Date", "dataType": "Date", "fieldName": "entryDate", "ishidefilter": true },
          { "displayName": "Slip No", "dataType": "numeric", "fieldName": "slipNo" },
          { "displayName": "Type", "dataType": "text", "fieldName": "type", "minWidth": "15" },
          { "displayName": "Name", "dataType": "text", "fieldName": "name", "minWidth": "15" },
          { "displayName": "Broker", "dataType": "text", "fieldName": "brokerName", "minWidth": "20" },
          { "displayName": "Total", "dataType": "numeric", "fieldName": "total" }
        ];
        break;
      case 12:
        colArray = [
          { "displayName": "Date", "dataType": "Date", "fieldName": "entryDate", "ishidefilter": true },
          { "displayName": "Slip No", "dataType": "numeric", "fieldName": "slipNo" },
          { "displayName": "Type", "dataType": "text", "fieldName": "type", "minWidth": "15" },
          { "displayName": "Name", "dataType": "text", "fieldName": "name", "minWidth": "15" },
          { "displayName": "Broker", "dataType": "text", "fieldName": "brokerName", "minWidth": "20" },
          { "displayName": "Total", "dataType": "numeric", "fieldName": "total" }
        ];
        break;
      case 13:
        colArray = [
          { "displayName": "Date", "dataType": "Date", "fieldName": "entryDate", "ishidefilter": true },
          { "displayName": "From Party", "dataType": "text", "fieldName": "fromParty", "minWidth": "15" },
          { "displayName": "To Party", "dataType": "text", "fieldName": "toParty", "minWidth": "15" },
          { "displayName": "Remarks", "dataType": "text", "fieldName": "remarks", "minWidth": "20" },
          { "displayName": "Debit", "dataType": "numeric", "fieldName": "debit", "minWidth": "15" },
          { "displayName": "Credit", "dataType": "numeric", "fieldName": "credit", "minWidth": "15" },
        ];
        break;
      case 14:
        colArray = [
          { "displayName": "Sr No", "dataType": "numeric", "fieldName": "srNo" },
          { "displayName": "Sr", "dataType": "numeric", "fieldName": "sr" },
          { "displayName": "To Party Name", "dataType": "text", "fieldName": "toPartyName", "minWidth": "20" },
          { "displayName": "Date", "dataType": "Date", "fieldName": "salaryMonthDateTime", "ishidefilter": true },
          { "displayName": "Worked Days/Hrs", "dataType": "numeric", "fieldName": "workedDays", "minWidth": "20" },
          { "displayName": "Month", "dataType": "numeric", "fieldName": "workedDays" },
          { "displayName": "OT Hrs(-)", "dataType": "numeric", "fieldName": "otMinusHrs" },
          { "displayName": "OT Rate(-)", "dataType": "numeric", "fieldName": "otMinusRate" },
          { "displayName": "OT Hrs(+)", "dataType": "numeric", "fieldName": "otPlusHrs" },
          { "displayName": "OT Rate(+)", "dataType": "numeric", "fieldName": "otPlusRate" },
          { "displayName": "Rounf(+/-)", "dataType": "numeric", "fieldName": "roundOfAmount" },
          { "displayName": "Total Salary", "dataType": "numeric", "fieldName": "salaryAmount" },
          { "displayName": "Remarks", "dataType": "text", "fieldName": "remarks", "minWidth": "20" },
        ];
        break;
      case 15:
        colArray = [
          { "displayName": "Date", "dataType": "Date", "fieldName": "entryDate", "ishidefilter": true },
          { "displayName": "SrNo", "dataType": "numeric", "fieldName": "srNo" },
          { "displayName": "Slip No", "dataType": "text", "fieldName": "slipNo" },
          { "displayName": "Party Name", "dataType": "text", "fieldName": "partyName", "minWidth": "20" },
          { "displayName": "Broker Name", "dataType": "text", "fieldName": "brokerName", "minWidth": "20" },
          { "displayName": "Size Name", "dataType": "text", "fieldName": "sizeName" },
          { "displayName": "Charni Size Name", "dataType": "text", "fieldName": "charniSizeName", "minWidth": "20" },
          { "displayName": "Gala Size Name", "dataType": "text", "fieldName": "galaSizeName", "minWidth": "20" },
          { "displayName": "Number Size Name", "dataType": "text", "fieldName": "numberSizeName", "minWidth": "20" },
          { "displayName": "Purity Name", "dataType": "text", "fieldName": "purityName", "minWidth": "20" },
          { "displayName": "Rate  ", "dataType": "numeric", "fieldName": "rate" },
          { "displayName": "Carat", "dataType": "numeric", "fieldName": "totalCarat" },
          { "displayName": "Amount", "dataType": "numeric", "fieldName": "amount" },
          { "displayName": "Remarks", "dataType": "text", "fieldName": "remarks", "minWidth": "20" },
        ];
        break;
      case 16:
        colArray = [
          { "displayName": "Date", "dataType": "Date", "fieldName": "entryDate", "ishidefilter": true },
          { "displayName": "SrNo", "dataType": "numeric", "fieldName": "srNo" },
          { "displayName": "Slip No", "dataType": "text", "fieldName": "slipNo" },
          { "displayName": "Party Name", "dataType": "text", "fieldName": "partyName", "minWidth": "20" },
          { "displayName": "Broker Name", "dataType": "text", "fieldName": "brokerName", "minWidth": "20" },
          { "displayName": "Size Name", "dataType": "text", "fieldName": "sizeName" },
          { "displayName": "Charni Size Name", "dataType": "text", "fieldName": "charniSizeName", "minWidth": "20" },
          { "displayName": "Gala Size Name", "dataType": "text", "fieldName": "galaSizeName", "minWidth": "20" },
          { "displayName": "Number Size Name", "dataType": "text", "fieldName": "numberSizeName", "minWidth": "20" },
          { "displayName": "Purity Name", "dataType": "text", "fieldName": "purityName", "minWidth": "20" },
          { "displayName": "Rate  ", "dataType": "numeric", "fieldName": "rate" },
          { "displayName": "Carat", "dataType": "numeric", "fieldName": "totalCarat" },
          { "displayName": "Amount", "dataType": "numeric", "fieldName": "amount" },
          { "displayName": "Remarks", "dataType": "text", "fieldName": "remarks", "minWidth": "20" },
        ];
        break;
      case 17:
        colArray = [
          { "displayName": "Type", "dataType": "text", "fieldName": "name", "minWidth": "10" },
          { "displayName": "Total Weight", "dataType": "numeric", "fieldName": "totalWeight", "minWidth": "20" },
          { "displayName": "Rate", "dataType": "numeric", "fieldName": "rate" },
          { "displayName": "Total Amount", "dataType": "numeric", "fieldName": "totalAmount", "minWidth": "20" }
        ];
        break;
      case 18:
        colArray = [
          { "displayName": "SrNo", "dataType": "numeric", "fieldName": "srNo" },
          { "displayName": "Branch", "dataType": "text", "fieldName": "branchName", "minWidth": "15" },
          { "displayName": "Kapan", "dataType": "text", "fieldName": "kapanName", "minWidth": "15" },
          { "displayName": "Size", "dataType": "text", "fieldName": "sizeName", "minWidth": "10" },
          { "displayName": "Number", "dataType": "text", "fieldName": "numberName", "minWidth": "10" },
          { "displayName": "Total Cts", "dataType": "numeric", "fieldName": "totalCts" },
          { "displayName": "Rate", "dataType": "numeric", "fieldName": "rate" },
          { "displayName": "Amount", "dataType": "numeric", "fieldName": "amount" },
          { "displayName": "Remarks", "dataType": "text", "fieldName": "remarks", "minWidth": "20" },
          { "displayName": "Update Date", "dataType": "Date", "fieldName": "updatedDate", "ishidefilter": true }
        ];
        break;
      case 19:
        colArray = [
          { "displayName": "Week No", "dataType": "text", "fieldName": "weekNo" },
          { "displayName": "Period", "dataType": "text", "fieldName": "period", "minWidth": "20" },
          { "displayName": "Amount", "dataType": "numeric", "fieldName": "amount", "minWidth": "20" }
        ];
        break;
      case 20:
        colArray = [
          { "displayName": "Col Type", "dataType": "text", "fieldName": "colType" },
          { "displayName": "Account Name", "dataType": "text", "fieldName": "type", "minWidth": "20" },
          { "displayName": "Amount", "dataType": "numeric", "fieldName": "amount", "minWidth": "20" }
        ];
        break;
      case 21:
        colArray = [
          { "displayName": "Col Type", "dataType": "text", "fieldName": "colType" },
          { "displayName": "Account Name", "dataType": "text", "fieldName": "type", "minWidth": "20" },
          { "displayName": "Amount", "dataType": "numeric", "fieldName": "amount", "minWidth": "20" }
        ];
        break;
      default:
        colArray = this.columnArray;
        break;
    }
    exportColumns = colArray.map((col) => (col.fieldName));

    
    // Get filtered data from the grid (assuming the grid has a method to get filtered data)

    if (this.dataTable.filteredValue !== undefined && this.dataTable.filteredValue !== null) {
      this.PurchaseReportList = this.dataTable.filteredValue;
    }

    // Calculate footer totals
 const footerTotals : any = [];
 
 for (const col of this.columnArray) {    
  let m: any = {};  
  if (col.fieldName === 'netWeight' || col.fieldName === 'totalCts' || col.fieldName === 'total' ) {
      debugger;
      m["key"] = colArray.find(x => x.fieldName === col.fieldName)?.displayName;
      m["value"] = this.calculateColumnSum(col.fieldName);
      footerTotals.push(m);
    }
  }

    const formatDate = (dateString: string) => {
      const date = new Date(dateString);
      const month = (date.getMonth() + 1).toString().padStart(2, '0');
      const day = date.getDate().toString().padStart(2, '0');
      const year = date.getFullYear();
      return `${month}-${day}-${year}`;
    };

    let extractedData: any[] = this.PurchaseReportList.map((item) => {
      const formattedItem = { ...item };
      for (const key in formattedItem) {
        if (formattedItem.hasOwnProperty(key) && this.isISODateString(formattedItem[key])) {
          formattedItem[key] = formatDate(formattedItem[key]);
        }
      }
      return formattedItem;
    });

    extractedData = extractedData.map((item) =>
      exportColumns.map((column) => item[column])
    );

    debugger;
    const data = {
      "columnsHeaders": colArray.map((col) => (col.displayName)),
      "rowData": extractedData,
      "footerTotals": footerTotals  // Include footer totals in the data
    };
    this.loading = true;
    this.sharedService.customPostApi("Report/downloadexcel", data)
      .subscribe((data: any) => {
        const options: DownloadFileOptions = {
          path: this.PageTitle.replaceAll(" ", '') + ".csv",
          url: data.data,
          directory: Directory.Documents,
        };

        Filesystem.downloadFile(options)
          .then(downloadResult => {
            // Check downloadResult for success
            if (downloadResult) {
              alert("File downloaded successfully.");
            } else {
              alert("File download failed.");
            }

            this.loading = false;
          })
          .catch(ex => {
            console.error("Error downloading file:", ex);
            this.loading = false;
            alert(ex);
          });
        this.loading = false;
      }, (ex: any) => {
        this.loading = false;
        alert(ex);
      });

  }

  exportPdf() {
    let exportColumns: any[];
    let colArray: any[] = [];
    switch (this.reportIndex) {
      case 1:
        this.loading = true;
        colArray = [
          { "displayName": "Date", "dataType": "Date", "fieldName": "date" },
          { "displayName": "Branch", "dataType": "text", "fieldName": "branchName" },
          { "displayName": "SlipNo", "dataType": "numeric", "fieldName": "slipNo" },
          { "displayName": "Party", "dataType": "text", "fieldName": "partyName" },
          { "displayName": "Broker", "dataType": "text", "fieldName": "brokerName" },
          { "displayName": "Kapan", "dataType": "text", "fieldName": "kapanName" },
          { "displayName": "NetCts", "dataType": "numeric", "fieldName": "netWeight" },
          { "displayName": "BuyRate", "dataType": "numeric", "fieldName": "buyingRate" },
          { "displayName": "Less", "dataType": "numeric", "fieldName": "lessWeight" },
          { "displayName": "CVDAmt", "dataType": "numeric", "fieldName": "cvdAmount" },
          { "displayName": "DueDays", "dataType": "numeric", "fieldName": "dueDays" },
          { "displayName": "PayDays", "dataType": "numeric", "fieldName": "paymentDays" },
          { "displayName": "DueDate", "dataType": "Date", "fieldName": "dueDate" },
          { "displayName": "Total", "dataType": "numeric", "fieldName": "total" },
          { "displayName": "Status", "dataType": "text", "fieldName": "approvalType" },
        ];
        break;
      case 2:
        colArray = [
          { "displayName": "Date", "dataType": "Date", "fieldName": "date", "ishidefilter": true },
          { "displayName": "Branch Name", "dataType": "text", "fieldName": "branchName", "minWidth": "15" },
          { "displayName": "Slip No", "dataType": "numeric", "fieldName": "slipNo" },
          { "displayName": "Party Name", "dataType": "text", "fieldName": "partyName", "minWidth": "15" },
          { "displayName": "Broker Name", "dataType": "text", "fieldName": "brokerName", "minWidth": "15" },
          { "displayName": "Kapan Name", "dataType": "text", "fieldName": "kapanName", "minWidth": "15" },
          { "displayName": "Net Cts", "dataType": "numeric", "fieldName": "netWeight" },
          { "displayName": "Sale Rate", "dataType": "numeric", "fieldName": "saleRate" },
          { "displayName": "Less", "dataType": "numeric", "fieldName": "lessWeight" },
          { "displayName": "CVD Amount", "dataType": "numeric", "fieldName": "cvdAmount" },
          { "displayName": "Pay Days", "dataType": "numeric", "fieldName": "paymentDays" },
          { "displayName": "Due Days", "dataType": "numeric", "fieldName": "dueDays" },
          { "displayName": "Due Date", "dataType": "Date", "fieldName": "dueDate", "ishidefilter": true },
          { "displayName": "Total", "dataType": "numeric", "fieldName": "total" },
          { "displayName": "Remarks", "dataType": "text", "fieldName": "remarks", "minWidth": "15" },
          { "displayName": "Message", "dataType": "text", "fieldName": "message", "minWidth": "15" }
          // {"displayName":"Approval Type","dataType":"boolean","fieldName":"approvalType","minWidth":"3"}
        ];
        break;
      case 3:
        colArray = [
          { "displayName": "Date", "dataType": "Date", "fieldName": "entryDate", "ishidefilter": true },
          { "displayName": "To Party", "dataType": "text", "fieldName": "toName", "minWidth": "15" },
          { "displayName": "From Party", "dataType": "text", "fieldName": "fromName", "minWidth": "15" },
          { "displayName": "Amount", "dataType": "numeric", "fieldName": "amount" },
          { "displayName": "Cheque No", "dataType": "text", "fieldName": "chequeNo" },
          { "displayName": "Cheque Date", "dataType": "Date", "fieldName": "chequeDate", "minWidth": "15", "ishidefilter": true },
          { "displayName": "Remarks", "dataType": "text", "fieldName": "remarks", "minWidth": "15" },
          { "displayName": "Approval Status", "dataType": "text", "fieldName": "approvalType" },
          // { "displayName": "Approve", "dataType": "text", "fieldName": "approvalType", "minWidth": "10", "reportid": "groupId", "ishidefilter": true },
          // { "displayName": "Reject", "dataType": "text", "fieldName": "approvalType", "minWidth": "10", "reportid": "groupId", "ishidefilter": true }
        ];
        break;
      case 4:
        colArray = [
          { "displayName": "Date", "dataType": "Date", "fieldName": "entryDate", "ishidefilter": true },
          { "displayName": "To Party", "dataType": "text", "fieldName": "toName", "minWidth": "15" },
          { "displayName": "From Party", "dataType": "text", "fieldName": "fromName", "minWidth": "15" },
          { "displayName": "Amount", "dataType": "numeric", "fieldName": "amount" },
          { "displayName": "Cheque No", "dataType": "text", "fieldName": "chequeNo" },
          { "displayName": "Cheque Date", "dataType": "Date", "fieldName": "chequeDate", "minWidth": "15", "ishidefilter": true },
          { "displayName": "Remarks", "dataType": "text", "fieldName": "remarks", "minWidth": "15" },
          { "displayName": "Approval Status", "dataType": "text", "fieldName": "approvalType" },
        ];
        break;
      case 5:
        colArray = [
          { "displayName": "Date", "dataType": "Date", "fieldName": "entryDate", "ishidefilter": true },
          { "displayName": "From Party", "dataType": "text", "fieldName": "fromPartyName", "minWidth": "15" },
          { "displayName": "To Party", "dataType": "text", "fieldName": "toPartyName", "minWidth": "15" },
          { "displayName": "Cheque No", "dataType": "text", "fieldName": "chequeNo" },
          { "displayName": "Cheque Date", "dataType": "Date", "fieldName": "chequeDate", "minWidth": "15", "ishidefilter": true },
          { "displayName": "Amount", "dataType": "numeric", "fieldName": "amount" },
          { "displayName": "Remarks", "dataType": "text", "fieldName": "remarks", "minWidth": "15" },
        ];
        break;
      case 6:
        colArray = [
          { "displayName": "Date", "dataType": "Date", "fieldName": "entryDate", "ishidefilter": true },
          { "displayName": "SrNo", "dataType": "numeric", "fieldName": "srNo" },
          { "displayName": "Branch Name", "dataType": "text", "fieldName": "branchName", "minWidth": "15" },
          { "displayName": "From Party", "dataType": "text", "fieldName": "fromPartyName", "minWidth": "15" },
          { "displayName": "To Party", "dataType": "text", "fieldName": "toPartyName", "minWidth": "15" },
          { "displayName": "Amount", "dataType": "numeric", "fieldName": "amount" },
          { "displayName": "Remarks", "dataType": "text", "fieldName": "remarks", "minWidth": "20" },
        ];
        break;
      case 7:
        colArray = [
          { "displayName": "Sr", "dataType": "numeric", "fieldName": "sr" },
          { "displayName": "Party Name", "dataType": "text", "fieldName": "partyName", "minWidth": "15" },
          { "displayName": "Cash/Bank Party Name", "dataType": "text", "fieldName": "cashBankName", "minWidth": "25" },
          { "displayName": "Amount", "dataType": "numeric", "fieldName": "amount" },
          { "displayName": "Duration Type", "dataType": "text", "fieldName": "duratonType", "minWidth": "15" },
          { "displayName": "Start Date", "dataType": "Date", "fieldName": "startDate", "ishidefilter": true },
          { "displayName": "End Date", "dataType": "Date", "fieldName": "endDate", "ishidefilter": true },
          { "displayName": "Interest Rate", "dataType": "numeric", "fieldName": "interestRate" },
          { "displayName": "Total Interest", "dataType": "numeric", "fieldName": "totalInterest" },
          { "displayName": "Net Amount", "dataType": "numeric", "fieldName": "netAmount" },
          { "displayName": "Updated Date", "dataType": "Date", "fieldName": "updatedDate", "ishidefilter": true }
        ];
        break;
      case 8:
        colArray = [
          { "displayName": "Date", "dataType": "Date", "fieldName": "entryDate", "ishidefilter": true },
          { "displayName": "From Party Name", "dataType": "text", "fieldName": "fromName", "minWidth": "15" },
          { "displayName": "To Name", "dataType": "text", "fieldName": "toName", "minWidth": "15" },
          { "displayName": "Remarks", "dataType": "text", "fieldName": "remarks", "minWidth": "20" },
          { "displayName": "Debit", "dataType": "numeric", "fieldName": "debit", "minWidth": "15" },
          { "displayName": "Credit", "dataType": "numeric", "fieldName": "credit", "minWidth": "15" },
        ];
        break;
      case 9:
        colArray = [
          { "displayName": "Type", "dataType": "text", "fieldName": "type" },
          { "displayName": "Party Name", "dataType": "text", "fieldName": "partyName", "minWidth": "15" },
          { "displayName": "Broker Name", "dataType": "text", "fieldName": "brokerName", "minWidth": "15" },
          { "displayName": "Size", "dataType": "numeric", "fieldName": "size", "minWidth": "15" },
          { "displayName": "Number", "dataType": "numeric", "fieldName": "number", "minWidth": "15" },
          { "displayName": "Weight", "dataType": "numeric", "fieldName": "weight", "minWidth": "15" },
          { "displayName": "Net Weight", "dataType": "numeric", "fieldName": "netWeight", "minWidth": "15" },
          { "displayName": "Rate", "dataType": "numeric", "fieldName": "rate", "minWidth": "15" },
          { "displayName": "Amount", "dataType": "numeric", "fieldName": "amount", "minWidth": "15" },
          { "displayName": "Created Date", "dataType": "Date", "fieldName": "createdDate", "ishidefilter": true }
        ];
        break;
      case 10:
        colArray = [
          { "displayName": "Type", "dataType": "text", "fieldName": "type", "minWidth": "15" },
          { "displayName": "Name", "dataType": "text", "fieldName": "name", "minWidth": "15" },
          { "displayName": "Sub Type", "dataType": "text", "fieldName": "subType", "minWidth": "15" },
          { "displayName": "Closing Balance", "dataType": "numeric", "fieldName": "closingBalance", "minWidth": "20" },
        ];
        break;
      case 11:
        colArray = [
          { "displayName": "Date", "dataType": "Date", "fieldName": "entryDate", "ishidefilter": true },
          { "displayName": "Slip No", "dataType": "numeric", "fieldName": "slipNo" },
          { "displayName": "Type", "dataType": "text", "fieldName": "type", "minWidth": "15" },
          { "displayName": "Name", "dataType": "text", "fieldName": "name", "minWidth": "15" },
          { "displayName": "Broker", "dataType": "text", "fieldName": "brokerName", "minWidth": "20" },
          { "displayName": "Total", "dataType": "numeric", "fieldName": "total" }
        ];
        break;
      case 12:
        colArray = [
          { "displayName": "Date", "dataType": "Date", "fieldName": "entryDate", "ishidefilter": true },
          { "displayName": "Slip No", "dataType": "numeric", "fieldName": "slipNo" },
          { "displayName": "Type", "dataType": "text", "fieldName": "type", "minWidth": "15" },
          { "displayName": "Name", "dataType": "text", "fieldName": "name", "minWidth": "15" },
          { "displayName": "Broker", "dataType": "text", "fieldName": "brokerName", "minWidth": "20" },
          { "displayName": "Total", "dataType": "numeric", "fieldName": "total" }
        ];
        break;
      case 13:
        colArray = [
          { "displayName": "Date", "dataType": "Date", "fieldName": "entryDate", "ishidefilter": true },
          { "displayName": "From Party", "dataType": "text", "fieldName": "fromParty", "minWidth": "15" },
          { "displayName": "To Party", "dataType": "text", "fieldName": "toParty", "minWidth": "15" },
          { "displayName": "Remarks", "dataType": "text", "fieldName": "remarks", "minWidth": "20" },
          { "displayName": "Debit", "dataType": "numeric", "fieldName": "debit", "minWidth": "15" },
          { "displayName": "Credit", "dataType": "numeric", "fieldName": "credit", "minWidth": "15" },
        ];
        break;
      case 14:
        colArray = [
          { "displayName": "Sr No", "dataType": "numeric", "fieldName": "srNo" },
          { "displayName": "Sr", "dataType": "numeric", "fieldName": "sr" },
          { "displayName": "To Party Name", "dataType": "text", "fieldName": "toPartyName", "minWidth": "20" },
          { "displayName": "Date", "dataType": "Date", "fieldName": "salaryMonthDateTime", "ishidefilter": true },
          { "displayName": "Worked Days/Hrs", "dataType": "numeric", "fieldName": "workedDays", "minWidth": "20" },
          { "displayName": "Month", "dataType": "numeric", "fieldName": "workedDays" },
          { "displayName": "OT Hrs(-)", "dataType": "numeric", "fieldName": "otMinusHrs" },
          { "displayName": "OT Rate(-)", "dataType": "numeric", "fieldName": "otMinusRate" },
          { "displayName": "OT Hrs(+)", "dataType": "numeric", "fieldName": "otPlusHrs" },
          { "displayName": "OT Rate(+)", "dataType": "numeric", "fieldName": "otPlusRate" },
          { "displayName": "Rounf(+/-)", "dataType": "numeric", "fieldName": "roundOfAmount" },
          { "displayName": "Total Salary", "dataType": "numeric", "fieldName": "salaryAmount" },
          { "displayName": "Remarks", "dataType": "text", "fieldName": "remarks", "minWidth": "20" },
        ];
        break;
      case 15:
        colArray = [
          { "displayName": "Date", "dataType": "Date", "fieldName": "entryDate", "ishidefilter": true },
          { "displayName": "SrNo", "dataType": "numeric", "fieldName": "srNo" },
          { "displayName": "Slip No", "dataType": "text", "fieldName": "slipNo" },
          { "displayName": "Party Name", "dataType": "text", "fieldName": "partyName", "minWidth": "20" },
          { "displayName": "Broker Name", "dataType": "text", "fieldName": "brokerName", "minWidth": "20" },
          { "displayName": "Size Name", "dataType": "text", "fieldName": "sizeName" },
          { "displayName": "Charni Size Name", "dataType": "text", "fieldName": "charniSizeName", "minWidth": "20" },
          { "displayName": "Gala Size Name", "dataType": "text", "fieldName": "galaSizeName", "minWidth": "20" },
          { "displayName": "Number Size Name", "dataType": "text", "fieldName": "numberSizeName", "minWidth": "20" },
          { "displayName": "Purity Name", "dataType": "text", "fieldName": "purityName", "minWidth": "20" },
          { "displayName": "Rate  ", "dataType": "numeric", "fieldName": "rate" },
          { "displayName": "Carat", "dataType": "numeric", "fieldName": "totalCarat" },
          { "displayName": "Amount", "dataType": "numeric", "fieldName": "amount" },
          { "displayName": "Remarks", "dataType": "text", "fieldName": "remarks", "minWidth": "20" },
        ];
        break;
      case 16:
        colArray = [
          { "displayName": "Date", "dataType": "Date", "fieldName": "entryDate", "ishidefilter": true },
          { "displayName": "SrNo", "dataType": "numeric", "fieldName": "srNo" },
          { "displayName": "Slip No", "dataType": "text", "fieldName": "slipNo" },
          { "displayName": "Party Name", "dataType": "text", "fieldName": "partyName", "minWidth": "20" },
          { "displayName": "Broker Name", "dataType": "text", "fieldName": "brokerName", "minWidth": "20" },
          { "displayName": "Size Name", "dataType": "text", "fieldName": "sizeName" },
          { "displayName": "Charni Size Name", "dataType": "text", "fieldName": "charniSizeName", "minWidth": "20" },
          { "displayName": "Gala Size Name", "dataType": "text", "fieldName": "galaSizeName", "minWidth": "20" },
          { "displayName": "Number Size Name", "dataType": "text", "fieldName": "numberSizeName", "minWidth": "20" },
          { "displayName": "Purity Name", "dataType": "text", "fieldName": "purityName", "minWidth": "20" },
          { "displayName": "Rate  ", "dataType": "numeric", "fieldName": "rate" },
          { "displayName": "Carat", "dataType": "numeric", "fieldName": "totalCarat" },
          { "displayName": "Amount", "dataType": "numeric", "fieldName": "amount" },
          { "displayName": "Remarks", "dataType": "text", "fieldName": "remarks", "minWidth": "20" },
        ];
        break;
      case 17:
        colArray = [
          { "displayName": "Type", "dataType": "text", "fieldName": "name", "minWidth": "10" },
          { "displayName": "Total Weight", "dataType": "numeric", "fieldName": "totalWeight", "minWidth": "20" },
          { "displayName": "Rate", "dataType": "numeric", "fieldName": "rate" },
          { "displayName": "Total Amount", "dataType": "numeric", "fieldName": "totalAmount", "minWidth": "20" }
        ];
        break;
      case 18:
        colArray = [
          { "displayName": "SrNo", "dataType": "numeric", "fieldName": "srNo" },
          { "displayName": "Branch", "dataType": "text", "fieldName": "branchName", "minWidth": "15" },
          { "displayName": "Kapan", "dataType": "text", "fieldName": "kapanName", "minWidth": "15" },
          { "displayName": "Size", "dataType": "text", "fieldName": "sizeName", "minWidth": "10" },
          { "displayName": "Number", "dataType": "text", "fieldName": "numberName", "minWidth": "10" },
          { "displayName": "Total Cts", "dataType": "numeric", "fieldName": "totalCts" },
          { "displayName": "Rate", "dataType": "numeric", "fieldName": "rate" },
          { "displayName": "Amount", "dataType": "numeric", "fieldName": "amount" },
          { "displayName": "Remarks", "dataType": "text", "fieldName": "remarks", "minWidth": "20" },
          { "displayName": "Update Date", "dataType": "Date", "fieldName": "updatedDate", "ishidefilter": true }
        ];
        break;
      case 19:
        colArray = [
          { "displayName": "Week No", "dataType": "text", "fieldName": "weekNo" },
          { "displayName": "Period", "dataType": "text", "fieldName": "period", "minWidth": "20" },
          { "displayName": "Amount", "dataType": "numeric", "fieldName": "amount", "minWidth": "20" }
        ];
        break;
      case 20:
        colArray = [
          { "displayName": "Col Type", "dataType": "text", "fieldName": "colType" },
          { "displayName": "Account Name", "dataType": "text", "fieldName": "type", "minWidth": "20" },
          { "displayName": "Amount", "dataType": "numeric", "fieldName": "amount", "minWidth": "20" }
        ];
        break;
      case 21:
        colArray = [
          { "displayName": "Col Type", "dataType": "text", "fieldName": "colType" },
          { "displayName": "Account Name", "dataType": "text", "fieldName": "type", "minWidth": "20" },
          { "displayName": "Amount", "dataType": "numeric", "fieldName": "amount", "minWidth": "20" }
        ];
        break;
      default:
        colArray = this.columnArray;
        break;
    }

    if (this.dataTable.filteredValue !== undefined && this.dataTable.filteredValue !== null) {
      this.PurchaseReportList = this.dataTable.filteredValue;
    }
        // Calculate footer totals
 const footerTotals : any = [];
 
 for (const col of this.columnArray) {    
  let m: any = {};  
  if (col.fieldName === 'netWeight' || col.fieldName === 'totalCts' || col.fieldName === 'total' ) {
      m["key"] = colArray.find(x => x.fieldName === col.fieldName)?.displayName;
      m["value"] = this.calculateColumnSum(col.fieldName);
      footerTotals.push(m);
    }
  }
    exportColumns = colArray.map((col) => (col.fieldName));
    const formatDate = (dateString: string) => {
      const date = new Date(dateString);
      const month = (date.getMonth() + 1).toString().padStart(2, '0');
      const day = date.getDate().toString().padStart(2, '0');
      const year = date.getFullYear();
      return `${month}-${day}-${year}`;
    };

    let extractedData: any[] = this.PurchaseReportList.map((item) => {
      const formattedItem = { ...item };
      for (const key in formattedItem) {
        if (formattedItem.hasOwnProperty(key) && this.isISODateString(formattedItem[key])) {
          formattedItem[key] = formatDate(formattedItem[key]);
        }
      }
      return formattedItem;
    });

    extractedData = extractedData.map((item) =>
      exportColumns.map((column) => item[column])
    );

    const data = {
      "columnsHeaders": colArray.map((col) => (col.displayName)),
      "rowData": extractedData,
      "footerTotals": footerTotals
    };
    debugger;

    this.loading = true;
    this.sharedService.customPostApi("Report/downloadpdf", data)
      .subscribe((data: any) => {
        const options: DownloadFileOptions = {
          path: this.PageTitle.replaceAll(" ", '') + ".pdf",
          url: data.data,
          directory: Directory.Documents,
        };

        Filesystem.downloadFile(options)
          .then(downloadResult => {
            // Check downloadResult for success
            if (downloadResult) {
              alert("File downloaded successfully.");
            } else {
              alert("File download failed.");
            }

            this.loading = false;
          })
          .catch(ex => {
            this.loading = false;
            alert(ex);
          });

        this.loading = false;
      }, (ex: any) => {
        this.loading = false;
        alert(ex);
      });
  }

  isISODateString(value: any) {
    return typeof value === 'string' && /^\d{4}-\d{2}-\d{2}T\d{2}:\d{2}:\d{2}$/.test(value);
  }

  showMessage(type: string, message: string) {
    this.messageService.add({ severity: type, summary: message });
  }

// Inside your component class
calculateColumnSum(columnName: string): number {
  let sum = 0;
  for (const item of this.PurchaseReportList) {
    sum +=  item[columnName];
  }
  return sum;
  }

  getCompanyData() {
    try {
      const data = localStorage.getItem("companyremember");
      if (data != null) {
        this.RememberCompany = this.sharedService.JsonConvert<RememberCompany>(data)
      }
    } catch (e) {
      alert(JSON.stringify(e));
    }
  }

  onApproveClick(reportIndex: number, item: any, status: any) {
    this.visible = true;
    this.dialogReportIndex = reportIndex;
    this.reportItemId = item;
    this.ApproveRejectStatus = status;
  }

  formatIndianNumber(amount: number, isSymbol : boolean = true): string {
    const formatter = new Intl.NumberFormat('en-IN', { maximumFractionDigits: 2 });
    return isSymbol? '₹' + formatter.format(amount) : formatter.format(amount);
  }

  onApproveReject() {
    const data = {
      "ReportType": this.dialogReportIndex,
      "Id": this.reportItemId,
      "Comment": this.ApproveRejectComment,
      "Status": this.ApproveRejectStatus
    };
    this.loading = true;
    this.sharedService.customPostApi("Report/ApproveRejectStatus", data)
      .subscribe((data: any) => {
        if (data.success == true) {
          if (this.ApproveRejectStatus == 1) {
            this.showMessage('success', 'Approve successfully.');
          }
          else if (this.ApproveRejectStatus == 2) {
            this.showMessage('success', 'Rejected successfully.');
          }
          this.loading = false;
          this.dialogReportIndex = 0;
          this.reportItemId = '';
          this.ApproveRejectComment = '';
          this.ApproveRejectStatus = 0;
          this.purchseReport(this.firstDate, this.endDate);
          // this.ngOnInit();          
        }
        else {
          this.loading = false;
          this.showMessage('error', 'Something went wrong...');
        }
      }, (ex: any) => {
        this.loading = false;
        this.showMessage('error', ex);
      });
  }
}
