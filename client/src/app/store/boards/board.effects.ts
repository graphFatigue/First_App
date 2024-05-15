import { Injectable } from '@angular/core';
import { Actions } from '@ngrx/effects';
import { BoardsService } from '../../_services/boards.service';

Injectable();
export class BoardEffects {
  constructor(
    private action$: Actions,
    private boardsService: BoardsService,
  ) {}
}
