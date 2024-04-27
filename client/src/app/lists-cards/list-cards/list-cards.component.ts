import { Component, Input, OnInit } from '@angular/core';
import { ListCardsModel } from 'src/app/_models/listCards/listCardsModel';

@Component({
  selector: 'app-list-cards',
  templateUrl: './list-cards.component.html',
  styleUrls: ['./list-cards.component.css']
})
export class ListCardsComponent implements OnInit {
  @Input() listCards: ListCardsModel | undefined;

  constructor(){

  }
  ngOnInit(): void {
    //this.loadCards();
  }

}
