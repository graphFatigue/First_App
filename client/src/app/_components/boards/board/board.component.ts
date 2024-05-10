import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { BoardModel } from 'src/app/_models/board/boardModel';
import { BoardsService } from 'src/app/_services/boards.service';
import { CreateListCardsModalWindowComponent } from '../../lists-cards/create-list-modal-window/create-list-modal-window.component';
import { MatDialog, MatDialogConfig, MatDialogRef } from '@angular/material/dialog';

@Component({
  selector: 'app-board',
  templateUrl: './board.component.html',
  styleUrls: ['./board.component.css']
})
export class BoardComponent implements OnInit{
  board: BoardModel | undefined;
  dialogConfig = new MatDialogConfig();
  modalDialog: MatDialogRef<CreateListCardsModalWindowComponent, any> | undefined;

  constructor(private boardsService: BoardsService, private route: ActivatedRoute, public matDialog: MatDialog){}

  ngOnInit(): void {
    this.loadBoard();
  }

  loadBoard(){
    var id =  this.route.snapshot.paramMap.get('id');
    if (!id) return;
    this.boardsService.openBoardPage(Number(id));
    this.boardsService.getBoard(id).subscribe({
      next: board => this.board = board
    })
  }

  openCreateForm(){
    this.dialogConfig.id = "projects-modal-component";
    this.modalDialog = this.matDialog.open(CreateListCardsModalWindowComponent, {
      width: '500px',
      // height: '550px',
      data: {
        boardResponse: this.board?.id
      }
    });
  }

}
