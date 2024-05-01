import { DatePipe } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { MessageService } from 'primeng/api';
import { SharedService } from '../../common/shared.service';
import { RememberCompany } from '../../shared/component/companyselection/companyselection.component';
import { Filesystem, Directory, Encoding, DownloadFileOptions } from '@capacitor/filesystem';
import { FileOpener } from '@capacitor-community/file-opener';

@Component({
  selector: 'app-kapanlagad',
  templateUrl: './kapanlagad.component.html',
  styleUrls: ['./kapanlagad.component.scss']
})
export class KapanlagadComponent implements OnInit {
  allkapan: any[] = [];
  loading: boolean = true;
  isOpen: boolean = false;
  RememberCompany: RememberCompany = new RememberCompany();
  kapanid: any = [];
  groupedData: { [category: string]: any[] } = {};
  kapandata: any[] = [];
  inward: any[] = [];
  outward: any[] = [];
  closing: any[] = [];
  transformedData: any[] = [];
  PageTitle = "Kapan Lagad Report";
  TotalInwardAmount: number = 0;
  TotalInwardRate: number = 0;
  TotalInwardNetWeight: number = 0;

  TotalOutwardAmount: number = 0;
  TotalOutwardRate: number = 0;
  TotalOutwardNetWeight: number = 0;

  TotalClosingAmount: number = 0;
  TotalClosingRate: number = 0;
  TotalClosingNetWeight: number = 0;

  profitLossPercentage = 0;
  perCtsValue = 0;

  profitLossAndPerCtsData: any; // Define the property with the appropriate type

  currentSortField: string = 'date'; // Set default sorting field
  currentSortOrder: number = 1; // 1 for ascending, -1 for descending

  constructor(private rote: Router, private activateRoute: ActivatedRoute, private messageService: MessageService,
    private sharedService: SharedService, private datePipe: DatePipe) {

  }

  goBack() {
    this.rote.navigate(['/dashboard']);
  }

