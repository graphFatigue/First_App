import { Component, Inject } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { BoardsService } from 'src/app/_services/boards.service';
import { CardsService } from 'src/app/_services/cards.service';
import { ListsCardsService } from 'src/app/_services/lists-cards.service';

@Component({
  selector: 'app-delete-board-modal-window',
  templateUrl: './delete-board-modal-window.component.html',
  styleUrls: ['./delete-board-modal-window.component.css']
})
export class DeleteBoardModalWindowComponent {

  constructor(public dialogRef: MatDialogRef<DeleteBoardModalWindowComponent>, 
    @Inject(MAT_DIALOG_DATA) public data: any, private boardsService: BoardsService){

    }

    deleteBoard(){
      this.boardsService.deleteBoard(Number(this.data.boardResponse)).subscribe({
        next: _ => {
        this.closeModal();
        window.location.reload();
      }
      })
    }

    closeModal() {
      this.dialogRef.close();
    }
}
