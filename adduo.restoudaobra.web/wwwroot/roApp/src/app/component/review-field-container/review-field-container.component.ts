import { Component, OnInit, Input } from '@angular/core';
import { PropertyStringModel } from '../../shared/propertystring.model';
import { TypeHelper } from '../../shared/type.helper';

@Component({
  selector: 'app-review-field-container',
  templateUrl: './review-field-container.component.html'
})
export class ReviewFieldContainerComponent implements OnInit {

  @Input() public invalidText: string = 'inválido';
  @Input() public emptyText: string = 'campo obrigatório'
  @Input() public differentText: string = TypeHelper.stringEmpty;
  @Input() public notfoundText: string = TypeHelper.stringEmpty;
  @Input() public alreadyText: string = TypeHelper.stringEmpty;
  @Input() public property: PropertyStringModel = new PropertyStringModel();

  constructor() {
  }

  ngOnInit() {
  }

}
