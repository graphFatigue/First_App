import { Injectable } from '@angular/core';
import { Actions, createEffect, ofType } from '@ngrx/effects';
import { EMPTY, catchError, map, of, switchMap } from 'rxjs';
import {
  addList,
  addListSuccess,
  loadList,
  loadListSuccess,
} from './list.actions';
import { ListsCardsService } from 'src/app/_services/lists-cards.service';
import { CreateListCardsModel } from 'src/app/_models/listCards/createListCardsModel';

@Injectable()
export class ListEffects {
  constructor(
    private action$: Actions,
    private listCardsService: ListsCardsService,
  ) {}

  _loadList = createEffect(() =>
    this.action$.pipe(
      ofType(loadList),
      switchMap((action) => {
        return this.listCardsService.getListCards(action.listId).pipe(
          map((data) => {
            return loadListSuccess({ list: data });
          }),
          catchError((err) => EMPTY),
        );
      }),
    ),
  );

  _AddList = createEffect(() =>
    this.action$.pipe(
      ofType(addList),
      switchMap((action) =>
        this.listCardsService.createListCards(action.listinput).pipe(
          switchMap((data) =>
            of(addListSuccess({ listInput: data as CreateListCardsModel })),
          ),
          catchError((_error) => EMPTY),
        ),
      ),
    ),
  );
}
