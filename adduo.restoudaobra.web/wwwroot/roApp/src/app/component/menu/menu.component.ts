﻿import { Component, OnInit, Input } from '@angular/core';
import { AuthService } from '../../service/auth.service';
import { BaseComponent } from '../../base.component';
import { DataTransferService } from '../../service/data-transfer.service';
import { Router } from '@angular/router';
import { Title } from '../../../../node_modules/@angular/platform-browser';

@Component({
  selector: 'app-menu',
  templateUrl: './menu.component.html'
})
export class MenuComponent extends BaseComponent implements OnInit {

  public isAuth: boolean = false;
  public isOpen : boolean = false;

  public name: string = '';

  constructor(
    private authService: AuthService,
    public dataTransferService: DataTransferService,
    public router: Router, 
    public title: Title) {
    super(dataTransferService, router, title);
    
        this.router.events.subscribe((val) => {
          this.isOpen = false;
        });

  }

  ngOnInit() {
  

    this.authService.currentState.subscribe(auth => {

      this.isAuth = false;
      if (auth) {
        this.name = auth.name;
        this.isAuth = true;
      }

    });
  }

  public logout(): void {
    this.authService.logout().subscribe(() => this.redirect('conta'));
  }
  
  public toogle() : void {
    this.isOpen = !this.isOpen;
  }
  
}
