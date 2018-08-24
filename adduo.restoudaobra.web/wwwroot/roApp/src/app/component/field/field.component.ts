import { Component, OnInit, Input, Directive } from '@angular/core';
import { PropertyStringModel } from '../../shared/propertystring.model';
import { TypeHelper } from '../../shared/type.helper';

@Directive({ 
  selector: 'app-field'
})
export class FieldComponent {

  @Input() public label: string = TypeHelper.stringEmpty;
  @Input() public invalidText: string = 'inválido';
  @Input() public emptyText: string = 'campo obrigatório'
  @Input() public differentText: string = TypeHelper.stringEmpty;
  @Input() public notfoundText: string = TypeHelper.stringEmpty;
  @Input() public alreadyText: string = TypeHelper.stringEmpty;

  @Input() public property: PropertyStringModel = new PropertyStringModel();
  @Input() public maxlength: number = 256;
  @Input() public placeholder: string = TypeHelper.stringEmpty;
  @Input() public name: string = TypeHelper.stringEmpty;

  constructor() {
  }

}
