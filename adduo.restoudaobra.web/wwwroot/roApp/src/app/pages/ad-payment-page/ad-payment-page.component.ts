import { Component, OnInit } from '@angular/core';
import { BaseComponent } from '../../base.component';
import { Router } from '@angular/router';
import { DataTransferService } from '../../service/data-transfer.service';
import { Title } from '../../../../node_modules/@angular/platform-browser';

@Component({
  selector: 'app-ad-payment-page',
  templateUrl: './ad-payment-page.component.html'
})
export class AdPaymentPageComponent extends BaseComponent implements OnInit {

  constructor(
    public router: Router,
    public dataTransferService: DataTransferService,
    public title : Title
  ) {
    super(dataTransferService, router, title)
  }

  public ok() {
    this.redirect('conta/meus-anuncios')
  }

  ngOnInit() {
  }

}
