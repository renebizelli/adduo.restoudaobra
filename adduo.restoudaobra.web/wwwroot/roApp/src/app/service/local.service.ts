import { Injectable } from '@angular/core';

import { HttpService } from './http.service'
import { Observable } from 'rxjs';
import { ItemModel } from '../model/item.model';


@Injectable({
  providedIn: 'root'
})
export class LocalService {

  constructor(private http: HttpService) { }

  static states(): ItemModel[] {

    return [
      new ItemModel(1, 'Acre'),
      new ItemModel(2, 'Alagoas'),
      new ItemModel(3, 'Amapá'),
      new ItemModel(4, 'Amazonas'),
      new ItemModel(5, 'Bahia'),
      new ItemModel(6, 'Ceará'),
      new ItemModel(7, 'Distrito Federal'),
      new ItemModel(8, 'Espírito Santo'),
      new ItemModel(9, 'Goiás'),
      new ItemModel(10, 'Maranhão'),
      new ItemModel(11, 'Mato Grosso'),
      new ItemModel(12, 'Mato Grosso do Sul'),
      new ItemModel(13, 'Minas Gerais'),
      new ItemModel(14, 'Pará'),
      new ItemModel(15, 'Paraíba'),
      new ItemModel(16, 'Paraná'),
      new ItemModel(17, 'Pernambuco'),
      new ItemModel(18, 'Piauí'),
      new ItemModel(19, 'Rio de Janeiro'),
      new ItemModel(20, 'Rio Grande do Norte'),
      new ItemModel(21, 'Rio Grande do Sul'),
      new ItemModel(22, 'Rondônia'),
      new ItemModel(23, 'Roraima'),
      new ItemModel(24, 'Santa Catarina'),
      new ItemModel(25, 'São Paulo'),
      new ItemModel(26, 'Sergipe'),
      new ItemModel(27, 'Tocantins')
    ];
  }


}
