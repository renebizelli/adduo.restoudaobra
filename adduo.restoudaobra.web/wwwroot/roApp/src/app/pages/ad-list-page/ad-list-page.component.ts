import { Component, OnInit } from '@angular/core';
import { BaseComponent } from '../../base.component';
import { SearchService  } from '../../service/search.service';
import { map, catchError, finalize } from 'rxjs/operators';
import { throwError } from 'rxjs';
import { Router, ActivatedRoute } from '@angular/router';
import { DataTransferService } from '../../service/data-transfer.service';
import { HttpErrorResponse } from '@angular/common/http';
import { ResponseEnvelope } from '../../envelope/response.envelope';
import { CardDetailModel } from '../../model/card-detail.model';

@Component({
  selector: 'app-ad-list-page',
  templateUrl: './ad-list-page.component.html'
})
export class AdListPageComponent extends BaseComponent  implements OnInit {

  public cards: CardDetailModel[] = [];

  constructor(
    public searchService: SearchService,
    public router: Router,
    public dataTransferService: DataTransferService,
    public activatedRoute: ActivatedRoute) {
    super(dataTransferService, router);
  }


  ngOnInit() {
    this.init();
  }

  private init(): void {

    this.processRunningStart();

    this.searchService.list('')
      .pipe(
        map((m) => m.body),
        catchError((response: HttpErrorResponse) => {
          let e: ResponseEnvelope<CardDetailModel[]> = response.error as ResponseEnvelope<CardDetailModel[]>;
          super.processHttpErrorResponse(response)
          return throwError(response);
        }),
        finalize(() => {
          this.processRunningStop();
          this.isAlready = true;
        }))
      .subscribe((response) => {
        this.cards = response.dtos;
      });
  }

}
