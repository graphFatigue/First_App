import { Component, Input, OnInit } from '@angular/core';
import { MatDialog, MatDialogConfig, MatDialogRef } from '@angular/material/dialog';
import { ListCardsModel } from 'src/app/_models/listCards/listCardsModel';
import { CreateCardModalWindowComponent } from 'src/app/_components/cards/create-card-modal-window/create-card-modal-window.component';

@Component({
  selector: 'app-list-cards',
  templateUrl: './list-cards.component.html',
  styleUrls: ['./list-cards.component.css']
})
export class ListCardsComponent {
  @Input() listCards: ListCardsModel | undefined;
  dialogConfig = new MatDialogConfig();
  modalDialog: MatDialogRef<CreateCardModalWindowComponent, any> | undefined;

  constructor(public matDialog: MatDialog){}

  openCreateForm(){
    this.dialogConfig.id = "projects-modal-component";
    this.modalDialog = this.matDialog.open(CreateCardModalWindowComponent, {
      // width: '500px',
      // height: '550px',
      data: {
        cardResponse: this.listCards?.name,
        boardResponse: this.listCards?.boardId
      }
    });
  }
}
