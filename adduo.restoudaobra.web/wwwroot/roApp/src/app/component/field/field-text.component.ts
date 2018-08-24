import { Component, OnInit, Input } from '@angular/core';
import { FieldComponent } from './field.component';

@Component({ 
  selector: 'app-field-text',
  templateUrl: './field-text.component.html'
})
export class FieldTextComponent extends FieldComponent {

  constructor() {
    super()
  }

}
