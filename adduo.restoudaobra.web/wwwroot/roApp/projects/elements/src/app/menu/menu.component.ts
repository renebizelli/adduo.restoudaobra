import { Component, OnInit, Input, ViewEncapsulation } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '../../../../../src/app/service/auth.service';

@Component({
  selector: 'app-menu',
  templateUrl: './menu.component.html',
  encapsulation : ViewEncapsulation.Native,
  styleUrls : ['../../assets/menu.css']
})
export class MenuComponent  implements OnInit {

   public isAuth: boolean = false;
   public isOpen: boolean = true;

  public name: string = '';
  
  constructor(
    private authService: AuthService,
  public router: Router) {}
  
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
    this.authService.logout().subscribe(() => this.router.navigate(['/']));
  }
  
  public toggle() : void {
  
    console.log('toogle', this.isOpen)
    this.name += ' x'
  
    this.isOpen = !this.isOpen;
  }
  
  
}
