import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { MenuItem } from 'primeng/api';

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

  sidebarVisible!: boolean;
  items: MenuItem[] = [
    {
        label: 'Home',
        icon: 'pi pi-fw pi-file',
        routerLink: "/dashboard",
        expanded: false,
        command: () => {
          this.sidebarVisible = false;  
        }
    },
    {
        label: 'Calculator',
        icon: 'pi pi-fw pi-calculator',
        routerLink: "/viewcts",
        expanded: false,
        command: () => {
          this.sidebarVisible = false;
        }
    },
    {
        label: 'Reports',        
        expanded: false,
        icon: 'pi pi-fw pi-chart-bar',
        items:[
          {
            label: 'Transaction Report',        
            expanded: false,
            icon: 'pi pi-fw pi-file-o',
            items: [
              {
                  label: 'Purchase',
                  icon: 'pi pi-fw pi-shopping-cart',
                  routerLink: "/report/1",
                  command: () => {
                    this.sidebarVisible = false;
                  }
              },
              {
                  label: 'Sales',
                  icon: 'pi pi-fw pi-chart-line',
                  routerLink: "/report/2",
                  command: () => {
                    this.sidebarVisible = false;
                  }
              },
              {
                  label: 'Payment',
                  icon: 'pi pi-fw pi-money-bill',
                  routerLink: "/report/3",
                  command: () => {
                    this.sidebarVisible = false;
                  }
              },
              {
                  label: 'Receipt',
                  icon: 'pi pi-fw pi-credit-card',
                  routerLink: "/report/4",
                  command: () => {
                    this.sidebarVisible = false;
                  }
              },
              {
                label: 'Contra',
                icon: 'pi pi-fw pi-sync',
                routerLink: "/report/5",
                command: () => {
                  this.sidebarVisible = false;
                }
              },
              {
                label: 'Expense',
                icon: 'pi pi-fw pi-file',
                routerLink: "/report/6",
                command: () => {
                  this.sidebarVisible = false;
                }
              },
              {
                label: 'Loan',
                icon: 'pi pi-fw pi-money-bill',
                routerLink: "/report/7",
                command: () => {
                  this.sidebarVisible = false;
                }
              },
              {
                label: 'Mixed',
                icon: 'pi pi-fw pi-refresh',
                routerLink: "/report/8",
                command: () => {
                  this.sidebarVisible = false;
                }
              },
              {
                label: 'PF',
                icon: 'pi pi-fw pi-users',
                routerLink: "/report/9",
                command: () => {
                  this.sidebarVisible = false;
                }
              },              
              {
                label: 'Ledger',
                icon: 'pi pi-fw pi-book',
                routerLink: "/report/10",
                command: () => {
                  this.sidebarVisible = false;
                }
              },
              {
                label: 'Payable',
                icon: 'pi pi-fw pi-money-bill',
                routerLink: "/report/11",
                command: () => {
                  this.sidebarVisible = false;
                }
              },
              {
                label: 'Receivable',
                icon: 'pi pi-fw pi-money-bill',
                routerLink: "/report/12",
                command: () => {
                  this.sidebarVisible = false;
                }
              },
              {
                label: 'Cash Bank',
                icon: 'pi pi-fw pi-money-bill',
                routerLink: "/report/13",
                command: () => {
                  this.sidebarVisible = false;
                }
              },
              {
                label: 'Salary',
                icon: 'pi pi-fw pi-money-bill',
                routerLink: "/report/14",
                command: () => {
                  this.sidebarVisible = false;
                }
              },
              {
                label: 'Rejection In',
                icon: 'pi pi-fw pi-minus-circle',
                routerLink: "",
                command: () => {
                  this.sidebarVisible = false;
                }
              },
              {
                label: 'Rejection Out',
                icon: 'pi pi-fw pi-minus-circle',
                routerLink: "",
                command: () => {
                  this.sidebarVisible = false;
                }
              }
            ]
          },
          {
            label: 'Stock Report',
            icon: 'pi pi-fw pi-chart-bar',
            routerLink: "",
            expanded: false,
            command: () => {
              this.sidebarVisible = false;
            }
          },
          {
            label: 'Opening',
            icon: 'pi pi-fw pi-folder-open',
            routerLink: "",
            expanded: false,
            command: () => {
              this.sidebarVisible = false;
            }
          },
          {
            label: 'Weekly',
            icon: 'pi pi-fw pi-calendar-plus',
            routerLink: "",
            expanded: false,
            command: () => {
              this.sidebarVisible = false;
            }
          },
          {
            label: 'Balance',
            icon: 'pi pi-fw pi-briefcase',
            routerLink: "",
            expanded: false,
            command: () => {
              this.sidebarVisible = false;
            }
          },
          {
            label: 'Profit',
            icon: 'pi pi-fw pi-money-bill',
            routerLink: "",
            expanded: false,
            command: () => {
              this.sidebarVisible = false;
            }
          },
          {
            label: 'Kapan Lagad',
            icon: 'pi pi-fw pi-question',
            routerLink: "",
            expanded: false,
            command: () => {
              this.sidebarVisible = false;
            }
          }          
        ]
        
      },
    {
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
    },
    {
        label: 'Logout',
        icon: 'pi pi-fw pi-power-off',
        routerLink: "/login",
        command: () => {
          this.sidebarVisible = false;
        }
    }
  ];

  ngOnInit(): void {
    let userInfo = localStorage.getItem("loginremember");
    if(userInfo != null) {
      this.userName = JSON.parse(userInfo).username;
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