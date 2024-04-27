import { Component, OnInit } from '@angular/core';
import { CardModel } from 'src/app/_models/card/cardModel';
import { CardsService } from 'src/app/_services/cards.service';

@Component({
  selector: 'app-list-cards',
  templateUrl: './list-cards.component.html',
  styleUrls: ['./list-cards.component.css']
})
export class ListCardsComponent implements OnInit {
  cards: CardModel[] = [];

  constructor(private cardsService: CardsService){

  }
  ngOnInit(): void {
    this.loadCards();
  }

  loadCards(){
    this.cardsService.getCards().subscribe({
      next: cards => this.cards = cards
    })
  }

}
