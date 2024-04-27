import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ListCardsModel } from '../_models/listCards/listCardsModel';
import { environment } from 'src/environments/environment.development';

@Injectable({
  providedIn: 'root'
})
export class ListsCardsService {
  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) { }

  getListsCards(){
    return this.http.get<ListCardsModel[]>(this.baseUrl + 'listCards/all')
  }
}
