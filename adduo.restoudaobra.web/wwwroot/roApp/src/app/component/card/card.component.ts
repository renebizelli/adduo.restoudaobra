import { Component, OnInit, Input } from '@angular/core';
import { CardDetailModel } from '../../model/card-detail.model';
import { ViewHelper } from '../../shared/view.helper';
import { AdTypeEnum } from '../../enum/ad-type.enum';

@Component({
  selector: 'app-card',
  templateUrl: './card.component.html'
})
export class CardComponent implements OnInit {

  @Input() public card: CardDetailModel = CardDetailModel._new()

  constructor(public viewHelper:ViewHelper) { }

  ngOnInit() {
  }
  
  public getClass() : String {
    return this.viewHelper.getTypeToClass(this.card.ad.type);
  }
  
   public getUrl() : String {
   
    let type = this.viewHelper.getTypeToUrl(this.card.ad.type);
   
    return '/' + type + '/' + this.card.ad.guid + '/' + this.card.ad.url;
  }
 
  public getTypeText() : string {
    return this.viewHelper.getTypeToText(this.card.ad.type);
  }
 
  public getFirstImage() : string {
  
    let image = ''
    
    if(this.card.images.length) {
      image = this.card.images[0]
    }
  
    return image
  }
  
  
}
