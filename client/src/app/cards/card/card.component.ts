import { Component, Input } from '@angular/core';
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
export class CardComponent {
  dialogConfig = new MatDialogConfig();
  modalDialog: MatDialogRef<EditCardModalWindowComponent, any> | undefined;
  @Input() card: CardModel | undefined;

  constructor(public matDialog: MatDialog){}

  showContextMenu(){}
  
  openEditForm(){
    this.dialogConfig.id = "projects-modal-component";
    this.dialogConfig.height = "500px";
    this.dialogConfig.width = "650px";
    if (this.card!==undefined){
    this.modalDialog = this.matDialog.open(EditCardModalWindowComponent, {
      width: '330px',
      height: '400px',
      data: {
        cardResponse: this.card
      }
    });
    }
  }
}
