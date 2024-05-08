import { ChangeDetectionStrategy, Component, Inject, Input, ViewChild } from '@angular/core';
import { MatDialog, MatDialogConfig, MatDialogRef } from '@angular/material/dialog';
import { MenuItem } from 'primeng/api';
import { ListsCardsService } from 'src/app/_services/lists-cards.service';
import { EditListModalWindowComponent } from '../edit-list-modal-window/edit-list-modal-window.component';
import { DeleteListModalWindowComponent } from '../delete-list-modal-window/delete-list-modal-window.component';

@Component({
  selector: 'app-list-context-menu',
  templateUrl: './list-context-menu.component.html',
  styleUrls: ['./list-context-menu.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})

export class ListContextMenuComponent {
  @Input() target: any;
  @Input() id: any;
  dialogConfig = new MatDialogConfig();
  modalDialogEdit: MatDialogRef<EditListModalWindowComponent, any> | undefined;
  modalDialogDelete: MatDialogRef<DeleteListModalWindowComponent, any> | undefined;

  constructor(private listsCards: ListsCardsService, public matDialog: MatDialog){

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
    this.modalDialogEdit = this.matDialog.open(EditListModalWindowComponent, {
      width: '500px',
      // height: '550px',
      data: {
        listResponse: this.id
      }
    });
  }

  openDeletePopup(){
    this.dialogConfig.id = "projects-modal-component";
    this.modalDialogDelete = this.matDialog.open(DeleteListModalWindowComponent, {
      // width: '500px',
      // height: '550px',
      data: {
        listResponse: this.id
      }
    });
  }

}
