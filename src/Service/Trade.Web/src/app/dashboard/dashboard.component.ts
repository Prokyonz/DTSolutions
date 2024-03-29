import { Component, OnInit, Inject } from '@angular/core';
import { SharedService } from '../common/shared.service';
import { Message, MessageService } from 'primeng/api';
import { DatePipe } from '@angular/common';
import { RememberCompany } from '../shared/component/companyselection/companyselection.component';
import { LOCALE_ID, NgModule } from '@angular/core';

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
    await this.loadDashboard();      
    this.loading = false;    
  }

  rowClicked(rowIndex: number, itemIndex: number): void {
    this.rowClickedIndex = rowIndex;
    this.rowClickedItemIndex = itemIndex;
    // You can use the selected row data for additional functionality.
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
                      icon: 'pi pi-fw pi-money-bill',
                      routerLink: "/report/7",
                     
                    });
                break;
                case 'balance_report':
                  this.dashBoardReportItems.push({
                      label: 'Balance',
                      icon: 'pi pi-fw pi-briefcase',
                      routerLink: "/balancesheet",
                      expanded: false,
                    
                    });
                break;
                case 'profit_report':
                  this.dashBoardReportItems.push({
                      label: 'Profit',
                      icon: 'pi pi-fw pi-money-bill',
                      routerLink: "/profitloss",
                      expanded: false,
                      
                    });
                break;  
                case 'stock_report':
                  this.dashBoardReportItems.push({
                      label: 'Stock Report',
                      icon: 'pi pi-fw pi-chart-bar',
                      routerLink: "/report/17",
                      expanded: false,
                     
                    });
                break;
                case 'openingstock_report':
                  this.dashBoardReportItems.push({
                      label: 'Opening',
                      icon: 'pi pi-fw pi-folder-open',
                      routerLink: "/report/18",
                      expanded: false,
                      
                    });
                break;
                case 'rejectionin_report':
                  this.dashBoardReportItems.push({
                      label: 'Rejection In',
                      icon: 'pi pi-fw pi-minus-circle',
                      routerLink: "/report/15",
                     
                    });
                break;
                case 'rejectionout_report':
                  this.dashBoardReportItems.push({
                      label: 'Rejection Out',
                      icon: 'pi pi-fw pi-minus-circle',
                      routerLink: "/report/16",
                     
                    });
                break;
                case 'kapanlagad_report':
                  this.dashBoardReportItems.push({
                      label: 'Kapan Lagad',
                      icon: 'pi pi-fw pi-question',
                      routerLink: "/kapan",
                      expanded: false,
                      
                    });
                break;  
                case 'purchase_report':
                  this.dashBoardReportItems.push({
                      label: 'Purchase',
                      icon: 'pi pi-fw pi-shopping-cart',
                      routerLink: "/report/1",
                     
                    });
                break;
                case 'sales_report':
                this.dashBoardReportItems.push({
                    label: 'Sales',
                    icon: 'pi pi-fw pi-chart-line',
                    routerLink: "/report/2",
                    
                  });
                break;
                case 'payment_report':
                  this.dashBoardReportItems.push({
                      label: 'Payment',
                      icon: 'pi pi-fw pi-money-bill',
                      routerLink: "/report/3",
                    });
                break;
                case 'receipt_report':
                  this.dashBoardReportItems.push({
                      label: 'Receipt',
                      icon: 'pi pi-fw pi-money-bill',
                      routerLink: "/report/4",
                     
                    });
                break;
                case 'contra_report':
                this.dashBoardReportItems.push({
                    label: 'Contra',
                    icon: 'pi pi-fw pi-sync',
                    routerLink: "/report/5",
                  });
                break;
                case 'expense_report':
                  this.dashBoardReportItems.push({
                      label: 'Expense',
                      icon: 'pi pi-fw pi-file',
                      routerLink: "/report/6",
                    });
                break;
                case 'cashbank_report':
                  this.dashBoardReportItems.push({
                      label: 'Cash Bank',
                      icon: 'pi pi-fw pi-money-bill',
                      routerLink: "/report/13",
                    });
                break;
                case 'pf_report':
                  this.dashBoardReportItems.push({
                      label: 'PF',
                      icon: 'pi pi-fw pi-users',
                      routerLink: "/report/9",
                     
                    });
                break;
                case 'ledger_report':
                  this.dashBoardReportItems.push({
                      label: 'Ledger',
                      icon: 'pi pi-fw pi-book',
                      routerLink: "/report/10",
                     
                    });
                break;
                case 'mixed_report':
                  this.dashBoardReportItems.push({
                      label: 'Rojmel',
                      icon: 'pi pi-fw pi-refresh',
                      routerLink: "/report/8",
                    });
                break;
                case 'weekly_report':
                  this.dashBoardReportItems.push({
                      label: 'Weekly',
                      icon: 'pi pi-fw pi-calendar-plus',
                      routerLink: "/report/19",
                      expanded: false,
                     
                    });
                break;     
                case 'salary_report':
                  this.dashBoardReportItems.push({
                      label: 'Salary',
                      icon: 'pi pi-fw pi-money-bill',
                      routerLink: "/report/14",
                    });
                break;
                case 'payable_report':
                  this.dashBoardReportItems.push({
                      label: 'Payable',
                      icon: 'pi pi-fw pi-money-bill',
                      routerLink: "/report/11",
                    
                    });
                break;
                case 'receivable_report':
                  this.dashBoardReportItems.push({
                      label: 'Receivable',
                      icon: 'pi pi-fw pi-money-bill',
                      routerLink: "/report/12",
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
            });
            this.dashBoardReportItems.push({
              label: 'Company',
              icon: 'pi pi-fw pi-user-plus',
              routerLink: "/companyselection/header",
            });
            this.dashBoardReportItems.push({
              label: 'Logout',
              icon: 'pi pi-fw pi-power-off',
              routerLink: "/login",
            });
            this.loading = false;
          }, (ex: any) => {
            this.loading = false;
        });
}

get rowDataList() {
  return Array(Math.floor(this.dashBoardReportItems.length / 2));
}
}
