import { Component, OnInit } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { BoardModel } from 'src/app/_models/board/boardModel';
import { BoardsService } from 'src/app/_services/boards.service';

@Component({
  selector: 'app-board-list',
  templateUrl: './board-list.component.html',
  styleUrls: ['./board-list.component.css']
})
export class BoardListComponent implements OnInit{
  boards$? : Observable<BoardModel[]>

  constructor(public boardsService: BoardsService){}

  ngOnInit(): void {
    this.loadBoards();
  }

  openBoardPage(){
    this.boardsService.boardPageIsOpened$.next(true);
  }
    
  loadBoards(){
    this.boards$ = this.boardsService.getBoards()
  }
}
