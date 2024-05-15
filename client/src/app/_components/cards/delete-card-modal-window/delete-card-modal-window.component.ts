import { Component, Inject } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { CardsService } from 'src/app/_services/cards.service';

@Component({
  selector: 'app-delete-card-modal-window',
  templateUrl: './delete-card-modal-window.component.html',
  styleUrls: ['./delete-card-modal-window.component.css'],
})
export class DeleteCardModalWindowComponent {
  constructor(
    public dialogRef: MatDialogRef<DeleteCardModalWindowComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any,
    private cardsService: CardsService,
  ) {}

  deleteCard() {
    this.cardsService.deleteCard(Number(this.data.cardResponse)).subscribe({
      next: (_) => {
        this.closeModal();
        window.location.reload();
      },
    });
  }

  closeModal() {
    this.dialogRef.close();
  }
}
