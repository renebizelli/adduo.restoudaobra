  import { Component, PLATFORM_ID, Inject, APP_ID } from '@angular/core';
  import { isPlatformBrowser } from '@angular/common';
  import { ActivatedRoute, Router, ActivationEnd } from '../../node_modules/@angular/router';
import { AdCacheService } from './service/ad-cache.service';

  @Component({
    selector: 'app-root',
    templateUrl: './app.component.html'
  })
  export class AppComponent {

    constructor(
      @Inject(PLATFORM_ID) private platformId: Object,
      @Inject(APP_ID) private appId: string, 
      public adCacheService: AdCacheService,
      public router : Router) {
      
       router.events.subscribe( (event: any) => {
       
        if(event instanceof ActivationEnd)  {
        
          let noscroll = false
          let noresetadcache = false;
          
          if(event.snapshot.data)
          {
              noscroll = event.snapshot.data.noscroll
              noresetadcache = event.snapshot.data.noresetadcache
          }
       
          if(!noresetadcache) {
            this.adCacheService.reset()
          }
          
          if (!noscroll && isPlatformBrowser(this.platformId)) {
          
            let scrollToTop = window.setInterval(() => {
              let pos = window.pageYOffset;
              if (pos > 0) {
                window.scrollTo(0, pos - 50);
              }
              else {
                window.clearInterval(scrollToTop);
              }
            }, 16);
          }
          
          }

       
       
       })
      
    }


    onActivate(event: any): void {
    
    
    }

  }