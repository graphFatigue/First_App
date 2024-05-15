import { Component, Input, OnInit, ViewChild } from '@angular/core';
import {
  MatDialog,
  MatDialogConfig,
  MatDialogRef,
} from '@angular/material/dialog';
import { CardModel } from 'src/app/_models/card/cardModel';
import { CardsService } from 'src/app/_services/cards.service';
import { UpdateCardModel } from 'src/app/_models/card/updateCardModel';
import { ListCardsModel } from 'src/app/_models/listCards/listCardsModel';
import { ViewCardModalWindowComponent } from '../view-card-modal-window/view-card-modal-window.component';
import { Store } from '@ngrx/store';
import { loadCard } from 'src/app/store/cards/card.actions';

@Component({
  selector: 'app-card',
  templateUrl: './card.component.html',
  styleUrls: ['./card.component.css'],
})
export class CardComponent implements OnInit {
  @Input() card: CardModel | undefined;
  @Input() boardId: any;
  listsCards: ListCardsModel[] = [];
  cardModel: UpdateCardModel = {
    id: 0,
    name: '',
    description: '',
    priority: '',
    listCardsName: '',
    dueDate: '',
  };
  value: string = '';
  dialogConfig = new MatDialogConfig();
  modalDialogView: MatDialogRef<ViewCardModalWindowComponent, any> | undefined;

  constructor(
    private cardsService: CardsService,
    public matDialog: MatDialog,
    private store: Store<{
      lists: { lists: ListCardsModel[] };
      card: { card: CardModel };
    }>,
  ) {}

  ngOnInit(): void {
    this.loadLists();
  }

  loadLists() {
    try {
      this.store
        .select('lists')
        .subscribe(
          (data) =>
            (this.listsCards = data.lists.filter(
              (el) => el.name !== this.card?.listCardsName,
            )),
        );
    } catch (err) {
      console.log(err);
    }
  }

  updateCard(newValue: string | null) {
    if (this.card) {
      this.cardModel = this.card;
      this.cardModel.listCardsName = newValue;
      this.cardsService.updateCard(this.cardModel).subscribe({
        next: (_) => {
          window.location.reload();
        },
      });
    } else console.log(this.value, 'wrong');
  }

  openViewCardWindow() {
    if (this.card) this.store.dispatch(loadCard({ cardId: this.card.id }));
    this.dialogConfig.id = 'projects-modal-component';
    this.modalDialogView = this.matDialog.open(ViewCardModalWindowComponent, {
      width: '800px',
      height: '500px',
      data: {
        cardResponse: this.card?.id,
        boardResponse: this.boardId,
      },
    });
  }

  convertToLocalDate(responseDate: any) {
    try {
      if (responseDate != null) {
        var dt = new Date(responseDate);
        dt.setHours(dt.getHours() + 5);
        return String(dt.toUTCString().split(' ').slice(0, 3).join(' '));
      } else {
        return null;
      }
    } catch (error) {
      return responseDate;
    }
  }
}
