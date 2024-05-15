import { Component, OnInit } from '@angular/core';
import { ListCardsModel } from '../../_models/listCards/listCardsModel';
import { CardModel } from '../../_models/card/cardModel';
import { Observable } from 'rxjs';
import { MatDialogConfig, MatDialogRef } from '@angular/material/dialog';
import { CreateListCardsModalWindowComponent } from '../lists-cards/create-list-modal-window/create-list-modal-window.component';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css'],
})
export class HomeComponent implements OnInit {
  cardsWithoutParent$?: Observable<CardModel[]>;
  listsCards$?: Observable<ListCardsModel[]>;
  dialogConfig = new MatDialogConfig();
  modalDialog:
    | MatDialogRef<CreateListCardsModalWindowComponent, any>
    | undefined;

  constructor() {}

  ngOnInit(): void {}
}
