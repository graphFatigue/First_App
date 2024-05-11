import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Store } from '@ngrx/store';
import { BoardsService } from 'src/app/_services/boards.service';
import { closeBoard } from 'src/app/store/board.actions';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit{
  boardId: number = 0

  constructor( private store: Store<{id:{id: number}}>){}

  ngOnInit(): void {
    this.store.select('id').subscribe(data=> this.boardId = data.id)
  }

  closeBoardPage(){
    this.store.dispatch(closeBoard())
  }

}
