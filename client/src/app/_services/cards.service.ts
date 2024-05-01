import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment.development';
import { CardModel } from '../_models/card/cardModel';
import { UpdateCardModel } from '../_models/card/updateCardModel';


@Injectable({
  providedIn: 'root'
})
export class CardsService {
  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) { }

  getCards(){
    console.log('works');
    return this.http.get<CardModel[]>(this.baseUrl + 'cards/all')
  }

  getCard(id: number){
    return this.http.get<CardModel>(this.baseUrl + 'cards/' + id)
  }

  updateCard(updateCardModel: CardModel){
    return this.http.put<CardModel>(this.baseUrl + 'cards', updateCardModel)
  }

  getCardsWithoutParent(){
    console.log('works');
    return this.http.get<CardModel[]>(this.baseUrl + 'cards/allWithoutParentList')
  }
}
