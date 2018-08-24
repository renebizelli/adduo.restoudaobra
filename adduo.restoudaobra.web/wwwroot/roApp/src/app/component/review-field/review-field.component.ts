import { Component, OnInit, Input, Directive } from '@angular/core';
import { TypeHelper } from '../../shared/type.helper';
import { PropertyStringModel } from '../../shared/propertystring.model';
import { ViewHelper } from '../../shared/view.helper';

@Directive({
  selector: 'app-review-field'
})
export class ReviewFieldComponent  {

  @Input() public text: string = TypeHelper.stringEmpty;
  @Input() public property: PropertyStringModel = new PropertyStringModel();

  public ok: boolean = false;
  public error: boolean = false;

  constructor(public viewHelper: ViewHelper) { }

  public test(): boolean {
    console.log('pai')
    return false;
  }

}
