import { Component, OnInit } from '@angular/core';
import { ListsCardsService } from '../../_services/lists-cards.service';
import { ListCardsModel } from '../../_models/listCards/listCardsModel';
import { CardModel } from '../../_models/card/cardModel';
import { CardsService } from '../../_services/cards.service';
import { Observable } from 'rxjs';
import { MatDialog, MatDialogConfig, MatDialogRef } from '@angular/material/dialog';
import { CreateListCardsModalWindowComponent } from '../lists-cards/create-list-modal-window/create-list-modal-window.component';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit{
  cardsWithoutParent$? : Observable<CardModel[]>
  listsCards$? : Observable<ListCardsModel[]>
  dialogConfig = new MatDialogConfig();
  modalDialog: MatDialogRef<CreateListCardsModalWindowComponent, any> | undefined;

  constructor(private listsCardsService: ListsCardsService, private cardsService: CardsService, public matDialog: MatDialog){}

  ngOnInit(): void {
    this.loadLists();
    this.loadCardsWithoutParent();
  }
    
  loadLists(){
    this.listsCards$ = this.listsCardsService.getListsCards()
  }

  loadCardsWithoutParent(){
    this.cardsWithoutParent$ = this.cardsService.getCardsWithoutParent();
  }

  openCreateForm(){
    this.dialogConfig.id = "projects-modal-component";
    this.modalDialog = this.matDialog.open(CreateListCardsModalWindowComponent, {
      width: '500px',
      // height: '550px',
    });
  }
}
