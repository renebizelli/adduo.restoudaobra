import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { LocalService } from '../../service/local.service';
import { ItemModel } from '../../model/item.model';
import { AddressRegisterModel } from '../../model/address-register.model';
import { AddressRegisterTypeEnum } from '../../enum/address-register-type.enum';
import { ActionTypeEnum } from '../../enum/action-type.enum';

@Component({
  selector: 'app-address-register-new',
  templateUrl: './address-register-new.component.html'
})
export class AddressRegisterNewComponent implements OnInit {

  public states: ItemModel[] = LocalService.states();

  @Input() public address: AddressRegisterModel = AddressRegisterModel._new();

  @Output() registerType: EventEmitter<ActionTypeEnum> = new EventEmitter();

  constructor() {
  }

  ngOnInit() {
    //this.address = AddressRegisterModel._new();
    //this.address.actionType = ActionTypeEnum.new;
  }

  public changeType(): void {
    this.registerType.emit(ActionTypeEnum.update);
  }

}
