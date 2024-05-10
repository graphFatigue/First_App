import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ListCardsModel } from '../_models/listCards/listCardsModel';
import { environment } from 'src/environments/environment.development';
import { CreateListCardsModel } from '../_models/listCards/createListCardsModel';

@Injectable({
  providedIn: 'root'
})
export class ListsCardsService {
  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) { }

  getListsCards(){
    return this.http.get<ListCardsModel[]>(this.baseUrl + 'listCards/all')
  }

  getListsCardsByBoardId(id: number){
    return this.http.get<ListCardsModel[]>(this.baseUrl + 'listCards/allBy/' + id)
  }

  getListCards(id: number){
    return this.http.get<ListCardsModel>(this.baseUrl + 'listCards/' + id)
  }

  deleteListCards(id: number){
    return this.http.delete<ListCardsModel>(this.baseUrl + 'listCards/' + id)
  }

  updateListCards(updateListCardsModel: ListCardsModel){
    return this.http.put<ListCardsModel>(this.baseUrl + 'listCards', updateListCardsModel)
  }

  createListCards(createListCardsModel: CreateListCardsModel){
    return this.http.post<CreateListCardsModel>(this.baseUrl + 'listCards', createListCardsModel)
  }

}
