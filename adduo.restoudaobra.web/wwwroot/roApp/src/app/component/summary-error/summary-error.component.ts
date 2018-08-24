import { Component, OnInit, Input } from '@angular/core';
import { SummaryItemModel } from '../../model/summary-item.model';

@Component({
  selector: 'app-summary-error',
  templateUrl: './summary-error.component.html'
})
export class SummaryErrorComponent implements OnInit {

  @Input() items:SummaryItemModel[] = []

  constructor() { }

  ngOnInit() {
  }

}
