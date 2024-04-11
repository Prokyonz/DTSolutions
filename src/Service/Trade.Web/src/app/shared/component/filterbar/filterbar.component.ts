import { Component, EventEmitter, OnInit, Output } from '@angular/core';

@Component({
  selector: 'app-filterbar',
  templateUrl: './filterbar.component.html',
  styleUrls: ['./filterbar.component.scss']
})
export class FilterbarComponent implements OnInit {  
  @Output() onClickSearchButton = new EventEmitter<{startDate: Date, endDate: Date}>();
  startDate: Date = new Date();
  endDate: Date = new Date();

  ngOnInit(): void {
    let currentDate = new Date(); // Get the current date
    currentDate = new Date(currentDate.getFullYear(), currentDate.getMonth(), 1);
    this.startDate = currentDate;
    this.endDate = new Date();
  }

  onClick() {
    this.onClickSearchButton.emit({startDate: this.startDate, endDate: this.endDate});
  }
}
