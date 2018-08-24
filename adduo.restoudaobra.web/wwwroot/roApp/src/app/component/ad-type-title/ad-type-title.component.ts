import { Component, OnInit, Input } from '@angular/core';
import { AdTypeEnum } from '../../enum/ad-type.enum';
import { ViewHelper } from '../../shared/view.helper';

@Component({
  selector: 'app-ad-type-title',
  templateUrl: './ad-type-title.component.html'
})
export class AdTypeTitleComponent implements OnInit {

  @Input() public type: AdTypeEnum = AdTypeEnum.none;

  public donation: string = 'Quero doar'
  public sale: string = 'Quero vender'

  constructor(public viewHelper: ViewHelper) { }

  ngOnInit() {
  }

  public isAdTypeSale(): boolean {
    return this.viewHelper.isAdTypeSale(this.type);
  }


}
