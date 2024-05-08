import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment.development';
import { CardModel } from '../_models/card/cardModel';
import { UpdateCardModel } from '../_models/card/updateCardModel';
import { CreateCardModel } from '../_models/card/createCardModel';


@Injectable({
  providedIn: 'root'
})
export class CardsService {
  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) { }

  getCards(){
    return this.http.get<CardModel[]>(this.baseUrl + 'cards/all')
  }

  getCard(id: number){
    return this.http.get<CardModel>(this.baseUrl + 'cards/' + id)
  }

  deleteCard(id: number){
    return this.http.delete<CardModel>(this.baseUrl + 'cards/' + id)
  }

  updateCard(updateCardModel: UpdateCardModel){
    return this.http.put<CardModel>(this.baseUrl + 'cards', updateCardModel)
  }

  createCard(createCardModel: CreateCardModel){
    return this.http.post<CardModel>(this.baseUrl + 'cards', createCardModel)
  }

  getCardsWithoutParent(){
    return this.http.get<CardModel[]>(this.baseUrl + 'cards/allWithoutParentList')
  }
}
