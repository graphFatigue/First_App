import { Component, Input, OnInit } from '@angular/core';
import { ListCardsModel } from 'src/app/_models/listCards/listCardsModel';
import { CardsService } from 'src/app/_services/cards.service';

@Component({
  selector: 'app-list-cards',
  templateUrl: './list-cards.component.html',
  styleUrls: ['./list-cards.component.css']
})
export class ListCardsComponent {
  @Input() listCards: ListCardsModel | undefined;

}
