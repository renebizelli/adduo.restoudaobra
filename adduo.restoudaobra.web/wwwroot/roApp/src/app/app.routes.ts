import { Routes } from '@angular/router';

import { AccountPageComponent } from './pages/account-page/account-page.component';
import { RegisterFinalizationPageComponent } from './pages/register-finalization-page/register-finalization-page.component';
import { RegisterConfirmationPageComponent } from './pages/register-confirmation-page/register-confirmation-page.component';
import { RedefinePasswordSolicitationPageComponent } from './pages/redefine-password-solicitation-page/redefine-password-solicitation-page.component'
import { RedefinePasswordSolicitationFinalizationPageComponent } from './pages/redefine-password-solicitation-finalization-page/redefine-password-solicitation-finalization-page.component';
import { RedefinePasswordChangePageComponent } from './pages/redefine-password-change-page/redefine-password-change-page.component';
import { RedefinePasswordChangeFinalizationPageComponent } from './pages/redefine-password-change-finalization-page/redefine-password-change-finalization-page.component';
import { AccountMyInfoPageComponent } from './pages/account-my-info-page/account-my-info-page.component';
import { AdRegisterDonationPageComponent } from './pages/ad-register-page/ad-register-donation-page.component';
import { AdRegisterSalePageComponent } from './pages/ad-register-page/ad-register-sale-page.component';
import { AccountMyAdPageComponent } from './pages/account-my-ad-page/account-my-ad-page.component';
import { AdPaymentPageComponent } from './pages/ad-payment-page/ad-payment-page.component';
import { AuthGuard } from './guard/auth.guard';
import { AdUpdateDonationPageComponent } from './pages/ad-update-page/ad-update-donation-page.component';
import { AdUpdateSalePageComponent } from './pages/ad-update-page/ad-update-sale-page.component';
import { AdTypeEnum } from './enum/ad-type.enum';
import { ContactPageComponent } from './pages/contact-page/contact-page.component';
import { ContactFinalizationPageComponent } from './pages/contact-finalization-page/contact-finalization-page.component';
import { AdListPageComponent } from './pages/ad-list-page/ad-list-page.component';
import { AdDetailPageComponent } from './pages/ad-detail-page/ad-detail-page.component';
import { PrivacyPageComponent } from './pages/privacy-page/privacy-page.component';
import { TermPageComponent } from './pages/term-page/term-page.component';
import { AccountRegisterPageComponent } from './pages/account-register-page/account-register-page.component';

export const ROUTES: Routes = [
  { path: 'conta', component: AccountPageComponent },
  { path: 'conta/criar', component: AccountRegisterPageComponent },
  { path: 'conta/sucesso', component: RegisterFinalizationPageComponent },
  { path: 'conta/confirmacao/:id', component: RegisterConfirmationPageComponent },
  { path: 'conta/redefinir-senha', component: RedefinePasswordSolicitationPageComponent },
  { path: 'conta/redefinir-senha/solicitada', component: RedefinePasswordSolicitationFinalizationPageComponent },
  { path: 'conta/redefinir-senha/sucesso', component: RedefinePasswordChangeFinalizationPageComponent },
  { path: 'conta/redefinir-senha/:key', component: RedefinePasswordChangePageComponent },
  { path: 'conta/meus-dados', component: AccountMyInfoPageComponent, canActivate: [AuthGuard] },
  { path: 'conta/meus-anuncios', component: AccountMyAdPageComponent, canActivate: [AuthGuard] },
  { path: 'conta/meus-anuncios/quero-doar/:id', component: AdUpdateDonationPageComponent, canActivate: [AuthGuard] },
  { path: 'conta/meus-anuncios/quero-vender/:id', component: AdUpdateSalePageComponent, canActivate: [AuthGuard] },
  { path: 'quero-doar', component: AdRegisterDonationPageComponent, canActivate: [AuthGuard] },
  { path: 'quero-vender', component: AdRegisterSalePageComponent, canActivate: [AuthGuard] },
  { path: 'quero-vender/pagamento/:id', component: AdPaymentPageComponent, canActivate: [AuthGuard] },
  { path: 'contato', component: ContactPageComponent },
  { path: 'contato/enviado', component: ContactFinalizationPageComponent },
  { path: 'politica-de-privacidade', component: PrivacyPageComponent },
  { path: 'termos-de-uso', component: TermPageComponent },
  { path: '**', redirectTo: '/conta' }
  

  // { path: 'doacao/:id/:url', component: AdDetailPageComponent, data : { noresetadcache:true } },
  // { path: 'venda/:id/:url', component: AdDetailPageComponent, data : { noresetadcache:true } },
  // { path: 'anuncios', component: AdListPageComponent, data : { noscroll : true, noresetadcache:true } },


]

