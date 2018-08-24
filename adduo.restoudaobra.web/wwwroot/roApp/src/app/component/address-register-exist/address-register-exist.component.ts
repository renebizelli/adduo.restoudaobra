import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { AddressRegisterModel } from '../../model/address-register.model';
import { AddressDetailModel } from '../../model/address-detail.model';
import { AddressRegisterTypeEnum } from '../../enum/address-register-type.enum';
import { ActionTypeEnum } from '../../enum/action-type.enum';


@Component({
  selector: 'app-address-register-exist',
  templateUrl: './address-register-exist.component.html'
})
export class AddressRegisterExistComponent implements OnInit {

  @Input() public address: AddressRegisterModel;

  @Input() public addresses: AddressDetailModel[] = [];

  @Output() registerType: EventEmitter<ActionTypeEnum> = new EventEmitter();

  constructor() {
  }

  ngOnInit() {
    //this.address.actionType = ActionTypeEnum.update;
  }

  public select(addressSelect: AddressDetailModel): void {
    this.address.id.value = addressSelect.id;
  }

  public selected(selected: AddressDetailModel): boolean {
    return this.address.id.value == selected.id;
  }

  public changeType(): void {
    this.registerType.emit(ActionTypeEnum.new);
  }

}
