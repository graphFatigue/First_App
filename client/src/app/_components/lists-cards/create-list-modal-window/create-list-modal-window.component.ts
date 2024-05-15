import { Component, Inject, OnInit, ViewChild } from '@angular/core';
import { MatDialogRef } from '@angular/material/dialog';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';
import { ListsCardsService } from 'src/app/_services/lists-cards.service';
import { NgForm } from '@angular/forms';
import { CreateListCardsModel } from 'src/app/_models/listCards/createListCardsModel';

@Component({
  selector: 'app-create-list-modal-window',
  templateUrl: './create-list-modal-window.component.html',
  styleUrls: ['./create-list-modal-window.component.css'],
})
export class CreateListCardsModalWindowComponent implements OnInit {
  listCardsModel: CreateListCardsModel = { name: '', boardId: 0 };
  @ViewChild('createForm') createForm: NgForm | undefined;
  errors: string[] = [];

  constructor(
    private listsCardsService: ListsCardsService,
    public dialogRef: MatDialogRef<CreateListCardsModalWindowComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any,
  ) {}

  ngOnInit(): void {
    this.listCardsModel.boardId = Number(this.data.boardResponse);
  }

  createListCards() {
    this.listsCardsService.createListCards(this.createForm?.value).subscribe(
      (next) => {
        this.closeModal();
        window.location.reload();
      },
      (err) => {
        this.errors = [];
        console.log(err.error);
        try {
          let validationErrorDictionary = JSON.parse(
            JSON.stringify(err.error.errors),
          );
          for (var fieldName in validationErrorDictionary) {
            if (validationErrorDictionary.hasOwnProperty(fieldName)) {
              this.errors.push(validationErrorDictionary[fieldName]);
            }
          }
        } catch {
          let validationErrorDictionary = JSON.parse(JSON.stringify(err.error));
          for (var fieldName in validationErrorDictionary) {
            if (validationErrorDictionary.hasOwnProperty(fieldName)) {
              this.errors.push(validationErrorDictionary[fieldName]);
            }
          }
        }
      },
    );
  }

  closeModal() {
    this.dialogRef.close();
  }
}
