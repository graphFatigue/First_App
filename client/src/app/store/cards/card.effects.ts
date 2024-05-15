import { Injectable } from '@angular/core';
import { Actions, createEffect, ofType } from '@ngrx/effects';
import { EMPTY, catchError, map, switchMap } from 'rxjs';
import { CardsService } from 'src/app/_services/cards.service';
import { loadCard, loadCardSuccess } from './card.actions';

@Injectable()
export class CardEffects {
  constructor(
    private action$: Actions,
    private cardsService: CardsService,
  ) {}

  _loadCard = createEffect(() =>
    this.action$.pipe(
      ofType(loadCard),
      switchMap((action) => {
        return this.cardsService.getCard(action.cardId).pipe(
          map((data) => {
            return loadCardSuccess({ card: data });
          }),
          catchError((err) => EMPTY),
        );
      }),
    ),
  );
}
