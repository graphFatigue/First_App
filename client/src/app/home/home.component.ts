import { Component, OnInit } from '@angular/core';
import { ListsCardsService } from '../_services/lists-cards.service';
import { ListCardsModel } from '../_models/listCards/listCardsModel';
import { CardModel } from '../_models/card/cardModel';
import { CardsService } from '../_services/cards.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit{
  listsCards : ListCardsModel[] = []
  cardsWithoutParent : CardModel[] = []

  constructor(private listsCardsService: ListsCardsService, private cardsService: CardsService){

  }

  ngOnInit(): void {
    this.loadLists();
    this.loadCardsWithoutParent();
  }
    
  loadLists(){
      this.listsCardsService.getListsCards().subscribe({
      next: listsCards => this.listsCards = listsCards
    })
  }

  loadCardsWithoutParent(){
    this.cardsService.getCardsWithoutParent().subscribe({
      next: cardsWithoutParent => this.cardsWithoutParent = cardsWithoutParent
    })
  }
}
