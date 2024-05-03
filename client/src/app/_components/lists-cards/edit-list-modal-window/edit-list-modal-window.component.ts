import { Component, Inject, OnInit, ViewChild } from '@angular/core';
import { MatDialogRef } from '@angular/material/dialog';
import { CardsService } from 'src/app/_services/cards.service';
import {MAT_DIALOG_DATA} from '@angular/material/dialog';
import { ListsCardsService } from 'src/app/_services/lists-cards.service';
import { ListCardsModel } from 'src/app/_models/listCards/listCardsModel';
import { Observable } from 'rxjs';
import {Priority} from 'src/app/_models/priority/priority';
import { DatePipe } from '@angular/common';
import { NgForm } from '@angular/forms';
import { UpdateCardModel } from 'src/app/_models/card/updateCardModel';
import { UpdateListCardsModel } from 'src/app/_models/listCards/updateListCardsModel';

@Component({
  selector: 'app-edit-list-modal-window',
  templateUrl: './edit-list-modal-window.component.html',
  styleUrls: ['./edit-list-modal-window.component.css']
})
export class EditListModalWindowComponent implements OnInit{
  listCardsModel: UpdateListCardsModel = {id: 0, name: ''}
  listsCards$? : Observable<ListCardsModel[]>
  @ViewChild('editForm') editForm: NgForm | undefined

  constructor(
    private listsCardsService: ListsCardsService,
    public dialogRef: MatDialogRef<EditListModalWindowComponent>, 
    @Inject(MAT_DIALOG_DATA) public data: any){}

  ngOnInit(): void {
    this.loadListCards()
  }

  loadListCards(){
    this.listsCardsService.getListCards(Number(this.data.listResponse)).subscribe({
      next: resp => this.listCardsModel = resp
    })
  }

  updateListCards(){
    this.listsCardsService.updateListCards(this.editForm?.value).subscribe({
      next: _ => {
        this.editForm?.reset(this.listCardsModel);
        this.closeModal();
        window.location.reload();
      }
    })
  }
    
  closeModal() {
    this.dialogRef.close();
  }
}
