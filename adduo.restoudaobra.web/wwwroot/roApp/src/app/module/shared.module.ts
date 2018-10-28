import { NgModule } from "../../../node_modules/@angular/core"
import { CommonModule } from "@angular/common"
import { HttpClientModule  } from '@angular/common/http'
import { StorageServiceModule } from 'angular-webstorage-service'
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { TextMaskModule } from 'angular2-text-mask';
import { NgxCurrencyModule } from "ngx-currency";
import { HttpService } from "../service/http.service";
import { ScrollService } from "../service/scroll.service";

@NgModule({
  declarations: [HttpService, ScrollService],
  imports : [
    CommonModule, 
    HttpClientModule, 
    StorageServiceModule, 
    FormsModule, 
    ReactiveFormsModule, 
    TextMaskModule, 
    NgxCurrencyModule],
    exports : 
    [
      CommonModule,
      HttpClientModule, 
      StorageServiceModule, 
      FormsModule, 
      ReactiveFormsModule, 
      TextMaskModule, 
      NgxCurrencyModule,
      HttpService,
      ScrollService
    ],
    providers : [ HttpService, ScrollService ]
})
export class  SharedModule {


}