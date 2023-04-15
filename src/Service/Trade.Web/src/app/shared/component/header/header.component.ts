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
  @Input() showSideBar:boolean = false;
  @Output() onClickMainIcon = new EventEmitter();


  sidebarVisible!: boolean;
  items: MenuItem[] = [
    {
        label: 'Home',
        icon: 'pi pi-fw pi-file',
        routerLink: "/dashboard",
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
        icon: 'pi pi-fw pi-user',
        expanded: false,
        items: [
            {
                label: 'Purchase',
                icon: 'pi pi-fw pi-user-plus'
            },
            {
                label: 'Sales',
                icon: 'pi pi-fw pi-user-minus'
            },
            {
                label: 'Payment',
                icon: 'pi pi-fw pi-users'
            },
            {
                label: 'Receipt',
                icon: 'pi pi-fw pi-users'
            }
        ]
    },
    {
      label: 'Settings',
      icon: 'pi pi-spin pi-cog',
    },
    {
        label: 'Logout',
        icon: 'pi pi-fw pi-calendar',
        routerLink: "/login",
        command: () => {
          this.sidebarVisible = false;
        }
    }
  ];

  ngOnInit(): void {
    
  }  

  iconClick() {
    this.sidebarVisible = this.showSideBar;
    this.onClickMainIcon.emit();
  }
}