import { Component, Input, OnInit, ViewChild } from '@angular/core';
import { MatDialog, MatDialogConfig, MatDialogRef } from '@angular/material/dialog';
import { CardModel } from 'src/app/_models/card/cardModel';
import { CardsService } from 'src/app/_services/cards.service';
import { UpdateCardModel } from 'src/app/_models/card/updateCardModel';
import { ListCardsModel } from 'src/app/_models/listCards/listCardsModel';
import { Observable } from 'rxjs';
import { ListsCardsService } from 'src/app/_services/lists-cards.service';
import { ViewCardModalWindowComponent } from '../view-card-modal-window/view-card-modal-window.component';

@Component({
  selector: 'app-card',
  templateUrl: './card.component.html',
  styleUrls: ['./card.component.css']
})
export class CardComponent implements OnInit{
  @Input() card: CardModel | undefined;
  listsCards : ListCardsModel[] = [];
  cardModel: UpdateCardModel = {id: 0, name: '', description: '', priority: '', listCardsName: '', dueDate: ''}
  value : string = ''
  dialogConfig = new MatDialogConfig();
  modalDialogView: MatDialogRef<ViewCardModalWindowComponent, any> | undefined;

  constructor(private listsCardsService: ListsCardsService, private cardsService: CardsService, public matDialog: MatDialog){}

  ngOnInit(): void {
    this.loadLists();
  }

  loadLists(){
    this.listsCardsService.getListsCards().subscribe({
    next: listsCards => this.listsCards = listsCards.filter(el => el.name!==this.card?.listCardsName)
  })
}

  updateCard(newValue: string | null){
    if(this.card ){
      console.log(this.value, 'wrong')
      this.cardModel = this.card
      this.cardModel.listCardsName = newValue
      this.cardsService.updateCard(this.cardModel).subscribe({
        next: _ => {
          window.location.reload();
        }
      })
    }
    else console.log(this.value, 'wrong')
  }

  openViewCardWindow(){
    this.dialogConfig.id = "projects-modal-component";
    this.modalDialogView = this.matDialog.open(ViewCardModalWindowComponent, {
      width: '800px',
      height: '500px',
      data: {
        cardResponse: this.card?.id
      }
    });
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
 
}
