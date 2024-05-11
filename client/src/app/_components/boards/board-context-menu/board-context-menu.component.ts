import { ChangeDetectionStrategy, Component, Inject, Input, ViewChild } from '@angular/core';
import { MatDialog, MatDialogConfig, MatDialogRef } from '@angular/material/dialog';
import { MenuItem } from 'primeng/api';
import { BoardsService } from 'src/app/_services/boards.service';
import { ListsCardsService } from 'src/app/_services/lists-cards.service';
import { DeleteBoardModalWindowComponent } from '../delete-board-modal-window/delete-board-modal-window.component';
import { EditBoardModalWindowComponent } from '../edit-board-modal-window/edit-board-modal-window.component';

@Component({
  selector: 'app-board-context-menu',
  templateUrl: './board-context-menu.component.html',
  styleUrls: ['./board-context-menu.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})

export class BoardContextMenuComponent {
  @Input() target: any;
  @Input() id: any;
  dialogConfig = new MatDialogConfig();
  modalDialogEdit: MatDialogRef<EditBoardModalWindowComponent, any> | undefined;
  modalDialogDelete: MatDialogRef<DeleteBoardModalWindowComponent, any> | undefined;

  constructor(private boardsCards: BoardsService, public matDialog: MatDialog){

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
    this.modalDialogEdit = this.matDialog.open(EditBoardModalWindowComponent, {
      width: '500px',
      // height: '550px',
      data: {
        boardResponse: this.id
      }
    });
  }

  openDeletePopup(){
    this.dialogConfig.id = "projects-modal-component";
    this.modalDialogDelete = this.matDialog.open(DeleteBoardModalWindowComponent, {
      // width: '500px',
      // height: '550px',
      data: {
        boardResponse: this.id
      }
    });
  }

}
