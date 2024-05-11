import { Component, OnInit } from '@angular/core';
import { MatDialog, MatDialogConfig, MatDialogRef } from '@angular/material/dialog';
import { BehaviorSubject, Observable } from 'rxjs';
import { BoardModel } from 'src/app/_models/board/boardModel';
import { BoardsService } from 'src/app/_services/boards.service';
import { CreateBoardModalWindowComponent } from '../create-board-modal-window/create-board-modal-window.component';

@Component({
  selector: 'app-board-list',
  templateUrl: './board-list.component.html',
  styleUrls: ['./board-list.component.css']
})
export class BoardListComponent implements OnInit{
  boards$? : Observable<BoardModel[]>
  dialogConfig = new MatDialogConfig();
  modalDialog: MatDialogRef<CreateBoardModalWindowComponent, any> | undefined;

  constructor(public boardsService: BoardsService, public matDialog: MatDialog){}

  ngOnInit(): void {
    this.loadBoards();
  }
    
  loadBoards(){
    this.boards$ = this.boardsService.getBoards()
  }

  openCreateForm(){
    this.dialogConfig.id = "projects-modal-component";
    this.modalDialog = this.matDialog.open(CreateBoardModalWindowComponent, {
      width: '500px',
      // height: '550px',
      data: {
        
      }
    });
  }
}
