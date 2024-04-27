import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment.development';
import { CardModel } from '../_models/card/cardModel';

@Injectable({
  providedIn: 'root'
})
export class CardsService {
  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) { }

  getCards(){
    return this.http.get<CardModel[]>(this.baseUrl + 'cards/all')
  }
}
