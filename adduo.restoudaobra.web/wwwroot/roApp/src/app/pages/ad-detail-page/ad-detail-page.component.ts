import { Component, OnInit } from '@angular/core';
import { BaseComponent } from '../../base.component';
import { SearchService } from '../../service/search.service';
import { Router, ActivatedRoute } from '../../../../node_modules/@angular/router';
import { DataTransferService } from '../../service/data-transfer.service';
import { CardDetailModel } from '../../model/card-detail.model';
import { HttpErrorResponse } from '@angular/common/http';
import { catchError, map, finalize } from 'rxjs/operators';
import { ResponseEnvelope } from '../../envelope/response.envelope';
import { throwError } from 'rxjs';
import { ViewHelper } from '../../shared/view.helper';
import { TypeHelper } from '../../shared/type.helper';
import { ContactOwner } from '../../model/contact-owner-model';

declare var $: any;

@Component({
  selector: 'app-ad-detail-page',
  templateUrl: './ad-detail-page.component.html'
})
export class AdDetailPageComponent extends BaseComponent implements OnInit {

  public model: CardDetailModel = CardDetailModel._new();
  public contact: ContactOwner = ContactOwner._new()
  
  public isContactShow:boolean = false;
  
  public addressFormat : string = TypeHelper.stringEmpty

  constructor(
    public viewHelper: ViewHelper,
    public activatedRoute: ActivatedRoute,
    public searchService: SearchService,
    public router: Router,
    public dataTransferService: DataTransferService,
  ) {
    super(dataTransferService, router);
  }

  ngOnInit() {
    let id = this.activatedRoute.snapshot.params.id;
    this.processRunningStart();
    this.searchService.get(id)
      .pipe(
        map((m) => m.body),
        catchError((response: HttpErrorResponse) => {
          let e: ResponseEnvelope<CardDetailModel> = response.error as ResponseEnvelope<CardDetailModel>;
          super.processHttpErrorResponse(response)
          return throwError(response);
        }),
        finalize(() => {
          this.processRunningStop();
          this.isAlready = true;
        }))
      .subscribe((response) => {
        this.model = response.dto;
        this.address()
      });
  }
  
  public isShowLine(text:string) : boolean {
    return text != null && text != undefined && text != '' 
  }
  
  public isAdTypeSale() : boolean {
    return this.viewHelper.isAdTypeSale(this.model.ad.type);
  }
  
  public getTitleClass() : String {
    let type = this.viewHelper.getTypeToClass(this.model.ad.type);
    return type + '-header'
  }
  
  public getTypeText() : string {
    return this.viewHelper.getTypeToText(this.model.ad.type);
  }

 
  public address() : void {
    this.addressFormat = this.model.address.district + ', ' + this.model.address.city + ' - ' + this.model.address.state;
  }
  
  public contactShow() : void {
    this.isContactShow = true
    
    this.contact.email = this.model.owner.email;
    this.contact.phoneFormat = this.model.owner.phoneFormat;
    this.contact.cellphoneFormat = this.model.owner.cellphoneFormat;
    
    $("#contact-owner").fadeIn();
    
  }

}
