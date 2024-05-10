import { ChangeDetectionStrategy, Component, Inject, Input, ViewChild } from '@angular/core';
import { MatDialog, MatDialogConfig, MatDialogRef } from '@angular/material/dialog';
import { MenuItem } from 'primeng/api';
import { CardsService } from 'src/app/_services/cards.service';
import { EditCardModalWindowComponent } from '../edit-card-modal-window/edit-card-modal-window.component';
import { DeleteCardModalWindowComponent } from '../delete-card-modal-window/delete-card-modal-window.component';

@Component({
  selector: 'app-card-context-menu',
  templateUrl: './card-context-menu.component.html',
  styleUrls: ['./card-context-menu.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})

export class CardContextMenuComponent {
  @Input() target: any;
  @Input() id: any;
  @Input() boardId: any;
  dialogConfig = new MatDialogConfig();
  modalDialogEdit: MatDialogRef<EditCardModalWindowComponent, any> | undefined;
  modalDialogDelete: MatDialogRef<DeleteCardModalWindowComponent, any> | undefined;

  constructor(private cardsService: CardsService, public matDialog: MatDialog){

  }

  items: MenuItem[] = [
    {
    label: 'Edit',
    command: () => this.openEditForm()
  },
  {
    label: 'Delete',
    command: () => this.openDeletePopup()
  }
  ]

  openEditForm(){
    this.dialogConfig.id = "projects-modal-component";
    this.modalDialogEdit = this.matDialog.open(EditCardModalWindowComponent, {
      // width: '500px',
      // height: '550px',
      data: {
        cardResponse: this.id,
        boardResponse: this.boardId
      }
    });
  }

  openDeletePopup(){
    this.dialogConfig.id = "projects-modal-component";
    this.modalDialogDelete = this.matDialog.open(DeleteCardModalWindowComponent, {
      // width: '500px',
      // height: '550px',
      data: {
        cardResponse: this.id
      }
    });
  }

}
