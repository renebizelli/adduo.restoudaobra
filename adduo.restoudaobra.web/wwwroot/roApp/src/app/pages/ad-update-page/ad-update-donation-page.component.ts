import { Component, OnInit } from '@angular/core';
import { AdUpdateComponent } from './ad-update.component';
import { Router, ActivatedRoute } from '@angular/router';
import { AdService } from '../../service/ad.service';
import { AuthService } from '../../service/auth.service';
import { AdTypeEnum } from '../../enum/ad-type.enum';
import { DataTransferService } from '../../service/data-transfer.service';
import { ViewHelper } from '../../shared/view.helper';
import { Title } from '../../../../node_modules/@angular/platform-browser';

@Component({
  selector: 'app-ad-update-donation',
  templateUrl: '../ad-register-page/ad.component.html'
})
export class AdUpdateDonationPageComponent extends AdUpdateComponent implements OnInit {

  constructor(
    public viewHelper: ViewHelper,
    public activatedRoute: ActivatedRoute,
    public authService: AuthService,
    public adService: AdService,
    public dataTransferService: DataTransferService,
    public router: Router,
    public title: Title) {
    super(viewHelper, activatedRoute, authService, adService, dataTransferService, router, title);
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
