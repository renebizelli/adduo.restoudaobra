import { BrowserModule } from '@angular/platform-browser';
import { NgModule, Injector } from '@angular/core';
import { SharedModule } from "../../../../src/app/module/shared.module"
import { AuthModule } from "../../../../src/app/module/auth.module"
import { createCustomElement } from '@angular/elements';
import { RouterModule } from '@angular/router';

import { MenuComponent } from './menu/menu.component';
import { AppComponent } from './app.component';

@NgModule({
  declarations: [
    MenuComponent,
    AppComponent
  ],
  imports: [
    BrowserModule,
    SharedModule,
    AuthModule,
    RouterModule.forRoot([]),
  ],
  entryComponents: [MenuComponent]
})
export class AppModule { 
  constructor(private injector: Injector) { 
  
    const menuElement = createCustomElement(MenuComponent, { injector: this.injector });
    customElements.define('menu-element', menuElement)
  }
  
  ngDoBootstrap() {
  }
}
