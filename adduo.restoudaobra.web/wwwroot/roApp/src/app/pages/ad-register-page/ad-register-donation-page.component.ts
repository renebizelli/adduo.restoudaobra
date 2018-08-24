import { Component, OnInit } from '@angular/core';
import { AdRegisterComponent } from './ad-register.component';
import { Router } from '@angular/router';
import { AdService } from '../../service/ad.service';
import { AuthService } from '../../service/auth.service';
import { AdTypeEnum } from '../../enum/ad-type.enum';
import { DataTransferService } from '../../service/data-transfer.service';
import { ViewHelper } from '../../shared/view.helper';

@Component({
  selector: 'app-ad-registrer-donation',
  templateUrl: './ad.component.html',
})
export class AdRegisterDonationPageComponent extends AdRegisterComponent implements OnInit {

  constructor(
    public viewHelper: ViewHelper,
    public authService: AuthService,
    public adService: AdService,
    public dataTransferService: DataTransferService,
    public router: Router) {
    super(viewHelper, authService, adService, dataTransferService, router);
  }

  protected setType() {
    this.type = AdTypeEnum.donation;
  }

  protected nextStep() {
    this.redirect('conta/meus-anuncios');
  }

  ngOnInit() {
    super.ngOnInit();
  }

}
