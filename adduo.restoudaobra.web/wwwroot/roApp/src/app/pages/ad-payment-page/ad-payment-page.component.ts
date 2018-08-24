import { Component, OnInit } from '@angular/core';
import { BaseComponent } from '../../base.component';
import { Router } from '@angular/router';
import { DataTransferService } from '../../service/data-transfer.service';

@Component({
  selector: 'app-ad-payment-page',
  templateUrl: './ad-payment-page.component.html'
})
export class AdPaymentPageComponent extends BaseComponent implements OnInit {

  constructor(
    public router: Router,
    public dataTransferService: DataTransferService,
  ) {
    super(dataTransferService, router)
  }

  public ok() {
    this.redirect('conta/meus-anuncios')
  }

  ngOnInit() {
  }

}
