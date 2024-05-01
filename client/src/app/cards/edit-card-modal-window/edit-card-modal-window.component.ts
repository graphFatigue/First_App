import { Component, Inject, OnInit } from '@angular/core';
import { MatDialogRef } from '@angular/material/dialog';
import { UpdateCardModel } from 'src/app/_models/card/updateCardModel';
import { CardsService } from 'src/app/_services/cards.service';
import {MAT_DIALOG_DATA} from '@angular/material/dialog';
import { CardModel } from 'src/app/_models/card/cardModel';
import { ListsCardsService } from 'src/app/_services/lists-cards.service';
import { ListCardsModel } from 'src/app/_models/listCards/listCardsModel';
import { Observable } from 'rxjs';
import {Priority} from 'src/app/_models/priority/priority';

@Component({
  selector: 'app-edit-card-modal-window',
  templateUrl: './edit-card-modal-window.component.html',
  styleUrls: ['./edit-card-modal-window.component.css']
})
export class EditCardModalWindowComponent implements OnInit{
  cardModel: CardModel = {id: 0, name: '', description: '', priority: '', listCardsName: '', dueDate: ''}
  listsCards$? : Observable<ListCardsModel[]>
  priorities = Object.values(Priority);
  priorityStrings : string[]= []

  constructor(
    private cardsService: CardsService, 
    private listsCardsService: ListsCardsService,
    public dialogRef: MatDialogRef<EditCardModalWindowComponent>, 
    @Inject(MAT_DIALOG_DATA) public data: any){}

  ngOnInit(): void {
    this.loadCard()
    this.loadLists()
    this.priorities.forEach(prioritiy => {this.priorityStrings.push(String(prioritiy))
    });
  }

  loadCard(){
    this.cardsService.getCard(Number(this.data.cardResponse)).subscribe({
      next: resp => this.cardModel = resp
    })
  }

  loadLists(){
    this.listsCards$=this.listsCardsService.getListsCards();
  }
    
  closeModal() {
    this.dialogRef.close();
  }
}
