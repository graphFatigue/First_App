import {
  ChangeDetectionStrategy,
  Component,
  Inject,
  Input,
  ViewChild,
} from '@angular/core';
import {
  MatDialog,
  MatDialogConfig,
  MatDialogRef,
} from '@angular/material/dialog';
import { MenuItem } from 'primeng/api';
import { EditListModalWindowComponent } from '../edit-list-modal-window/edit-list-modal-window.component';
import { DeleteListModalWindowComponent } from '../delete-list-modal-window/delete-list-modal-window.component';
import { Store } from '@ngrx/store';
import { ListCardsModel } from 'src/app/_models/listCards/listCardsModel';
import { loadList } from 'src/app/store/list/list.actions';

@Component({
  selector: 'app-list-context-menu',
  templateUrl: './list-context-menu.component.html',
  styleUrls: ['./list-context-menu.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class ListContextMenuComponent {
  @Input() target: any;
  @Input() id: any;
  dialogConfig = new MatDialogConfig();
  modalDialogEdit: MatDialogRef<EditListModalWindowComponent, any> | undefined;
  modalDialogDelete:
    | MatDialogRef<DeleteListModalWindowComponent, any>
    | undefined;

  constructor(
    public matDialog: MatDialog,
    private store: Store<{ list: ListCardsModel }>,
  ) {}

  items: MenuItem[] = [
    {
      label: 'Edit',
      command: () => this.openEditForm(),
    },
    {
      label: 'Delete',
      command: () => this.openDeletePopup(),
    },
  ];

  openEditForm() {
    this.store.dispatch(loadList({ listId: this.id }));
    setTimeout(() => {
      this.dialogConfig.id = 'projects-modal-component';
      this.modalDialogEdit = this.matDialog.open(EditListModalWindowComponent, {
        width: '500px',
        data: {
          listResponse: this.id,
        },
      });
    }, 100);
  }

  openDeletePopup() {
    this.dialogConfig.id = 'projects-modal-component';
    this.modalDialogDelete = this.matDialog.open(
      DeleteListModalWindowComponent,
      {
        data: {
          listResponse: this.id,
        },
      },
    );
  }
}
