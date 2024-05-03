import { Component, OnInit } from '@angular/core';
import { ListsCardsService } from '../../_services/lists-cards.service';
import { ListCardsModel } from '../../_models/listCards/listCardsModel';
import { CardModel } from '../../_models/card/cardModel';
import { CardsService } from '../../_services/cards.service';
import { MatDialog, MatDialogConfig, MatDialogRef } from '@angular/material/dialog';
import { CreateListCardsModalWindowComponent } from '../lists-cards/create-list-modal-window/create-list-modal-window.component';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit{
  listsCards : ListCardsModel[] = []
  cardsWithoutParent : CardModel[] = []
  dialogConfig = new MatDialogConfig();
  modalDialog: MatDialogRef<CreateListCardsModalWindowComponent, any> | undefined;

  constructor(private listsCardsService: ListsCardsService, private cardsService: CardsService, public matDialog: MatDialog){

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

  openCreateForm(){
    this.dialogConfig.id = "projects-modal-component";
    this.modalDialog = this.matDialog.open(CreateListCardsModalWindowComponent, {
      width: '500px',
      // height: '550px',
    });
  }
}
