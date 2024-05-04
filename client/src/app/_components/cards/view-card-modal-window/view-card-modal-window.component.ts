import { Component, Inject, OnInit, ViewChild } from '@angular/core';
import { MatDialog, MatDialogConfig, MatDialogRef } from '@angular/material/dialog';
import { CardsService } from 'src/app/_services/cards.service';
import {MAT_DIALOG_DATA} from '@angular/material/dialog';
import { CardModel } from 'src/app/_models/card/cardModel';
import { ListsCardsService } from 'src/app/_services/lists-cards.service';
import { ListCardsModel } from 'src/app/_models/listCards/listCardsModel';
import { Observable, map } from 'rxjs';
import {Priority} from 'src/app/_models/priority/priority';
import { DatePipe } from '@angular/common';
import { NgForm } from '@angular/forms';
import { UpdateCardModel } from 'src/app/_models/card/updateCardModel';
import { EditCardModalWindowComponent } from '../edit-card-modal-window/edit-card-modal-window.component';
import { ActionsService } from 'src/app/_services/actions.service';
import { ActionModel } from 'src/app/_models/action/actionModel';

@Component({
  selector: 'app-view-card-modal-window',
  templateUrl: './view-card-modal-window.component.html',
  styleUrls: ['./view-card-modal-window.component.css']
})
export class ViewCardModalWindowComponent implements OnInit{
  cardModel: CardModel = {id: 0, name: '', description: '', priority: '', listCardsName: '', dueDate: '',actions: null}
  listsCards$? : Observable<ListCardsModel[]>
  priorities = Object.values(Priority);
  priorityStrings : string[]= []
  dateMin: string = new Date().toISOString().slice(0, 10);
  @ViewChild('editForm') editForm: NgForm | undefined
  actions: ActionModel[] = []

  constructor(
    private cardsService: CardsService, 
    private listsCardsService: ListsCardsService,
    private actionsService: ActionsService,
    public dialogRef: MatDialogRef<ViewCardModalWindowComponent>, 
    @Inject(MAT_DIALOG_DATA) public data: any, public matDialog: MatDialog){}

    dialogConfig = new MatDialogConfig();
    modalDialogEdit: MatDialogRef<EditCardModalWindowComponent, any> | undefined;
    

  ngOnInit(): void {
    this.loadCard()
    this.loadLists()
    this.loadActions()
    this.priorities.forEach(prioritiy => {this.priorityStrings.push(String(prioritiy))
    });
  }

  loadCard(){
    this.cardsService.getCard(Number(this.data.cardResponse)).subscribe({
      next: resp => this.cardModel = resp
    })
  }

  loadActions(){
     this.actionsService.getActionsByCardId(Number(this.data.cardResponse)).
     subscribe({
      next: resp => this.actions = resp
     })
    }
     //pipe(
    //   map(res => {
    //       this.actions=res;
    //       console.log(this.actions.length, 'ttgfhg')
    //   }))

  stringToDate(dateString: string): DatePipe {
    return new DatePipe(dateString);
  }

  updateCard(){
    this.cardsService.updateCard(this.editForm?.value).subscribe({
      next: _ => {
        this.editForm?.reset(this.cardModel);
        this.closeModal();
        window.location.reload();
      }
    })
  }

  loadLists(){
    this.listsCards$=this.listsCardsService.getListsCards();
  }
    
  closeModal() {
    this.dialogRef.close();
  }

  convertToLocalDate(responseDate: any) {
    try {
        if (responseDate != null) {
            var dt = new Date(responseDate)
            return String(dt.toUTCString().split(' ').slice(0,3).join(' '));
        } else {
            return null;
        }
    } catch (error) {
        return responseDate;
    }
}

openEditForm(){
  this.dialogConfig.id = "projects-modal-component";
  this.closeModal();
  this.modalDialogEdit = this.matDialog.open(EditCardModalWindowComponent, {
    // width: '500px',
    // height: '550px',
    data: {
      cardResponse: this.cardModel.id
    }
  });
}

}
