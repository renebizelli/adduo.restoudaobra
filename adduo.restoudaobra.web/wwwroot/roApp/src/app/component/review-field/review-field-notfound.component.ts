import { Component, OnInit, Input } from '@angular/core';
import { TypeHelper } from '../../shared/type.helper';
import { ReviewFieldComponent } from './review-field.component';
import { ViewHelper } from '../../shared/view.helper';

@Component({
  selector: 'app-review-field-notfound',
  templateUrl: './review-field.component.html'
})
export class ReviewFieldNotFoundComponent extends ReviewFieldComponent {

  constructor(public viewHelper:ViewHelper) {
    super(viewHelper)
    this.error = true;
  }

  public test(): boolean {
    return this.viewHelper.isErrorCodeNotFound(this.property);
  }
}
