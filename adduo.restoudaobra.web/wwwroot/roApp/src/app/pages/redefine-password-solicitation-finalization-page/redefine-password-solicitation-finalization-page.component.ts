import { Component, OnInit } from '@angular/core';
import { BaseComponent } from '../../base.component';
import { DataTransferService } from '../../service/data-transfer.service';
import { Router } from '@angular/router';
import { TypeHelper } from '../../shared/type.helper';
import { Title } from '../../../../node_modules/@angular/platform-browser';

@Component({
  selector: 'app-redefine-password-solicitation-finalization-page',
  templateUrl: './redefine-password-solicitation-finalization-page.component.html'
})
export class RedefinePasswordSolicitationFinalizationPageComponent extends BaseComponent implements OnInit {

  public email: string = TypeHelper.stringEmpty

  constructor(
    public dataTransferService: DataTransferService,
    public router: Router, 
    public title: Title) {
    super(dataTransferService, router, title);
  }
 
 ngOnInit() {
  this.setTitle('Redefinir senha')
    this.email = this.dataTransferService.get("data");
  }

}
