import { Component, Input, OnInit } from '@angular/core';
import { MatDialog, MatDialogConfig, MatDialogRef } from '@angular/material/dialog';
import { CardModel } from 'src/app/_models/card/cardModel';
import { EditCardModalWindowComponent } from '../edit-card-modal-window/edit-card-modal-window.component';
import { CardsService } from 'src/app/_services/cards.service';
import { UpdateCardModel } from 'src/app/_models/card/updateCardModel';

@Component({
  selector: 'app-card',
  templateUrl: './card.component.html',
  styleUrls: ['./card.component.css']
})
export class CardComponent{
  @Input() card: CardModel | undefined;
 
}
