import { Component, Inject, OnInit, ViewChild } from '@angular/core';
import { MatDialogRef } from '@angular/material/dialog';
import { UpdateCardModel } from 'src/app/_models/card/updateCardModel';
import { CardsService } from 'src/app/_services/cards.service';
import {MAT_DIALOG_DATA} from '@angular/material/dialog';
import { CardModel } from 'src/app/_models/card/cardModel';
import { ListsCardsService } from 'src/app/_services/lists-cards.service';
import { ListCardsModel } from 'src/app/_models/listCards/listCardsModel';
import { Observable } from 'rxjs';
import {Priority} from 'src/app/_models/priority/priority';
import { DatePipe } from '@angular/common';
import { NgForm } from '@angular/forms';
import { AppComponent } from 'src/app/app.component';
import { CreateCardModel } from 'src/app/_models/card/createCardModel';

@Component({
  selector: 'app-create-card-modal-window',
  templateUrl: './create-card-modal-window.component.html',
  styleUrls: ['./create-card-modal-window.component.css']
})
export class CreateCardModalWindowComponent implements OnInit{
  cardModel: CreateCardModel = {name: '', description: '', priority: '', listCardsName: '', boardId:0, dueDate: new Date().toISOString().substring(0, 10)}
  listsCards$? : Observable<ListCardsModel[]>
  errors: string[] = []
  priorities = Object.values(Priority);
  priorityStrings : string[]= []
  dateMin: string = new Date().toISOString().substring(0, 10);
  @ViewChild('createForm') createForm: NgForm | undefined

  constructor(
    private cardsService: CardsService, 
    private listsCardsService: ListsCardsService,
    public dialogRef: MatDialogRef<CreateCardModalWindowComponent>, 
    @Inject(MAT_DIALOG_DATA) public data: any){}

  ngOnInit(): void {
    this.loadLists()
    this.priorities.forEach(prioritiy => {this.priorityStrings.push(String(prioritiy))
    });
    this.cardModel.listCardsName=this.data.cardResponse;//.trim();
    this.cardModel.boardId = Number(this.data.boardResponse);
  }

  createCard(){
    this.cardsService.createCard(this.createForm?.value).subscribe(
      next => {
        this.closeModal();
        window.location.reload();
      },
      err =>{
        this.errors = [];
        let validationErrorDictionary = JSON.parse(JSON.stringify(err.error.errors));
        for (var fieldName in validationErrorDictionary) {
          if (validationErrorDictionary.hasOwnProperty(fieldName)) {
            this.errors.push(validationErrorDictionary[fieldName]);
          }
      }}
    )
  }

  loadLists(){
    this.listsCards$=this.listsCardsService.getListsCardsByBoardId(Number(this.data.boardResponse));
  }
    
  closeModal() {
    this.dialogRef.close();
  }
}