  ngOnInit() {
    this.loading = false;
    this.getCompanyData();
    this.getkapan();
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

  getkapan() {
    this.allkapan = [];
    this.sharedService.customGetApi("Report/GetAllKapan?companyid=" + this.RememberCompany.company.id).subscribe((t) => {
      if (t.success == true) {
        if (t.data != null && t.data.length > 0) {
          t.data = [
            ...t.data
          ];

          t.data.forEach((item: any) => {
            this.allkapan.push({ name: item });
          });
          console.log(this.allkapan);
        }
      }
    });
  }

  handlekapan(event: any) {
    this.kapanid = event.value;
  }

  showDetails() {
    this.loading = true;
    if (!this.kapanid || !this.kapanid.name || typeof this.kapanid.name.id === 'undefined') {
      alert("kapan is not selected");
      this.loading = false;
      return;
    }

    this.sharedService.customGetApi("Report/GetKapanLagadReport?kapanId=" + this.kapanid.name.id).subscribe((t) => {
      if (t.success == true) {
        console.log(t.data);
        this.kapandata = t.data;
        this.inward = this.kapandata.filter(f => f.category.toLowerCase() == "inward");
        if (this.inward.length > 0) {
          this.profitLossAndPerCtsData = {
            profitLossPercentage: this.inward[0].profitLossPer,
            perCtsValue: this.inward[0].inwardAvg
          };
        }
        this.TotalInwardAmount = this.inward.reduce((accumulator, currentObject) => {
          if (currentObject.amount !== null && currentObject.amount !== undefined) {
            return accumulator + currentObject.amount;
          } else {
            return accumulator; // Skip null or undefined values
          }
        }, 0);

        this.TotalInwardRate = this.inward.reduce((accumulator, currentObject) => {
          if (currentObject.rate !== null && currentObject.rate !== undefined) {
            return accumulator + currentObject.rate;
          } else {
            return accumulator; // Skip null or undefined values
          }
        }, 0);

        this.TotalInwardNetWeight = this.inward.reduce((accumulator, currentObject) => {
          if (currentObject.netWeight !== null && currentObject.netWeight !== undefined) {
            return accumulator + currentObject.netWeight;
          } else {
            return accumulator; // Skip null or undefined values
          }
        }, 0);
        if (this.inward.length > 0) {
          let row: any = {};
          row['Date'] = 'Inward'
          row['SlipNo'] = '';
          row['PartyName'] = '';
          row['NetWeight'] = '';
          row['Rate'] = '';
          row['Amount'] = '';
          this.transformedData.push(row);
          this.inward.forEach(element => {
            row = {};
            row['Date'] = this.formatDate(element.date);
            row['SlipNo'] = element.slipNo;
            row['PartyName'] = element.party;
            row['NetWeight'] = element.netWeight?.toFixed(2) || "0"
            row['Rate'] = element.rate?.toFixed(2).toString() || "0"
            row['Amount'] = element.amount?.toFixed(2).toString() || "0"
            this.transformedData.push(row);
          });
          row = {};
          row['Date'] = '';
          row['SlipNo'] = '';
          row['PartyName'] = 'Total';
          row['NetWeight'] = this.TotalInwardNetWeight.toFixed(2).toString() || "0";
          row['Rate'] = this.TotalInwardRate.toFixed(2).toString() || "0";
          row['Amount'] = this.TotalInwardAmount.toFixed(2).toString() || "0";
          this.transformedData.push(row);
        }

        this.outward = this.kapandata.filter(f => f.category.toLowerCase() == "outward");
        if (this.outward.length > 0) {
          this.profitLossAndPerCtsData = {
            profitLossPercentage: this.outward[0].profitLossPer,
            perCtsValue: this.outward[0].inwardAvg
          };
        }
        this.TotalOutwardAmount = this.outward.reduce((accumulator, currentObject) => {
          if (currentObject.amount !== null && currentObject.amount !== undefined) {
            return accumulator + currentObject.amount;
          } else {
            return accumulator; // Skip null or undefined values
          }
        }, 0);

        this.TotalOutwardRate = this.outward.reduce((accumulator, currentObject) => {
          if (currentObject.rate !== null && currentObject.rate !== undefined) {
            return accumulator + currentObject.rate;
          } else {
            return accumulator; // Skip null or undefined values
          }
        }, 0);

        this.TotalOutwardNetWeight = this.outward.reduce((accumulator, currentObject) => {
          if (currentObject.netWeight !== null && currentObject.netWeight !== undefined) {
            return accumulator + currentObject.netWeight;
          } else {
            return accumulator; // Skip null or undefined values
          }
        }, 0);

        if (this.outward.length > 0) {
          let row: any = {};
          row['Date'] = 'Outward'
          row['SlipNo'] = '';
          row['PartyName'] = '';
          row['NetWeight'] = '';
          row['Rate'] = '';
          row['Amount'] = '';
          this.transformedData.push(row);
          this.outward.forEach(element => {
            row = {};
            row['Date'] = this.formatDate(element.date);
            row['SlipNo'] = element.slipNo;
            row['PartyName'] = element.party;
            row['NetWeight'] = element.netWeight?.toFixed(2) || "0"
            row['Rate'] = element.rate?.toFixed(2).toString() || "0"
            row['Amount'] = element.amount?.toFixed(2).toString() || "0"
            this.transformedData.push(row);
          });
          row = {};
          row['Date'] = '';
          row['SlipNo'] = '';
          row['PartyName'] = 'Total';
          row['NetWeight'] = this.TotalOutwardNetWeight.toFixed(2).toString() || "0";
          row['Rate'] = this.TotalOutwardRate.toFixed(2).toString() || "0";
          row['Amount'] = this.TotalOutwardAmount.toFixed(2).toString() || "0";
          this.transformedData.push(row);
        }

        this.closing = this.kapandata.filter(f => f.category.toLowerCase() == "closing");
        if (this.closing.length > 0) {
          this.profitLossAndPerCtsData = {
            profitLossPercentage: this.closing[0].profitLossPer,
            perCtsValue: this.closing[0].inwardAvg
          };
        }
        this.TotalClosingAmount = this.closing.reduce((accumulator, currentObject) => {
          if (currentObject.amount !== null && currentObject.amount !== undefined) {
            return accumulator + currentObject.amount;
          } else {
            return accumulator; // Skip null or undefined values
          }
        }, 0);

        this.TotalClosingRate = this.closing.reduce((accumulator, currentObject) => {
          if (currentObject.rate !== null && currentObject.rate !== undefined) {
            return accumulator + currentObject.rate;
          } else {
            return accumulator; // Skip null or undefined values
          }
        }, 0);

        this.TotalClosingNetWeight = this.closing.reduce((accumulator, currentObject) => {
          if (currentObject.netWeight !== null && currentObject.netWeight !== undefined) {
            return accumulator + currentObject.netWeight;
          } else {
            return accumulator; // Skip null or undefined values
          }
        }, 0);

        if (this.closing.length > 0) {
          let row: any = {};
          row['Date'] = 'Closing'
          row['SlipNo'] = '';
          row['PartyName'] = '';
          row['NetWeight'] = '';
          row['Rate'] = '';
          row['Amount'] = '';
          this.transformedData.push(row);
          this.closing.forEach(element => {
            row = {};
            row['Date'] = this.formatDate(element.date);
            row['SlipNo'] = element.slipNo;
            row['PartyName'] = element.party;
            row['NetWeight'] = element.netWeight?.toFixed(2) || "0"
            row['Rate'] = element.rate?.toFixed(2).toString() || "0"
            row['Amount'] = element.amount?.toFixed(2).toString() || "0"
            this.transformedData.push(row);
          });
          row = {};
          row['Date'] = '';
          row['SlipNo'] = '';
          row['PartyName'] = 'Total';
          row['NetWeight'] = this.TotalClosingNetWeight.toFixed(2).toString() || "0";
          row['Rate'] = this.TotalClosingRate.toFixed(2).toString() || "0";
          row['Amount'] = this.TotalClosingAmount.toFixed(2).toString() || "0";
          this.transformedData.push(row);
        }

        this.loading = false;
        //this.groupDataByCategory();
      }
    }, (ex: any) => {
      this.loading = false;
      this.showMessage('error', ex);
    });

    this.handlePanelToggle();
  }

  handlePanelToggle() {
    debugger;
    this.isOpen = !this.isOpen;
  }

  formatDate(dateString: string) {
    const date = new Date(dateString);
    const month = (date.getMonth() + 1).toString().padStart(2, '0');
    const day = date.getDate().toString().padStart(2, '0');
    const year = date.getFullYear();
    return `${day}-${month}-${year}`;
  }

  exportExcel() {
    let exportColumns: any[];
    let colArray: any[] = [];
    colArray = [
      { "displayName": "Date", "dataType": "text", "fieldName": "Date" },
      { "displayName": "Slip No", "dataType": "text", "fieldName": "SlipNo" },
      { "displayName": "Party Name", "dataType": "text", "fieldName": "PartyName" },
      { "displayName": "Net Weight", "dataType": "text", "fieldName": "NetWeight" },
      { "displayName": "Rate", "dataType": "text", "fieldName": "Rate" },
      { "displayName": "Amount", "dataType": "text", "fieldName": "Amount" }
    ];

    exportColumns = colArray.map((col) => (col.fieldName));
    const footerTotals: any = [];

    let exportedData = this.transformedData.map((item) =>
      exportColumns.map((column) => item[column])
    );
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

  exportPdf() {
    let exportColumns: any[];
    let colArray: any[] = [];
    colArray = [
      { "displayName": "Date", "dataType": "text", "fieldName": "Date" },
      { "displayName": "Slip No", "dataType": "text", "fieldName": "SlipNo" },
      { "displayName": "Party Name", "dataType": "text", "fieldName": "PartyName" },
      { "displayName": "Net Weight", "dataType": "text", "fieldName": "NetWeight" },
      { "displayName": "Rate", "dataType": "text", "fieldName": "Rate" },
      { "displayName": "Amount", "dataType": "text", "fieldName": "Amount" }
    ];

    exportColumns = colArray.map((col) => (col.fieldName));
    const footerTotals: any = [];

    let exportedData = this.transformedData.map((item) =>
      exportColumns.map((column) => item[column])
    );
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
            if (downloadResult) {
              alert("File downloaded successfully.");
              this.openFile(downloadResult.path ?? "", 'application/pdf');
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

  showMessage(type: string, message: string) {
    this.messageService.add({ severity: type, summary: message });
  }

  calculateTotal(items: any[], field: string): number {
    return items.reduce((total, item) => total + (item[field] || 0), 0);
  }

  onSort(event: any) {
    this.currentSortField = event.field;
    this.currentSortOrder = event.order;
  }

  sortData(data: any[], field: string, order: number): any[] {
    // Sort the data based on the field and order
    return data.sort((a, b) => {
      const valueA = a[field];
      const valueB = b[field];
      if (valueA < valueB) {
        return -1 * order;
      } else if (valueA > valueB) {
        return 1 * order;
      } else {
        return 0;
      }
    });
  }

  groupAndCalculateTotals(data: any[]): any[] {
    // Sort the outward data based on the current sorting state
    if (this.currentSortField && this.currentSortOrder) {
      data = this.sortData(data, this.currentSortField, this.currentSortOrder);
    }
    const groupedData: { [key: string]: any } = {};

    for (const item of data) {
      const size = item.size || 'N/A'; // Use 'N/A' if 'size' is missing
      if (!groupedData[size]) {
        groupedData[size] = {
          size: size,
          netWeightTotal: 0,
          rateTotal: 0,
          amountTotal: 0,
          items: [],
        };
      }

      groupedData[size].items.push(item);
      groupedData[size].netWeightTotal += item.netWeight;
      groupedData[size].rateTotal += item.rate;
      groupedData[size].amountTotal += item.amount;
    }

    return Object.values(groupedData);
  }

  groupDataByCategory() {
    this.groupedData = {};
    this.kapandata.forEach(item => {
      if (!this.groupedData[item.category]) {
        this.groupedData[item.category] = [];
      }
      this.groupedData[item.category].push(item);
    });
    const sortedCategories = ['Inward', 'Outward', 'Closing'];
    this.groupedData = Object.fromEntries(
      sortedCategories.map(category => [category, this.groupedData[category] || []])
    );
  }

  formatDecimal(value: number): string {
    //return value.toFixed(2);
    return (value !== undefined && value !== null) ? value.toFixed(2) : '0';
  }

  calculateCategoryTotal(category: string, key: string): number {
    return this.groupedData[category]
      .map(item => item[key])
      .reduce((sum, value) => sum + value, 0);
  }

  formatIndianNumber(amount: number): string {
    const formatter = new Intl.NumberFormat('en-IN');
    return formatter.format(amount);
  }
}
