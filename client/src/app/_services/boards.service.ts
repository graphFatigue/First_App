import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ListCardsModel } from '../_models/listCards/listCardsModel';
import { environment } from 'src/environments/environment.development';
import { CreateListCardsModel } from '../_models/listCards/createListCardsModel';
import { BoardModel } from '../_models/board/boardModel';
import { CreateBoardModel } from '../_models/board/createBoardModel';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class BoardsService {
  baseUrl = environment.apiUrl;

  boardPageIsOpened$: BehaviorSubject<boolean> = new BehaviorSubject(false);

  constructor(private http: HttpClient) { }

  public openBoardPage() {
    this.boardPageIsOpened$.next(true);
  }

  public closeBoardPage() {
    this.boardPageIsOpened$.next(false);
  }

  getBoards(){
    return this.http.get<BoardModel[]>(this.baseUrl + 'boards/all')
  }

  getBoard(id: string){
    return this.http.get<BoardModel>(this.baseUrl + 'boards/' + id)
  }

  getBoardByName(name: string){
    return this.http.get<BoardModel>(this.baseUrl + 'boards/' + name)
  }

  deleteBoard(id: number){
    return this.http.delete<BoardModel>(this.baseUrl + 'boards/' + id)
  }

  updateBoard(updateBoardModel: BoardModel){
    return this.http.put<BoardModel>(this.baseUrl + 'boards', updateBoardModel)
  }

  createBoard(createBoardModel: CreateBoardModel){
    return this.http.post<CreateBoardModel>(this.baseUrl + 'boards', createBoardModel)
  }

}
