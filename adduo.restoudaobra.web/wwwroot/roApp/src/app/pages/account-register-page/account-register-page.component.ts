import { Component, OnInit } from '@angular/core';
import { ContactService } from '../../service/contact.service';
import { DataTransferService } from '../../service/data-transfer.service';
import { Router } from '../../../../node_modules/@angular/router';
import { Title } from '../../../../node_modules/@angular/platform-browser';
import { BaseComponent } from '../../base.component';

@Component({
  selector: 'app-account-register-page',
  templateUrl: './account-register-page.component.html'
})
export class AccountRegisterPageComponent extends BaseComponent implements OnInit {

 constructor(
    public contactService: ContactService, 
    public dataTransferService: DataTransferService,
    public router: Router, 
    public title: Title) {
    super(dataTransferService, router, title);
  }


  ngOnInit() {
    this.setTitle('Criar minha conta')
  }

}
