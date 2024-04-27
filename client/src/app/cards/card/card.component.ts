import { Component, Input } from '@angular/core';
import { CardModel } from 'src/app/_models/card/cardModel';

@Component({
  selector: 'app-card',
  templateUrl: './card.component.html',
  styleUrls: ['./card.component.css']
})
export class CardComponent {
  @Input() card: CardModel | undefined;

}
