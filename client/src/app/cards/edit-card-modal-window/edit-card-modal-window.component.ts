import { Component, Inject, OnInit } from '@angular/core';
import { MatDialogRef } from '@angular/material/dialog';
import { UpdateCardModel } from 'src/app/_models/card/updateCardModel';
import { CardsService } from 'src/app/_services/cards.service';
import {MAT_DIALOG_DATA} from '@angular/material/dialog';

@Component({
  selector: 'app-edit-card-modal-window',
  templateUrl: './edit-card-modal-window.component.html',
  styleUrls: ['./edit-card-modal-window.component.css']
})
export class EditCardModalWindowComponent implements OnInit{
  updateCardModel: UpdateCardModel | undefined

  constructor(private cardService: CardsService, 
    public dialogRef: MatDialogRef<EditCardModalWindowComponent>, 
    @Inject(MAT_DIALOG_DATA) public data: any){

  }

  ngOnInit(): void {
    this.updateCardModel = this.data.cardResponse
    console.log(this.data.cardResponse.name)
  }

  closeModal() {
    this.dialogRef.close();
  }

}
