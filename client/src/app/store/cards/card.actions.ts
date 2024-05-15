import { createAction, props } from '@ngrx/store';
import { Observable } from 'rxjs';
import { CardModel } from 'src/app/_models/card/cardModel';

export const LOAD_CARD_SUCCESS = '[view card component] load card success';
export const LOAD_CARD = '[view card component] load card';

export const loadCard = createAction(LOAD_CARD, props<{ cardId: number }>());
export const loadCardSuccess = createAction(
  LOAD_CARD_SUCCESS,
  props<{ card: CardModel }>(),
);
