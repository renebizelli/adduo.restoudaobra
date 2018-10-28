import { Component, OnInit, HostListener } from '@angular/core';
import { BaseComponent } from '../../base.component';
import { SearchService  } from '../../service/search.service';
import { map, catchError, finalize } from 'rxjs/operators';
import { throwError } from 'rxjs';
import { Router, ActivatedRoute } from '@angular/router';
import { DataTransferService } from '../../service/data-transfer.service';
import { HttpErrorResponse } from '@angular/common/http';
import { ResponseEnvelope } from '../../envelope/response.envelope';
import { CardDetailModel } from '../../model/card-detail.model';
import { Title } from '../../../../node_modules/@angular/platform-browser';
import { ScrollService } from '../../service/scroll.service';
import { AdCacheService } from '../../service/ad-cache.service';

@Component({
  selector: 'app-ad-list-page',
  templateUrl: './ad-list-page.component.html'
})
export class AdListPageComponent extends BaseComponent  implements OnInit {

@HostListener("window:scroll", []) 
onWindowScroll() {
  this.scrollService.set('app-ad-list-page', window, document)
}
 
  public cards: CardDetailModel[] = []

  constructor(
    public searchService: SearchService,
    public router: Router,
    public dataTransferService: DataTransferService,
    public activatedRoute: ActivatedRoute,
    public title : Title,
    public scrollService: ScrollService,
    public adCacheService: AdCacheService 
) {
    super(dataTransferService, router, title);
     
  }

  ngOnInit() {
    this.setTitle('Anúncios')
    this.init();
  }
  
  private init(): void {

      this.processRunningStart();

      this.searchService.list('')
        .subscribe((response) => {
        
            this.cards = this.adCacheService.get();
            
            setTimeout(() => {
            
               this.scrollService.scroll('app-ad-list-page');
                this.processRunningStop();
               
            }, 1)
            
        });
    }

}
