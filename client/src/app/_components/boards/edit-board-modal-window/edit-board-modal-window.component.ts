import { ChangeDetectorRef, Component, Inject, OnInit, ViewChild } from '@angular/core';
import { MatDialogRef } from '@angular/material/dialog';
import {MAT_DIALOG_DATA} from '@angular/material/dialog';
import { NgForm } from '@angular/forms';
import { BoardsService } from 'src/app/_services/boards.service';
import { UpdateBoardModel } from 'src/app/_models/board/updateBoardModel';

@Component({
  selector: 'app-edit-board-modal-window',
  templateUrl: './edit-board-modal-window.component.html',
  styleUrls: ['./edit-board-modal-window.component.css']
})
export class EditBoardModalWindowComponent implements OnInit{
  boardModel: UpdateBoardModel = {id: 0, name:''};
  @ViewChild('editForm') editForm: NgForm | undefined;
  errors: string[] = [];

  constructor(
    private boardsService: BoardsService,
    public dialogRef: MatDialogRef<EditBoardModalWindowComponent>, 
    @Inject(MAT_DIALOG_DATA) public data: any,private changeDetectorRef: ChangeDetectorRef){}

  ngOnInit(): void {
      this.loadBoard();
  }

  loadBoard(){
    this.boardsService.getBoard(this.data.boardResponse).subscribe({
      next: resp => this.boardModel = resp
    })
    this.changeDetectorRef.detectChanges();
  }

  updateBoard(){
    this.boardsService.updateBoard(this.editForm?.value).subscribe( next => {
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
