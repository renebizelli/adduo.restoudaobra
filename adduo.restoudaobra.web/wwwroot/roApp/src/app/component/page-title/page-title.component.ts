import { Component, Input } from '@angular/core';
import { TypeHelper } from '../../shared/type.helper';

@Component({
  selector: 'app-page-title',
  templateUrl: './page-title.component.html'
})
export class PageTitleComponent {

  @Input() public title: string = TypeHelper.stringEmpty;
  @Input() public subtitleH2: string = TypeHelper.stringEmpty;
  @Input() public subtitleH3: string = TypeHelper.stringEmpty;

  constructor(private typeHelper: TypeHelper) { }

  public showH2() {
    return !this.typeHelper.isEmpty(this.subtitleH2)
  }

  public showH3() {
    return !this.typeHelper.isEmpty(this.subtitleH3)
  }
}
