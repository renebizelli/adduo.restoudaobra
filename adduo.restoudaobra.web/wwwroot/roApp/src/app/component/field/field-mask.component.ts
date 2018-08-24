import { Component, OnInit, Input } from '@angular/core';
import { FieldComponent } from './field.component';
import { TypeHelper } from '../../shared/type.helper';

@Component({
  selector: 'app-field-mask',
  templateUrl: './field-mask.component.html'
})
export class FieldMaskComponent extends FieldComponent implements OnInit {

  ngOnInit(): void {
    this.format = this.formats[this.mask]

  }
  public format = []

  @Input() mask: string = TypeHelper.stringEmpty;

  private formats = {
    phone: ['(', /[1-9]/, /\d/, ')', ' ', /\d/, /\d/, /\d/, /\d/, '-', /\d/, /\d/, /\d/, /\d/],
    cellphone: ['(', /\d/, /\d/, ')', ' ',/\d/,/\d/,/\d/,/\d/,/\d/, '-', /\d/,/\d/,/\d/,/\d/],
    cpf: [/\d/, /\d/, /\d/, '.', /\d/, /\d/, /\d/, '.', /\d/,/\d/,/\d/, '.', /\d/, /\d/, /\d/],
    money: [/[1-9]/, /[1-9]/, /[1-9]/, /[1-9]/, /[1-9]/, /\d/, ',', /\d/, /\d/]
  }

  constructor() {
    super()
  }



}
