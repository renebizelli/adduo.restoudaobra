import { Component, OnInit } from '@angular/core';
import { AdRegisterComponent } from './ad-register.component';
import { Router } from '@angular/router';
import { AdService } from '../../service/ad.service';
import { AuthService } from '../../service/auth.service';
import { AdTypeEnum } from '../../enum/ad-type.enum';
import { DataTransferService } from '../../service/data-transfer.service';
import { ViewHelper } from '../../shared/view.helper';

@Component({
  selector: 'app-ad-register-sale',
  templateUrl: './ad.component.html',
})
export class AdRegisterSalePageComponent extends AdRegisterComponent implements OnInit {

  constructor(
    public viewHelper: ViewHelper,
    public authService: AuthService,
    public adService: AdService,
    public dataTransferService: DataTransferService,
    public router: Router) {
    super(viewHelper, authService, adService, dataTransferService, router);
  }

  protected setType() {
    this.type = AdTypeEnum.sale;
  }

  protected nextStep() {
    this.redirectWithQuerystring('quero-vender/pagamento/', [this.initial.guid]);
  }

  ngOnInit() {
    super.ngOnInit();
  }

  public isAdTypeSale(): boolean { return true; }


}
