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
}
