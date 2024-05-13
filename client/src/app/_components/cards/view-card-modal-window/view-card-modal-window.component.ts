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
import { EditCardModalWindowComponent } from '../edit-card-modal-window/edit-card-modal-window.component';
import { ActionsService } from 'src/app/_services/actions.service';
import { ActionModel } from 'src/app/_models/action/actionModel';
import { Store } from '@ngrx/store';

@Component({
  selector: 'app-view-card-modal-window',
  templateUrl: './view-card-modal-window.component.html',
  styleUrls: ['./view-card-modal-window.component.css']
})
export class ViewCardModalWindowComponent implements OnInit{
  card: CardModel = {id:0, name:'', description:'', boardId:0, listCardsName:'', priority:'', dueDate:'', actions:[]}
  listsCards$? : Observable<ListCardsModel[]>
  actionsObs$?: Observable<ActionModel[]>
  priorities = Object.values(Priority);
  priorityStrings : string[]= []
  dateMin: string = new Date().toISOString().slice(0, 10);
  @ViewChild('editForm') editForm: NgForm | undefined

  constructor(
    private cardsService: CardsService, 
    private listsCardsService: ListsCardsService,
    private actionsService: ActionsService,
    public dialogRef: MatDialogRef<ViewCardModalWindowComponent>, 
    @Inject(MAT_DIALOG_DATA) public data: any, public matDialog: MatDialog, private store: Store<{card:{card:CardModel}}>){}

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
    this.store.select('card').subscribe(data=> this.card = data.card);
  }

  loadActions(){
     this.actionsObs$ = this.actionsService.getActionsByCardId(Number(this.data.cardResponse))
    }

  stringToDate(dateString: string): DatePipe {
    return new DatePipe(dateString);
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
            var dt = new Date(responseDate);
            dt.setHours(dt.getHours()+5);
            return String(dt.toUTCString().split(' ').slice(0,3).join(' '));
        } else {
            return null;
        }
    } catch (error) {
        return responseDate;
    }
}

convertToLocalDate2(responseDate: any) {
  try {
      if (responseDate != null) {
          var dt = new Date(responseDate)
          return String('on ' + dt.toUTCString().split(' ').slice(0,3).join(' ') + ' at ' + dt.toTimeString().split(' ')[0].split(':').slice(0,2).join(':'));
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
      cardResponse: Number(this.data.cardResponse),
      boardResponse: this.data.boardResponse
    }
  });
}

}
