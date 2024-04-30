import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { SharedService } from '../../common/shared.service';
import { RememberCompany } from '../../shared/component/companyselection/companyselection.component';
import { MessageService } from 'primeng/api';
import { Filesystem, Directory, Encoding, DownloadFileOptions } from '@capacitor/filesystem';
import { FileOpener } from '@capacitor-community/file-opener';

@Component({
  selector: 'app-balancesheet',
  templateUrl: './balancesheet.component.html',
  styleUrls: ['./balancesheet.component.scss']
})
export class BalancesheetComponent {

  loading: boolean = true;
  RememberCompany: RememberCompany = new RememberCompany();
  PageTitle = "Balance Sheet";
  balanceSheetData: any[] = [];
  transformedData: any[] = [];
  totalDebitAmount: any;
  totalCreditAmount: any;

  constructor(private rote: Router, private sharedService: SharedService, private messageService: MessageService) {

  }

  goBack() {
    this.rote.navigate(['/dashboard']);
  }

  ngOnInit() {
    this.loading = false;
    this.getCompanyData();
    this.getBalanceSheet();
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

  getBalanceSheet() {
    this.loading = true;
    this.sharedService.customGetApi("Report/GetBalanceSheetReport?CompanyId=" + this.RememberCompany.company.id + "&FinancialYearId=" + this.RememberCompany.financialyear.id)
      .subscribe((data: any) => {
        debugger;
        this.balanceSheetData = data.data;
        this.transformedData = [];
        const debitData: any[] = this.balanceSheetData.filter(e => e.colType == 'Debit');
        const creditData: any[] = this.balanceSheetData.filter(e => e.colType == 'Credit');
        let index = 0;
        if (debitData.length >= creditData.length) {
          debitData.forEach(element => {
            const row: any = {};
            row['DebitColType'] = element.type;
            row['DebitAmount'] = element.amount;

            row['CreditColType'] = creditData.length > index ? creditData[index].type : null;
            row['CreditAmount'] = creditData.length > index ? creditData[index].amount : null;

            index++;
            this.transformedData.push(row);
          });
        }
        else {
          creditData.forEach(element => {
            const row: any = {};
            row['DebitColType'] = debitData.length > index ? debitData[index].type : null;
            row['DebitAmount'] = debitData.length > index ? debitData[index].amount : null;

            row['CreditColType'] = element.type;
            row['CreditAmount'] = element.amount;

            index++;
            this.transformedData.push(row);
          });
        }

        this.totalDebitAmount = debitData.reduce((total, item) => total + (parseFloat(item.amount) || 0), 0);

        this.totalCreditAmount = creditData.reduce((total, item) => total + (parseFloat(item.amount) || 0), 0);
        this.loading = false;
      }, (ex: any) => {
        this.loading = false;
        this.showMessage('error', ex);
      });


  }

  showMessage(type: string, message: string) {
    this.messageService.add({ severity: type, summary: message });
  }

  formatIndianNumber(amount: number): string {
    const formatter = new Intl.NumberFormat('en-IN');
    return formatter.format(amount);
  }

  exportPdf() {
    let exportColumns: any[];
    let colArray: any[] = [];
    colArray = [
      { "displayName": "Account Type", "dataType": "text", "fieldName": "DebitColType" },
      { "displayName": "Debit Amount", "dataType": "numeric", "fieldName": "DebitAmount" },
      { "displayName": "Account Type", "dataType": "text", "fieldName": "CreditColType" },
      { "displayName": "Credit Amount", "dataType": "numeric", "fieldName": "CreditAmount" }
    ];

    exportColumns = colArray.map((col) => (col.fieldName));
    const footerTotals: any = [];
    for (const col of colArray) {
      let m: any = {};
      if (col.fieldName === 'DebitAmount' || col.fieldName === 'CreditAmount') {
        m["key"] = colArray.find(x => x.fieldName === col.fieldName)?.displayName;
        m["value"] = this.calculateColumnSum(col.fieldName);
        footerTotals.push(m);
      }
    }

    let exportedData = this.transformedData.map((item) =>
      exportColumns.map((column) => item[column])
    );
    debugger;
    const data = {
      "columnsHeaders": colArray.map((col) => (col.displayName)),
      "rowData": exportedData,
      "footerTotals": footerTotals  // Include footer totals in the data
    };
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
              this.openFile(downloadResult.path ?? "", 'application/pdf');
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

  exportExcel() {
    let exportColumns: any[];
    let colArray: any[] = [];
    colArray = [
      { "displayName": "Account Type", "dataType": "text", "fieldName": "DebitColType" },
      { "displayName": "Debit Amount", "dataType": "numeric", "fieldName": "DebitAmount" },
      { "displayName": "Account Type", "dataType": "text", "fieldName": "CreditColType" },
      { "displayName": "Credit Amount", "dataType": "numeric", "fieldName": "CreditAmount" }
    ];

    exportColumns = colArray.map((col) => (col.fieldName));
    const footerTotals: any = [];
    for (const col of colArray) {
      let m: any = {};
      if (col.fieldName === 'DebitAmount' || col.fieldName === 'CreditAmount') {
        m["key"] = colArray.find(x => x.fieldName === col.fieldName)?.displayName;
        m["value"] = this.calculateColumnSum(col.fieldName);
        footerTotals.push(m);
      }
    }

    let exportedData = this.transformedData.map((item) =>
      exportColumns.map((column) => item[column])
    );
    debugger;
    const data = {
      "columnsHeaders": colArray.map((col) => (col.displayName)),
      "rowData": exportedData,
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
            if (downloadResult) {
              alert("File downloaded successfully.");
              this.openFile(downloadResult.path ?? "", 'text/csv');
            }
            else {
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

  async openFile(uri: string, mimeType: string) {
    try {
      await FileOpener.open({
        filePath: uri,
        contentType: mimeType
      });
    } catch (error) {
      console.error('Error opening file:', error);
      // Handle error opening file
    }
  }

  calculateColumnSum(columnName: string): number {
    let sum = 0;
    let count = 0;


    if (this.transformedData === undefined) {
      return 0;
    }

    try {
      for (const item of this.transformedData) {
        // Check if the property exists before summing
        if (item.hasOwnProperty(columnName) && !isNaN(parseFloat(item[columnName]))) {
          sum += parseFloat(item[columnName]);
          count++;
        }
      }
    } catch (ex) {
      this.loading = false;
      alert(ex);
    }
    return sum;
  }

}
