import { Component, OnInit } from '@angular/core';
import {
  MatDialog,
  MatDialogConfig,
  MatDialogRef,
} from '@angular/material/dialog';
import { Observable } from 'rxjs';
import { BoardModel } from 'src/app/_models/board/boardModel';
import { BoardsService } from 'src/app/_services/boards.service';
import { CreateBoardModalWindowComponent } from '../create-board-modal-window/create-board-modal-window.component';
import { Store } from '@ngrx/store';
import { openBoard } from 'src/app/store/boards/board.actions';
import { AppStateModel } from 'src/app/store/global/AppState.Model';

@Component({
  selector: 'app-board-list',
  templateUrl: './board-list.component.html',
  styleUrls: ['./board-list.component.css'],
})
export class BoardListComponent implements OnInit {
  boards$?: Observable<BoardModel[]>;
  dialogConfig = new MatDialogConfig();
  modalDialog: MatDialogRef<CreateBoardModalWindowComponent, any> | undefined;

  constructor(
    private boardsService: BoardsService,
    public matDialog: MatDialog,
    private store: Store<AppStateModel>,
  ) {}

  ngOnInit(): void {
    this.loadBoards();
  }

  loadBoards() {
    this.boards$ = this.boardsService.getBoards();
  }

  openBoardPage(id: number) {
    this.store.dispatch(openBoard({ id: id }));
  }

  openCreateForm() {
    this.dialogConfig.id = 'projects-modal-component';
    this.modalDialog = this.matDialog.open(CreateBoardModalWindowComponent, {
      width: '500px',
      data: {},
    });
  }
}
