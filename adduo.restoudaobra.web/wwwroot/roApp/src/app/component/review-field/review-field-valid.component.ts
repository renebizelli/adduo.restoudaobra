import { Component, OnInit, Input } from '@angular/core';
import { TypeHelper } from '../../shared/type.helper';
import { ReviewFieldComponent } from './review-field.component';
import { ViewHelper } from '../../shared/view.helper';

@Component({
  selector: 'app-review-field-valid',
  templateUrl: './review-field.component.html'
})
export class ReviewFieldValidComponent extends ReviewFieldComponent {

  constructor(public viewHelper:ViewHelper) {
    super(viewHelper)

    this.ok = true;
  }

  public test(): boolean {
    return this.viewHelper.isValid(this.property);
  }
}
