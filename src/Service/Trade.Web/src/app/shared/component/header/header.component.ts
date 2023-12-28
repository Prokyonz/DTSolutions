import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { MenuItem, MessageService } from 'primeng/api';
import { SharedService } from '../../../common/shared.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss']
})

export class HeaderComponent implements OnInit {
  @Input() title:string = "MyHeader";
  @Input() iconName:string = "pi-align-justify";
  @Input() leftIconName:string = "pi-align-justify";
  @Input() showSideBar:boolean = false;
  @Output() onClickMainIcon = new EventEmitter();
  @Output() onClickLeftIcon = new EventEmitter();

  userName: string = "Default User";
  loading: boolean = true;
  filterReport: any;

  sidebarVisible!: boolean;

  transactionReportItems: MenuItem[] = [];
  masterReportItems: MenuItem[] = [];

  items: MenuItem[] = [
    {
        label: 'Home',
        icon: 'pi pi-fw pi-file',
        routerLink: "/dashboard",
        expanded: false,
        command: () => {
          this.sidebarVisible = false;  
        }
    }
  ];
  constructor(private sharedService: SharedService, private messageService: MessageService){

  }

  ngOnInit(): void {
    let userInfo = localStorage.getItem("loginremember");
    if(userInfo != null) {
      this.userName = JSON.parse(userInfo).username;
      this.sharedService.customGetApi("Auth/GetPermissionList?userid=" + localStorage.getItem("userid"))
      .subscribe((data: any) => {
            this.filterReport = data.data;
            if (this.filterReport.filter((e : any) => e == "calculator").length > 0){
              this.items.push({
                label: 'Calculator',
                icon: 'pi pi-fw pi-calculator',
                routerLink: "/viewcts",
                expanded: false,
                command: () => {
                  this.sidebarVisible = false;
                }
              });
            }
            this.filterReport.forEach((e: any) => {
              switch (e){
                case 'purchase_report':
                  this.transactionReportItems.push({
                      label: 'Purchase',
                      icon: 'pi pi-fw pi-shopping-cart',
                      routerLink: "/report/1",
                      command: () => {
                        this.sidebarVisible = false;
                      }
                    });
                break;
                case 'sales_report':
                this.transactionReportItems.push({
                    label: 'Sales',
                    icon: 'pi pi-fw pi-chart-line',
                    routerLink: "/report/2",
                    command: () => {
                      this.sidebarVisible = false;
                    }
                  });
                break;
                case 'payment_report':
                  this.transactionReportItems.push({
                      label: 'Payment',
                      icon: 'pi pi-fw pi-money-bill',
                      routerLink: "/report/3",
                      command: () => {
                        this.sidebarVisible = false;
                      }
                    });
                break;
                case 'receipt_report':
                  this.transactionReportItems.push({
                      label: 'Receipt',
                      icon: 'pi pi-fw pi-credit-card',
                      routerLink: "/report/4",
                      command: () => {
                        this.sidebarVisible = false;
                      }
                    });
                break;
                case 'contra_report':
                this.transactionReportItems.push({
                    label: 'Contra',
                    icon: 'pi pi-fw pi-sync',
                    routerLink: "/report/5",
                    command: () => {
                      this.sidebarVisible = false;
                    }
                  });
                break;
                case 'expense_report':
                  this.transactionReportItems.push({
                      label: 'Expense',
                      icon: 'pi pi-fw pi-file',
                      routerLink: "/report/6",
                      command: () => {
                        this.sidebarVisible = false;
                      }
                    });
                break;
                case 'loan_report':
                  this.transactionReportItems.push({
                      label: 'Loan',
                      icon: 'pi pi-fw pi-money-bill',
                      routerLink: "/report/7",
                      command: () => {
                        this.sidebarVisible = false;
                      }
                    });
                break;
                case 'mixed_report':
                  this.transactionReportItems.push({
                      label: 'Rojmel',
                      icon: 'pi pi-fw pi-refresh',
                      routerLink: "/report/8",
                      command: () => {
                        this.sidebarVisible = false;
                      }
                    });
                break;
                case 'pf_report':
                  this.transactionReportItems.push({
                      label: 'PF',
                      icon: 'pi pi-fw pi-users',
                      routerLink: "/report/9",
                      command: () => {
                        this.sidebarVisible = false;
                      }
                    });
                break;
                case 'ledger_report':
                  this.transactionReportItems.push({
                      label: 'Ledger',
                      icon: 'pi pi-fw pi-book',
                      routerLink: "/report/10",
                      command: () => {
                        this.sidebarVisible = false;
                      }
                    });
                break;
                case 'payable_report':
                  this.transactionReportItems.push({
                      label: 'Payable',
                      icon: 'pi pi-fw pi-money-bill',
                      routerLink: "/report/11",
                      command: () => {
                        this.sidebarVisible = false;
                      }
                    });
                break;
                case 'receivable_report':
                  this.transactionReportItems.push({
                      label: 'Receivable',
                      icon: 'pi pi-fw pi-money-bill',
                      routerLink: "/report/12",
                      command: () => {
                        this.sidebarVisible = false;
                      }
                    });
                break;
                case 'cashbank_report':
                  this.transactionReportItems.push({
                      label: 'Cash Bank',
                      icon: 'pi pi-fw pi-money-bill',
                      routerLink: "/report/13",
                      command: () => {
                        this.sidebarVisible = false;
                      }
                    });
                break;
                case 'salary_report':
                  this.transactionReportItems.push({
                      label: 'Salary',
                      icon: 'pi pi-fw pi-money-bill',
                      routerLink: "/report/14",
                      command: () => {
                        this.sidebarVisible = false;
                      }
                    });
                break;
                case 'rejectionin_report':
                  this.transactionReportItems.push({
                      label: 'Rejection In',
                      icon: 'pi pi-fw pi-minus-circle',
                      routerLink: "/report/15",
                      command: () => {
                        this.sidebarVisible = false;
                      }
                    });
                break;
                case 'rejectionout_report':
                  this.transactionReportItems.push({
                      label: 'Rejection Out',
                      icon: 'pi pi-fw pi-minus-circle',
                      routerLink: "/report/16",
                      command: () => {
                        this.sidebarVisible = false;
                      }
                    });
                break;
                case 'stock_report':
                  this.masterReportItems.push({
                      label: 'Stock Report',
                      icon: 'pi pi-fw pi-chart-bar',
                      routerLink: "/report/17",
                      expanded: false,
                      command: () => {
                        this.sidebarVisible = false;
                      }
                    });
                break;
                case 'openingstock_report':
                  this.masterReportItems.push({
                      label: 'Opening',
                      icon: 'pi pi-fw pi-folder-open',
                      routerLink: "/report/18",
                      expanded: false,
                      command: () => {
                        this.sidebarVisible = false;
                      }
                    });
                break;
                case 'weekly_report':
                  this.masterReportItems.push({
                      label: 'Weekly',
                      icon: 'pi pi-fw pi-calendar-plus',
                      routerLink: "/report/19",
                      expanded: false,
                      command: () => {
                        this.sidebarVisible = false;
                      }
                    });
                break;
                case 'balance_report':
                  this.masterReportItems.push({
                      label: 'Balance',
                      icon: 'pi pi-fw pi-briefcase',
                      routerLink: "/balancesheet",
                      expanded: false,
                      command: () => {
                        this.sidebarVisible = false;
                      }
                    });
                break;
                case 'profit_report':
                  this.masterReportItems.push({
                      label: 'Profit',
                      icon: 'pi pi-fw pi-money-bill',
                      routerLink: "/report/21",
                      expanded: false,
                      command: () => {
                        this.sidebarVisible = false;
                      }
                    });
                break;  
                case 'kapanlagad_report':
                  this.masterReportItems.push({
                      label: 'Kapan Lagad',
                      icon: 'pi pi-fw pi-question',
                      routerLink: "/kapan",
                      expanded: false,
                      command: () => {
                        this.sidebarVisible = false;
                      }
                    });
                break;  
                default:
                  break;
                  
              }
            });
            if (this.filterReport.length  > 0){
              this.items.push({
                label: 'Reports',        
                expanded: false,
                icon: 'pi pi-fw pi-chart-bar',
                items: [
                  {
                    label: 'Transaction Report',        
                    expanded: false,
                    icon: 'pi pi-fw pi-file-o',
                    items: this.transactionReportItems
                  },
                  ... this.masterReportItems
                ]
              });
            }
            this.items.push({
                label: 'Settings',
                icon: 'pi pi-fw pi-cog',
                expanded: false,
                items: [
                    {
                      label: 'Change Company',
                      icon: 'pi pi-fw pi-user-plus',
                      routerLink: "/companyselection/header",
                      command: () => {
                        this.sidebarVisible = false;
                      }
                  },
                ]
            });
            
            this.items.push({
                label: 'Logout',
                icon: 'pi pi-fw pi-power-off',
                routerLink: "/login",
                command: () => {
                  this.sidebarVisible = false;
                }
            });
            this.loading = false;
          }, (ex: any) => {
            this.loading = false;
        });
    }
  }  

  iconClick() {
    this.sidebarVisible = this.showSideBar;
    this.onClickMainIcon.emit();
  }

  leftIconClick() {
    this.onClickLeftIcon.emit();
  }
}