import { Component, OnInit, Directive, ViewChild } from '@angular/core';
import { BaseComponent } from '../../base.component';
import { Router, ActivatedRoute } from '@angular/router';
import { CardRegisterModel } from '../../model/card-register.model';
import { AdService } from '../../service/ad.service';
import { AdRegisterInitialModel } from '../../model/ad-register-initial.model';
import { AuthService } from '../../service/auth.service';
import { AdTypeEnum } from '../../enum/ad-type.enum';
import { DataTransferService } from '../../service/data-transfer.service';
import { ActionTypeEnum } from '../../enum/action-type.enum';
import { AdImagesRegisterComponent } from '../../component/ad-images-register/ad-images-register.component';
import { ViewHelper } from '../../shared/view.helper';
import { Title } from '../../../../node_modules/@angular/platform-browser';

@Directive({
  selector: 'app-ad',
  providers: [AdService]
})
export class AdComponent extends BaseComponent implements OnInit {

  public model: CardRegisterModel = CardRegisterModel._new();
  public initial: AdRegisterInitialModel = AdRegisterInitialModel._new()
  public type: AdTypeEnum = AdTypeEnum.none;
  public actionType: ActionTypeEnum = ActionTypeEnum.none;

  constructor(
    public viewHelper: ViewHelper,
    public authService: AuthService,
    public adService: AdService,
    public dataTransferService: DataTransferService,
    public router: Router, 
    public title: Title) {
    super(dataTransferService, router, title);
  }

  ngOnInit() {
    this.setType();
    
    console.log(this.type)
    
    this.init();
  }
  

  protected setActionType() { }
  protected setType() { }
  protected nextStep() { }
  public init(): void { }
  
  public setTitle(text:string) : void {
    super.setTitle(text)
  }

  public isAdTypeSale(): boolean { return this.viewHelper.isAdTypeSale(this.type); }
  public isAdTypeDonation(): boolean { return this.viewHelper.isAdTypeDonation(this.type); }
}
