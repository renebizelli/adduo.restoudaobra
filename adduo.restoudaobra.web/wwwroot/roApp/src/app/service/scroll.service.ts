import { Directive, Injectable } from "../../../node_modules/@angular/core";
import { CardDetailModel } from "../model/card-detail.model";

@Injectable()
@Directive({selector:"[app-scroll-service]"})
export class ScrollService { 

  private verticalOffset:any = {}

  constructor() {}
  
  public set(page: string, window: Window, document: Document) : void {

    this.verticalOffset[page] = window.pageYOffset 
          || document.documentElement.scrollTop 
          || document.body.scrollTop || 0;
          
  }
  
  public get(page:string) : number {
    return this.verticalOffset[page];
  }
   
  public scroll(page:string) : void {
  
    if(this.verticalOffset[page])
    {
        console.log('scroll',parseInt( this.verticalOffset[page]))
        window.scrollTo(0, parseInt(this.verticalOffset[page]));
    }
  
  }
}
