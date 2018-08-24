import { Component, OnInit, Input, AfterContentInit, AfterViewInit, OnChanges, SimpleChanges } from '@angular/core';
import { BaseComponent } from '../../base.component';
import { DataTransferService } from '../../service/data-transfer.service';
import { Router } from '@angular/router';

import { AdService } from '../../service/ad.service';
import { catchError, map, finalize } from 'rxjs/operators';
import { throwError, Observable } from 'rxjs';
import { ResponseEnvelope } from '../../envelope/response.envelope';

import { AdImageRegisterModel } from '../../model/ad-image-register.model';
import { forEach } from '@angular/router/src/utils/collection';
import { AdImageService } from '../../service/ad-image.service';
import { PropertyListModel } from '../../shared/propertylist.model';
import { CardRegisterModel } from '../../model/card-register.model';
import { StatusPropertyEnum } from '../../enum/status-property.enum';
import { AdRegisterInitialModel } from '../../model/ad-register-initial.model';

@Component({
  selector: 'app-ad-images-register',
  templateUrl: './ad-images-register.component.html'
})
export class AdImagesRegisterComponent extends BaseComponent
  implements OnInit, OnChanges {

  ngOnChanges(changes: SimpleChanges): void {
    this.uploaded = this.images.list;
  }

  @Input() public images: PropertyListModel<AdImageRegisterModel> = new PropertyListModel<AdImageRegisterModel>();
  @Input() public initial: AdRegisterInitialModel = AdRegisterInitialModel._new();

  public uploaded: AdImageRegisterModel[] = [];
  public files: File[] = []
  private limit: number = 6;
  private deleteLoader: boolean[] = [];
  public loader: boolean = false;

  public maxSize: number = 2048000;
  public validComboDrag: any;

  public invalidClear: boolean = false;

  constructor(
    private adImageService: AdImageService,
    public dataTransferService: DataTransferService,
    public router: Router) {
    super(dataTransferService, router);
  }

  ngOnInit() {
  }

  public isInvalid(): boolean {
    return this.images.status == StatusPropertyEnum.invalid && !this.invalidClear;
  }

  public limitOk(): boolean {
    return this.uploaded.length == this.limit;
  }


  public upload(): void {

    this.loader = true;

    let missing = this.limit - this.uploaded.length;
    let smaller = missing < this.files.length ? missing : this.files.length;

    let formData = new FormData();
    formData.append('guid', this.initial.guid);

    for (let index = 0; index < smaller; index++) {
      let file = this.files[index];
      formData.append('image', file, file.name);
      formData.append(file.name, index.toString());
    }

    this.adImageService.upload(formData)
      .pipe(
        map(m => m.body as ResponseEnvelope<AdImageRegisterModel>),
        finalize(() => {
          this.loader = false;
        }),
        catchError(e => {
          super.processHttpErrorResponse(e)
          this.loader = false;
          return throwError(e);
        })
      )
      .subscribe(response => {
        if (response) {

          for (let i in response.dtos) {
            this.uploaded.push(response.dtos[i]);
          }

          this.files = [];
          this.invalidClear = true;
        }
      });
  }

  public showLoaderDelete(id: number): boolean {
    return this.deleteLoader[id];
  }

  public delete(image: AdImageRegisterModel): void {
    this.deleteLoader[image.id] = true;
    this.adImageService.delete(image.id)
      .pipe(
        catchError(e => {
          super.processHttpErrorResponse(e)
          return throwError(e);
        }),
        finalize(() => { this.deleteLoader[image.id] = false; })
      )
      .subscribe(response => {
        var i = this.uploaded.findIndex((f) => f.id == image.id);
        this.uploaded.splice(i, 1);
      });
  }

}
