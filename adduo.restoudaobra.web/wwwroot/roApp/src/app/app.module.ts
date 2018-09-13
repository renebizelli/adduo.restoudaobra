import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { ROUTES } from './app.routes';
import { Configs } from './app.configs'
import { SharedModule } from "./module/shared.module"
import { AuthModule } from "./module/auth.module"
import { RouterModule } from '@angular/router';
import { HTTP_INTERCEPTORS } from '@angular/common/http'
import { ngfModule } from 'angular-file';

import { AppComponent } from './app.component';
import { AccountPageComponent } from './pages/account-page/account-page.component';

import { RegisterFinalizationPageComponent } from './pages/register-finalization-page/register-finalization-page.component';
import { RegisterConfirmationPageComponent } from './pages/register-confirmation-page/register-confirmation-page.component';
import { RedefinePasswordSolicitationPageComponent } from './pages/redefine-password-solicitation-page/redefine-password-solicitation-page.component';
import { RedefinePasswordSolicitationFinalizationPageComponent } from './pages/redefine-password-solicitation-finalization-page/redefine-password-solicitation-finalization-page.component';
import { DataTransferService } from './service/data-transfer.service';
import { RedefinePasswordChangePageComponent } from './pages/redefine-password-change-page/redefine-password-change-page.component';
import { AuthInterceptor } from './interceptor/auth.interceptor';
import { RedefinePasswordChangeFinalizationPageComponent } from './pages/redefine-password-change-finalization-page/redefine-password-change-finalization-page.component';
import { AccountMyInfoPageComponent } from './pages/account-my-info-page/account-my-info-page.component';
import { LoginComponent } from './component/login/login.component';
import { OwnerRegisterComponent } from './component/owner-register/owner-register.component';
import { AddressRegisterComponent } from './component/address-register/address-register.component';
import { AddressRegisterNewComponent } from './component/address-register-new/address-register-new.component';
import { AddressRegisterExistComponent } from './component/address-register-exist/address-register-exist.component';
import { MenuComponent } from './component/menu/menu.component';
import { FinalizationComponent } from './component/finalization/finalization.component';
import { AccountMyAdPageComponent } from './pages/account-my-ad-page/account-my-ad-page.component';
import { AdPaymentPageComponent } from './pages/ad-payment-page/ad-payment-page.component';
import { AuthGuard } from './guard/auth.guard';
import { LoginService } from './service/login.service';
import { AdRegisterDonationPageComponent } from './pages/ad-register-page/ad-register-donation-page.component';
import { AdRegisterSalePageComponent } from './pages/ad-register-page/ad-register-sale-page.component';
import { AdUpdateDonationPageComponent } from './pages/ad-update-page/ad-update-donation-page.component';
import { AdUpdateSalePageComponent } from './pages/ad-update-page/ad-update-sale-page.component';
import { AdImagesRegisterComponent } from './component/ad-images-register/ad-images-register.component';
import { LoaderComponent } from './component/loader/loader.component';
import { BaseComponent } from './base.component';
import { AdComponent } from './pages/ad-register-page/ad.component';
import { AdRegisterComponent } from './pages/ad-register-page/ad-register.component';
import { AdUpdateComponent } from './pages/ad-update-page/ad-update.component';
import { AdTypeTitleComponent } from './component/ad-type-title/ad-type-title.component';
import { MyAdComponent } from './component/my-ad/my-ad.component';
import { ViewHelper } from './shared/view.helper';
import { TypeHelper } from './shared/type.helper';
import { PageTitleComponent } from './component/page-title/page-title.component';
import { SummaryErrorComponent } from './component/summary-error/summary-error.component';
import { ReviewFieldComponent } from './component/review-field/review-field.component';
import { ReviewFieldInvalidComponent } from './component/review-field/review-field-invalid.component';
import { ReviewFieldEmptyComponent } from './component/review-field/review-field-empty.component';
import { ReviewFieldDifferentComponent } from './component/review-field/review-field-different.component';
import { ReviewFieldValidComponent } from './component/review-field/review-field-valid.component';
import { ReviewFieldNotFoundComponent } from './component/review-field/review-field-notfound.component';
import { ReviewFieldContainerComponent } from './component/review-field-container/review-field-container.component';
import { ReviewFieldAlreadyComponent } from 'src/app/component/review-field/review-field-already.component';
import { ContactPageComponent } from './pages/contact-page/contact-page.component';
import { FieldTextareaComponent } from './component/field/field-textarea.component';
import { ContactFinalizationPageComponent } from './pages/contact-finalization-page/contact-finalization-page.component';
import { FieldComponent } from './component/field/field.component';
import { FieldTextComponent } from './component/field/field-text.component';
import { FieldPasswordComponent } from './component/field/field-password.component';
import { FieldCurrencyComponent } from './component/field/field-currency.component';
import { FieldMaskComponent } from './component/field/field-mask.component';

@NgModule({
  declarations: [
    BaseComponent,
    AppComponent,
    MenuComponent,
    AccountPageComponent,
    LoginComponent,
    OwnerRegisterComponent,
    FinalizationComponent,
    RegisterFinalizationPageComponent,
    RegisterConfirmationPageComponent,
    RedefinePasswordSolicitationPageComponent,
    RedefinePasswordSolicitationFinalizationPageComponent,
    RedefinePasswordChangePageComponent,
    RedefinePasswordChangeFinalizationPageComponent,
    AccountMyInfoPageComponent,
    AddressRegisterComponent,
    AddressRegisterNewComponent,
    AddressRegisterExistComponent,
    AccountMyAdPageComponent,
    AdComponent,
    AdPaymentPageComponent,
    AdRegisterComponent,
    AdRegisterDonationPageComponent,
    AdRegisterSalePageComponent,
    AdUpdateComponent,
    AdUpdateDonationPageComponent,
    AdUpdateSalePageComponent,
    AdImagesRegisterComponent,
    LoaderComponent,
    AdTypeTitleComponent,
    MyAdComponent,
    PageTitleComponent,
    SummaryErrorComponent,
    ReviewFieldComponent,
    ReviewFieldEmptyComponent,
    ReviewFieldDifferentComponent,
    ReviewFieldInvalidComponent,
    ReviewFieldValidComponent,
    ReviewFieldNotFoundComponent,
    ReviewFieldAlreadyComponent,
    ReviewFieldContainerComponent,
    ContactPageComponent,
    FieldTextareaComponent,
    ContactFinalizationPageComponent,
    FieldComponent,
    FieldTextComponent,
    FieldPasswordComponent,
    FieldMaskComponent,
    FieldCurrencyComponent
  ],
  imports: [
    ngfModule,
    BrowserModule,
    RouterModule.forRoot(ROUTES),
    SharedModule,
    AuthModule
  ],
  providers:
    [
      Configs,
      DataTransferService,
      { provide: HTTP_INTERCEPTORS, useClass: AuthInterceptor, multi: true },
      AuthGuard,
      LoginService,
      ViewHelper,
      TypeHelper
    ],
  bootstrap: [AppComponent]
})
export class AppModule { }
