import { ChangeDetectorRef, Component, Inject, OnInit, ViewChild } from '@angular/core';
import { MatDialogRef } from '@angular/material/dialog';
import { CardsService } from 'src/app/_services/cards.service';
import {MAT_DIALOG_DATA} from '@angular/material/dialog';
import { ListsCardsService } from 'src/app/_services/lists-cards.service';
import { ListCardsModel } from 'src/app/_models/listCards/listCardsModel';
import { Observable } from 'rxjs';
import { NgForm } from '@angular/forms';
import { UpdateListCardsModel } from 'src/app/_models/listCards/updateListCardsModel';

@Component({
  selector: 'app-edit-list-modal-window',
  templateUrl: './edit-list-modal-window.component.html',
  styleUrls: ['./edit-list-modal-window.component.css']
})
export class EditListModalWindowComponent implements OnInit{
  listCardsModel: UpdateListCardsModel = {id: 0, name:''}
  @ViewChild('editForm') editForm: NgForm | undefined

  constructor(
    private listsCardsService: ListsCardsService,
    public dialogRef: MatDialogRef<EditListModalWindowComponent>, 
    @Inject(MAT_DIALOG_DATA) public data: any,private changeDetectorRef: ChangeDetectorRef){}

  ngOnInit(): void {
      this.loadListCards();
  }

  loadListCards(){
    this.listsCardsService.getListCards(Number(this.data.listResponse)).subscribe({
      next: resp => this.listCardsModel = resp
    })
    this.changeDetectorRef.detectChanges();
  }

  updateListCards(){
    this.listsCardsService.updateListCards(this.editForm?.value).subscribe({
      next: _ => {
        this.editForm?.reset(this.listCardsModel);
        this.closeModal();
        window.location.reload();
      }
    })
  }
    
  closeModal() {
    this.dialogRef.close();
  }
}
