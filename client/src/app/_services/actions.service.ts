import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment.development';
import { ActionModel } from '../_models/action/actionModel';
import { ActionsSieveResponse } from '../_models/action/actionsSieveResponse';

@Injectable({
  providedIn: 'root'
})
export class ActionsService {
  baseUrl = environment.apiUrl;
  
  constructor(private http: HttpClient) { }

  getActions(){
    return this.http.get<ActionsSieveResponse>(this.baseUrl + 'actions?Sorts=-actionTime')
  }

  getActionsByCardId(cardId: number){
    return this.http.get<ActionModel[]>(this.baseUrl + 'actions/' + cardId)
  }

  loadActionsWithNumPage(page: number){
    return this.http.get<ActionsSieveResponse>(this.baseUrl + String('actions?Sorts=-ActionTime&Page=' + page + '&PageSize=20'))
  }

  loadActionsWithNumPageAndBoardId(page: number, boardId: number){
    return this.http.get<ActionsSieveResponse>(this.baseUrl + String('actions?Filters=boardid==' + boardId +'&Sorts=-ActionTime&Page=' + page + '&PageSize=20'))
  }
}
