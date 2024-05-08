import { Component, Inject } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { CardsService } from 'src/app/_services/cards.service';
import { ListsCardsService } from 'src/app/_services/lists-cards.service';

@Component({
  selector: 'app-delete-list-modal-window',
  templateUrl: './delete-list-modal-window.component.html',
  styleUrls: ['./delete-list-modal-window.component.css']
})
export class DeleteListModalWindowComponent {

  constructor(public dialogRef: MatDialogRef<DeleteListModalWindowComponent>, 
    @Inject(MAT_DIALOG_DATA) public data: any, private listCardsService: ListsCardsService){

    }

    deleteCard(){
      this.listCardsService.deleteListCards(Number(this.data.listResponse)).subscribe({
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
