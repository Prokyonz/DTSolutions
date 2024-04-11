import { Component, OnInit, Inject, EventEmitter, Output } from '@angular/core';
import { SharedService } from '../common/shared.service';
import { Message, MessageService } from 'primeng/api';
import { DatePipe } from '@angular/common';
import { RememberCompany } from '../shared/component/companyselection/companyselection.component';
import { LOCALE_ID, NgModule } from '@angular/core';
import { Router } from '@angular/router';

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
  userName: string;
  dashBoardReportItems: any[] = [];
  rowClickedIndex: number = -1;
  rowClickedItemIndex: number = -1;
  loading:boolean = false;
  selectedItem: any;
  highlightedRowIndex: number = 0;
  filterReport: any[] = [];
  showDashboard: boolean = false;
  showFirstPanel: boolean = true;
  showSecondPanel: boolean = false;
  constructor(private sharedService: SharedService, private messageService: MessageService,
    private datePipe: DatePipe,  @Inject(LOCALE_ID) public locale: string){}

  ngOnInit(): void {
      this.getCompanyData();
      let currentDate = new Date(); // Get the current date
      currentDate = new Date(currentDate.getFullYear(), currentDate.getMonth(), 1);
      //this.firstDate = this.datePipe.transform(currentDate, 'yyyy-MM-dd');
      //this.endDate = this.datePipe.transform(new Date(), 'yyyy-MM-dd');
      this.firstDate = this.datePipe.transform(this.RememberCompany.financialyear.startDate, 'yyyy-MM-dd');
      this.endDate = this.datePipe.transform(this.RememberCompany.financialyear.endDate, 'yyyy-MM-dd');

      let userInfo = localStorage.getItem("loginremember");

      if(userInfo != null) {
        this.userName = JSON.parse(userInfo).username;
        this.sharedService.customGetApi("Auth/GetPermissionList?userid=" + localStorage.getItem("userid"))
        .subscribe((data: any) => {
              this.filterReport = data.data;
              if (this.filterReport.filter((e : any) => e == "mobile_dashboard").length > 0){
                this.showDashboard = true;
                this.geDashBoardData();
              }              
            }, (ex: any) => {
              this.loading = false;
          });
      }
      this.showFirstPanel =true;
      // this.loadDashboard();
     
  }

  // Function to format the number in Indian numbering system
