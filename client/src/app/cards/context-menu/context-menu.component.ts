import { ChangeDetectionStrategy, Component, Inject, Input, ViewChild } from '@angular/core';
import { MatDialog, MatDialogConfig, MatDialogRef } from '@angular/material/dialog';
import { MenuItem } from 'primeng/api';
import { CardsService } from 'src/app/_services/cards.service';
import { EditCardModalWindowComponent } from '../edit-card-modal-window/edit-card-modal-window.component';

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
  modalDialog: MatDialogRef<EditCardModalWindowComponent, any> | undefined;

  constructor(private cardsService: CardsService, public matDialog: MatDialog){

  }

  items: MenuItem[] = [
    {
    label: 'Edit',
    command: () => this.openEditForm()
  },
  {
    label: 'Delete',
    command: () => this.cardsService.getCards()
  }
  ]

  openEditForm(){
    this.dialogConfig.id = "projects-modal-component";
    this.dialogConfig.height = "500px";
    this.dialogConfig.width = "650px";
    this.modalDialog = this.matDialog.open(EditCardModalWindowComponent, {
      width: '330px',
      height: '400px',
      data: {
        cardResponse: this.id
      }
    });
  }

}
