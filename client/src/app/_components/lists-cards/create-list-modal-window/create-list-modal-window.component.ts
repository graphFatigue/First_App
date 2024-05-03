import { Component, Inject, OnInit, ViewChild } from '@angular/core';
import { MatDialogRef } from '@angular/material/dialog';
import { UpdateCardModel } from 'src/app/_models/card/updateCardModel';
import { CardsService } from 'src/app/_services/cards.service';
import {MAT_DIALOG_DATA} from '@angular/material/dialog';
import { ListsCardsService } from 'src/app/_services/lists-cards.service';
import { DatePipe } from '@angular/common';
import { NgForm } from '@angular/forms';
import { CreateListCardsModel } from 'src/app/_models/listCards/createListCardsModel';

@Component({
  selector: 'app-create-card-modal-window',
  templateUrl: './create-list-modal-window.component.html',
  styleUrls: ['./create-list-modal-window.component.css']
})
export class CreateListCardsModalWindowComponent implements OnInit{
  listCardsModel: CreateListCardsModel = {name: ''}
  @ViewChild('createForm') createForm: NgForm | undefined

  constructor(
    private listsCardsService: ListsCardsService,
    public dialogRef: MatDialogRef<CreateListCardsModalWindowComponent>, 
    @Inject(MAT_DIALOG_DATA) public data: any){}

  ngOnInit(): void {
    
  }

  stringToDate(dateString: string): DatePipe {
    return new DatePipe(dateString);
  }

  createListCards(){
    this.listsCardsService.createListCards(this.createForm?.value).subscribe({
      next: _ => {
        this.createForm?.reset(this.listCardsModel);
        this.closeModal();
        window.location.reload();
      }
    })
  }
    
  closeModal() {
    this.dialogRef.close();
  }
}