formatIndianNumber(amount: number): string {
  const formatter = new Intl.NumberFormat('en-IN');
  return formatter.format(amount);
}

  async loadDashboard() {
    try {
      this.sharedService.customGetApi("Report/GetPurchaseTotal?CompanyId=" + this.RememberCompany.company.id + "&FinancialYearId=" + this.RememberCompany.financialyear.id +"&FromDate=" + this.RememberCompany.financialyear.startDate + "&ToDate=" + this.RememberCompany.financialyear.endDate + "")
      .subscribe((data: any) => {
          this.purchaseData = this.formatIndianNumber(data.data.totalAmount);
          }, (ex: any) => {
            console.log(ex);
            this.showMessage('error',ex);
      });

      this.sharedService.customGetApi("Report/GetSaleTotal?CompanyId=" + this.RememberCompany.company.id + "&FinancialYearId=" + this.RememberCompany.financialyear.id +"&FromDate=" + this.firstDate + "&ToDate=" + this.endDate + "")
      .subscribe((data: any) => {
          this.salesData = this.formatIndianNumber(data.data.totalAmount);
          }, (ex: any) => {
            console.log(ex);
            this.showMessage('error',ex);
      });

      this.sharedService.customGetApi("Report/GetPaymentOrReceiptTotal?CompanyId=" + this.RememberCompany.company.id + "&FinancialYearId=" + this.RememberCompany.financialyear.id +"&FromDate=" + this.firstDate + "&ToDate=" + this.endDate + ",&TransType=0")
      .subscribe((data: any) => {
          this.paymentData = this.formatIndianNumber(data.data.totalAmount);
          }, (ex: any) => {
            console.log(ex);
            this.showMessage('error',ex);
      });

      this.sharedService.customGetApi("Report/GetPaymentOrReceiptTotal?CompanyId=" + this.RememberCompany.company.id + "&FinancialYearId=" + this.RememberCompany.financialyear.id +"&FromDate=" + this.firstDate + "&ToDate=" + this.endDate + ",&TransType=1")
      .subscribe((data: any) => {
          this.receiptData = this.formatIndianNumber(data.data.totalAmount);
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

  async onSeach(event: any) {
    this.loading = true;
    const StartDate = this.datePipe.transform(event.startDate, 'yyyy-MM-dd');
    const EndDate = this.datePipe.transform(event.endDate, 'yyyy-MM-dd');
    this.firstDate = StartDate;
    this.endDate = EndDate;
    this.showFirstPanel = true;
    await this.geDashBoardData();      
    this.loading = false;    
  }

  rowClicked(rowIndex: number, itemIndex: number): void {
    this.rowClickedIndex = rowIndex;
    this.rowClickedItemIndex = itemIndex;
  }

  backFunction() {
    this.showFirstPanel=true;
    this.showSecondPanel=false;
    window.location.href = '/dashboard';
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

  geDashBoardData(): void {
 
      this.sharedService.customGetApi("Auth/GetPermissionList?userid=" + localStorage.getItem("userid"))
      .subscribe((data: any) => {
            this.filterReport = data.data;
      
            this.filterReport.forEach((e: any) => {
              switch (e){
                case 'loan_report':
                  this.dashBoardReportItems.push({
                      label: 'Loan',
                      icon: 'pi pi-fw pi-credit-card',
                      routerLink: "/report/7",
                      index: 20
                    });
                break;
                case 'balance_report':
                  this.dashBoardReportItems.push({
                      label: 'Balance',
                      icon: 'pi pi-fw pi-briefcase',
                      routerLink: "/balancesheet",
                      expanded: false,
                      index: 17
                    });
                break;
                case 'profit_report':
                  this.dashBoardReportItems.push({
                      label: 'Profit',
                      icon: 'pi pi-fw pi-chart-line',
                      routerLink: "/profitloss",
                      expanded: false,
                      index: 18
                    });
                break;  
                case 'stock_report':
                  this.dashBoardReportItems.push({
                      label: 'Stock',
                      icon: 'pi pi-fw pi-table',
                      routerLink: "/report/17",
                      expanded: false,
                      index: 13
                    });
                break;
                case 'openingstock_report':
                  this.dashBoardReportItems.push({
                      label: 'Opening',
                      icon: 'pi pi-fw pi-folder-open',
                      routerLink: "/report/18",
                      expanded: false,
                      index: 12
                    });
                break;
                case 'rejectionin_report':
                  this.dashBoardReportItems.push({
                      label: 'Reject In',
                      icon: 'pi pi-fw pi-plus-circle',
                      routerLink: "/report/15",
                      index: 14
                    });
                break;
                case 'rejectionout_report':
                  this.dashBoardReportItems.push({
                      label: 'Reject Out',
                      icon: 'pi pi-fw pi-minus-circle',
                      routerLink: "/report/16",
                      index: 15
                    });
                break;
                case 'kapanlagad_report':
                  this.dashBoardReportItems.push({
                      label: 'Kapan',
                      icon: 'pi pi-fw pi-calendar',
                      routerLink: "/kapan",
                      expanded: false,
                      index: 21
                    });
                break;  
                case 'purchase_report':
                  this.dashBoardReportItems.push({
                      label: 'Purchase',
                      icon: 'pi pi-fw pi-shopping-cart',
                      routerLink: "/report/1",
                      index: 0
                    });
                break;
                case 'sales_report':
                this.dashBoardReportItems.push({
                    label: 'Sales',
                    icon: 'pi pi-fw pi-chart-line',
                    routerLink: "/report/2",
                    index: 1
                  });
                break;
                case 'payment_report':
                  this.dashBoardReportItems.push({
                      label: 'Payment',
                      icon: 'pi pi-fw pi-wallet',
                      routerLink: "/report/3",
                      index: 4
                    });
                break;
                case 'receipt_report':
                  this.dashBoardReportItems.push({
                      label: 'Receipt',
                      icon: 'pi pi-fw pi-file',
                      routerLink: "/report/4",
                      index: 5
                    });
                break;
                case 'contra_report':
                this.dashBoardReportItems.push({
                    label: 'Contra',
                    icon: 'pi pi-fw pi-sync',
                    routerLink: "/report/5",
                    index: 6
                  });
                break;
                case 'expense_report':
                  this.dashBoardReportItems.push({
                      label: 'Expense',
                      icon: 'pi pi-fw pi-chart-bar',
                      routerLink: "/report/6",
                      index: 9
                    });
                break;
                case 'cashbank_report':
                  this.dashBoardReportItems.push({
                      label: 'Cash Bank',
                      icon: 'pi pi-fw pi-book',
                      routerLink: "/report/13",
                      index: 10
                    });
                break;
                case 'pf_report':
                  this.dashBoardReportItems.push({
                      label: 'PF',
                      icon: 'pi pi-fw pi-globe',
                      routerLink: "/report/9",
                      index: 22
                    });
                break;
                case 'ledger_report':
                  this.dashBoardReportItems.push({
                      label: 'Ledger',
                      icon: 'pi pi-fw pi-book',
                      routerLink: "/report/10",
                      index: 19
                    });
                break;
                case 'mixed_report':
                  this.dashBoardReportItems.push({
                      label: 'Rojmel',
                      icon: 'pi pi-fw pi-list',
                      routerLink: "/report/8",
                      index: 8
                    });
                break;
                case 'weekly_report':
                  this.dashBoardReportItems.push({
                      label: 'Weekly',
                      icon: 'pi pi-fw pi-calendar-plus',
                      routerLink: "/report/19",
                      expanded: false,
                      index: 11
                    });
                break;     
                case 'salary_report':
                  this.dashBoardReportItems.push({
                      label: 'Salary',
                      icon: 'pi pi-fw pi-users',
                      routerLink: "/report/14",
                      index: 7
                    });
                break;
                case 'payable_report':
                  this.dashBoardReportItems.push({
                      label: 'Payable',
                      icon: 'pi pi-fw pi-money-bill',
                      routerLink: "/report/11",
                      index: 2
                    });
                break;
                case 'receivable_report':
                  this.dashBoardReportItems.push({
                      label: 'Receivable',
                      icon: 'pi pi-fw pi-dollar',
                      routerLink: "/report/12",
                      index: 3
                    });
                break;
                default:
                  break;
              }
            });
            this.dashBoardReportItems.push({
              label: 'Average',
              icon: 'pi pi-fw pi-calculator',
              routerLink: "/viewcts",
              index: 16
            });
            this.dashBoardReportItems.push({
              label: 'Overview',
              icon: 'pi pi-fw pi-eye',
              routerLink: "/login",
              index: 23
            });
            this.dashBoardReportItems.push({
              label: 'Company',
              icon: 'pi pi-fw pi-building',
              routerLink: "/companyselection/header",
              index: 24
            });

            // this.dashBoardReportItems.push({
            //   label: 'Logout',
            //   icon: 'pi pi-fw pi-power-off',
            //   routerLink: "/login",
            // });
               // Sorting dashBoardReportItems by index
             this.dashBoardReportItems.sort((a, b) => a.index - b.index);
            this.loading = false;
          }, (ex: any) => {
            this.loading = false;
        });
}

togglePanel(label: string): void {
  if (label === 'Overview') {
    this.loadDashboard();
    this.showFirstPanel = !this.showFirstPanel; // Toggle the panel
    this.showSecondPanel = !this.showFirstPanel;
  }
}
onLogoutClick(): void{
  debugger;
  window.location.href = '/login';
}

get rowDataList() {
  return Array(Math.floor(this.dashBoardReportItems.length / 2));
}
}
