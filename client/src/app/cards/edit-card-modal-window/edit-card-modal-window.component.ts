import { Component, Inject, OnInit } from '@angular/core';
import { MatDialogRef } from '@angular/material/dialog';
import { UpdateCardModel } from 'src/app/_models/card/updateCardModel';
import { CardsService } from 'src/app/_services/cards.service';
import {MAT_DIALOG_DATA} from '@angular/material/dialog';
import { CardModel } from 'src/app/_models/card/cardModel';

@Component({
  selector: 'app-edit-card-modal-window',
  templateUrl: './edit-card-modal-window.component.html',
  styleUrls: ['./edit-card-modal-window.component.css']
})
export class EditCardModalWindowComponent implements OnInit{
  cardModel: CardModel = {id:0, name:'y', description:'y', dueDate:'y', priority:'h', listCardsName:'u'}

  constructor(
    private cardsService: CardsService, 
    public dialogRef: MatDialogRef<EditCardModalWindowComponent>, 
    @Inject(MAT_DIALOG_DATA) public data: any){

  }


  ngOnInit(): void {
    this.cardsService.getCard(Number(this.data.cardResponse)).subscribe({
      next: resp => this.cardModel = resp
    })
  }
    
  closeModal() {
    this.dialogRef.close();
  }

}
