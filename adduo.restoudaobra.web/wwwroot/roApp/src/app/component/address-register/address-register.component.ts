import { Component, OnInit, Input, OnChanges, SimpleChanges } from '@angular/core';
import { AddressRegisterModel } from '../../model/address-register.model';
import { AddressDetailModel } from '../../model/address-detail.model';
import { AddressRegisterTypeEnum } from '../../enum/address-register-type.enum';
import { ActionTypeEnum } from '../../enum/action-type.enum';
import { DataTransferService } from '../../service/data-transfer.service';
import { Router } from '@angular/router';
import { BaseComponent } from '../../base.component';
import { Title } from '../../../../node_modules/@angular/platform-browser';

@Component({
  selector: 'app-address-register',
  templateUrl: './address-register.component.html'
})
export class AddressRegisterComponent extends BaseComponent implements OnInit  {


  @Input() public address: AddressRegisterModel

  @Input() public addresses: AddressDetailModel[] = [];

  private type: ActionTypeEnum = ActionTypeEnum.none;

  constructor(
    public dataTransferService: DataTransferService,
    public router: Router, 
    public title: Title) {
    super(dataTransferService, router, title);
  }

  ngOnInit() {
    this.type = ActionTypeEnum.new;
    if (this.addresses.length) {
      this.type = ActionTypeEnum.update;
    }
    this.address.actionType = this.type;
  }

  public isTypeNew(): boolean { return this.type == ActionTypeEnum.new; }
  public isTypeExist(): boolean { return this.type == ActionTypeEnum.update; }

  public receiverRegisterType(type: ActionTypeEnum): void {
    this.type = type;
    this.address.actionType = type;
  }
}
