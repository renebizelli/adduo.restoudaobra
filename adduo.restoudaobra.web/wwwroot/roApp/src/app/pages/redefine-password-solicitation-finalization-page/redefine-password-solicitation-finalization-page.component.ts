import { Component, OnInit } from '@angular/core';
import { BaseComponent } from '../../base.component';
import { DataTransferService } from '../../service/data-transfer.service';
import { Router } from '@angular/router';
import { TypeHelper } from '../../shared/type.helper';

@Component({
  selector: 'app-redefine-password-solicitation-finalization-page',
  templateUrl: './redefine-password-solicitation-finalization-page.component.html'
})
export class RedefinePasswordSolicitationFinalizationPageComponent extends BaseComponent implements OnInit {

  public email: string = TypeHelper.stringEmpty

  constructor(
    public dataTransferService: DataTransferService,
    public router: Router) {
    super(dataTransferService, router);
    console.log(this.dataTransferService.get("data"));
  }



  ngOnInit() {
    this.email = this.dataTransferService.get("data");

    console.log(this.dataTransferService.get("data"));
  }

}
