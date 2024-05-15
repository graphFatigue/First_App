import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment.development';
import { BoardModel } from '../_models/board/boardModel';
import { CreateBoardModel } from '../_models/board/createBoardModel';

@Injectable({
  providedIn: 'root',
})
export class BoardsService {
  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) {}

  getBoards() {
    return this.http.get<BoardModel[]>(this.baseUrl + 'boards/all');
  }

  getBoard(id: string) {
    return this.http.get<BoardModel>(this.baseUrl + 'boards/' + id);
  }

  getBoardByName(name: string) {
    return this.http.get<BoardModel>(this.baseUrl + 'boards/' + name);
  }

  deleteBoard(id: number) {
    return this.http.delete<BoardModel>(this.baseUrl + 'boards/' + id);
  }

  updateBoard(updateBoardModel: BoardModel) {
    return this.http.put<BoardModel>(this.baseUrl + 'boards', updateBoardModel);
  }

  createBoard(createBoardModel: CreateBoardModel) {
    return this.http.post<CreateBoardModel>(
      this.baseUrl + 'boards',
      createBoardModel,
    );
  }
}
