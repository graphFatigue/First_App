import { Component, Inject, OnInit, ViewChild } from '@angular/core';
import { MatDialogRef } from '@angular/material/dialog';
import {MAT_DIALOG_DATA} from '@angular/material/dialog';
import { NgForm } from '@angular/forms';
import { CreateListCardsModel } from 'src/app/_models/listCards/createListCardsModel';
import { CreateBoardModel } from 'src/app/_models/board/createBoardModel';
import { BoardsService } from 'src/app/_services/boards.service';

@Component({
  selector: 'app-create-board-modal-window',
  templateUrl: './create-board-modal-window.component.html',
  styleUrls: ['./create-board-modal-window.component.css']
})
export class CreateBoardModalWindowComponent{
  boardModel: CreateBoardModel = {name: ''};
  @ViewChild('createForm') createForm: NgForm | undefined;
  errors: string[] = [];

  constructor(
    private boardsService: BoardsService,
    public dialogRef: MatDialogRef<CreateBoardModalWindowComponent>, 
    @Inject(MAT_DIALOG_DATA) public data: any){}

  createBoard(){
      this.boardsService.createBoard(this.createForm?.value).subscribe(
        next => {
          this.closeModal();
          window.location.reload();
      },
        err =>{
          this.errors = [];
          console.log(err.error);
          try{
            let validationErrorDictionary = JSON.parse(JSON.stringify(err.error.errors));
            for (var fieldName in validationErrorDictionary) {
              if (validationErrorDictionary.hasOwnProperty(fieldName)) {
                this.errors.push(validationErrorDictionary[fieldName]);
              }
          }
          }
          catch{
            let validationErrorDictionary = JSON.parse(JSON.stringify(err.error));
            for (var fieldName in validationErrorDictionary) {
              if (validationErrorDictionary.hasOwnProperty(fieldName)) {
                this.errors.push(validationErrorDictionary[fieldName]);
              }
          }
          }
      })
  }
    
  closeModal() {
    this.dialogRef.close();
  }
}
