import { ChangeDetectionStrategy, Component, Inject, Input, ViewChild } from '@angular/core';
import { MatDialog, MatDialogConfig, MatDialogRef } from '@angular/material/dialog';
import { MenuItem } from 'primeng/api';
import { CardsService } from 'src/app/_services/cards.service';
import { EditCardModalWindowComponent } from '../edit-card-modal-window/edit-card-modal-window.component';
import { DeleteCardModalWindowComponent } from '../delete-card-modal-window/delete-card-modal-window.component';

@Component({
  selector: 'app-context-menu',
  templateUrl: './context-menu.component.html',
  styleUrls: ['./context-menu.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})

export class ContextMenuComponent {
  @Input() target: any;
  @Input() id: any;
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
        cardResponse: this.id
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
