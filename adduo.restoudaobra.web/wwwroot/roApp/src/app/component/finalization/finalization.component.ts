import { Component, OnInit, Input } from '@angular/core';
import { TypeHelper } from '../../shared/type.helper';

@Component({
  selector: 'app-finalization',
  templateUrl: './finalization.component.html'
})
export class FinalizationComponent implements OnInit {

  @Input() title: string = TypeHelper.stringEmpty;
  @Input() subtitle: string[] = [];

  constructor() { }

  ngOnInit() {
  }

}
