import { Component, OnInit, Input } from '@angular/core';
import { FieldComponent } from './field.component';

@Component({
  selector: 'app-field-textarea',
  templateUrl: './field-textarea.component.html'
})
export class FieldTextareaComponent extends FieldComponent {

  constructor() {
    super()
  }


}
