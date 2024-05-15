import { ChangeDetectorRef, Component, Inject, OnInit, ViewChild } from '@angular/core';
import { MatDialogRef } from '@angular/material/dialog';
import { CardsService } from 'src/app/_services/cards.service';
import {MAT_DIALOG_DATA} from '@angular/material/dialog';
import { ListsCardsService } from 'src/app/_services/lists-cards.service';
import { ListCardsModel } from 'src/app/_models/listCards/listCardsModel';
import { Observable } from 'rxjs';
import { NgForm } from '@angular/forms';
import { UpdateListCardsModel } from 'src/app/_models/listCards/updateListCardsModel';
import { Store } from '@ngrx/store';

@Component({
  selector: 'app-edit-list-modal-window',
  templateUrl: './edit-list-modal-window.component.html',
  styleUrls: ['./edit-list-modal-window.component.css']
})
export class EditListModalWindowComponent implements OnInit{
  listCardsModel: UpdateListCardsModel = {id: 0, name:''};
  @ViewChild('editForm') editForm: NgForm | undefined;
  errors: string[] = [];

  constructor(
    private listsCardsService: ListsCardsService,
    public dialogRef: MatDialogRef<EditListModalWindowComponent>, 
    @Inject(MAT_DIALOG_DATA) public data: any,private changeDetectorRef: ChangeDetectorRef,
    private store: Store<{list:{list: ListCardsModel}}>){}

  ngOnInit(): void {
      this.loadListCards();
  }

  loadListCards(){
    this.store.select('list').subscribe(data=> this.listCardsModel = data.list);
    this.changeDetectorRef.detectChanges();
  }

  updateListCards(){
    this.listsCardsService.updateListCards(this.editForm?.value).subscribe( next => {
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
