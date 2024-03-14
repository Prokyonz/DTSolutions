import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { SharedService } from '../../common/shared.service';
import { RememberCompany } from '../../shared/component/companyselection/companyselection.component';
import { MessageService } from 'primeng/api';

@Component({
  selector: 'app-profitloss',
  templateUrl: './profitloss.component.html',
  styleUrls: ['./profitloss.component.scss']
})
export class ProfitlossComponent {
  loading: boolean = true;
  RememberCompany: RememberCompany = new RememberCompany();
  PageTitle = "PF Report";
  profitlossData: any[] = [];
  transformedData: any[] = [];
  totalDebitAmount: any;
  totalCreditAmount: any;

  constructor(private rote: Router, private sharedService: SharedService, private messageService: MessageService){

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

  getBalanceSheet(){
      this.loading = true;
      this.sharedService.customGetApi("Report/GetProfitLossReport?CompanyId=" + this.RememberCompany.company.id + "&FinancialYearId=" + this.RememberCompany.financialyear.id)
          .subscribe((data: any) => {
              debugger;
              this.profitlossData = data.data;
              this.transformedData = [];
              const debitData: any [] = this.profitlossData.filter(e => e.colType == 'Debit');
              const creditData: any [] = this.profitlossData.filter(e => e.colType == 'Credit');
              let index = 0;
              if (debitData.length >= creditData.length){
                debitData.forEach(element => {
                  const row : any = {};
                  row['DebitColType'] = element.type;
                  row['DebitAmount'] = element.amount;

                  row['CreditColType'] = creditData.length > index ? creditData[index].type : null;
                  row['CreditAmount'] = creditData.length > index ? creditData[index].amount : null;

                  index++;
                  this.transformedData.push(row);
                });
              }
              else{
                creditData.forEach(element => {
                  const row : any = {};
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

    // Function to format the number in Indian numbering system
formatIndianNumber(amount: number): string {
  const formatter = new Intl.NumberFormat('en-IN');
  return '₹' +formatter.format(amount);
}

  showMessage(type: string, message: string) {
    this.messageService.add({ severity: type, summary: message });
  }
}
