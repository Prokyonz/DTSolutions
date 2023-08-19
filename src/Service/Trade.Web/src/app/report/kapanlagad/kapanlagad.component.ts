import { DatePipe } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { MessageService } from 'primeng/api';
import { SharedService } from '../../common/shared.service';
import { RememberCompany } from '../../shared/component/companyselection/companyselection.component';

@Component({
  selector: 'app-kapanlagad',
  templateUrl: './kapanlagad.component.html',
  styleUrls: ['./kapanlagad.component.scss']
})
export class KapanlagadComponent implements OnInit {
  allkapan: any[] = [];
  loading: boolean = true;
  RememberCompany: RememberCompany = new RememberCompany();
  kapanid: any = [];
  groupedData: { [category: string]: any[] } = {};
  kapandata: any[] = [];
  inward: any[] = [];
  outward:any[] = [];
  closing:any[] = [];
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

  getkapan(){
    this.allkapan = [];
    this.sharedService.customGetApi("Report/GetAllKapan?companyid=" + this.RememberCompany.company.id).subscribe((t) => {
      if (t.success == true){
        if (t.data != null && t.data.length > 0){
          t.data = [
            ...t.data
          ];

          t.data.forEach((item: any) => {
            this.allkapan.push({ name: item});
          });
          console.log(this.allkapan);
        }
      }
    });      
  }

  handlekapan(event: any){
    this.kapanid = event.value;
  }

  showDetails(){
    debugger;
    this.sharedService.customGetApi("Report/GetKapanLagadReport?kapanId=" + this.kapanid.name.id).subscribe((t) => {
      if (t.success == true){
        console.log(t.data);
        this.kapandata = t.data;
        this.inward = this.kapandata.filter(f=>f.category.toLowerCase() == "inward");

        this.TotalInwardAmount = this.inward.reduce((accumulator, currentObject) => {
          return accumulator + currentObject.amount;
        }, 0);
        this.TotalInwardRate = this.inward.reduce((accumulator, currentObject) => {
          return accumulator + currentObject.rate;
        }, 0);
        this.TotalInwardNetWeight = this.inward.reduce((accumulator, currentObject) => {
          return accumulator + currentObject.netWeight;
        }, 0);
        
        this.outward = this.kapandata.filter(f=>f.category.toLowerCase() == "outward");        

        this.TotalOutwardAmount = this.closing.reduce((accumulator, currentObject) => {
          return accumulator + currentObject.amount;
        }, 0);
        this.TotalOutwardRate = this.closing.reduce((accumulator, currentObject) => {
          return accumulator + currentObject.rate;
        }, 0);
        this.TotalOutwardNetWeight = this.closing.reduce((accumulator, currentObject) => {
          return accumulator + currentObject.netWeight;
        }, 0);


        this.closing = this.kapandata.filter(f=>f.category.toLowerCase() == "closing");

        this.TotalClosingAmount = this.closing.reduce((accumulator, currentObject) => {
          return accumulator + currentObject.amount;
        }, 0);
        this.TotalClosingRate = this.closing.reduce((accumulator, currentObject) => {
          return accumulator + currentObject.rate;
        }, 0);
        this.TotalClosingNetWeight = this.closing.reduce((accumulator, currentObject) => {
          return accumulator + currentObject.netWeight;
        }, 0);
        //this.groupDataByCategory();
      }
    });
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
}
