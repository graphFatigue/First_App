import { createAction, props } from '@ngrx/store';
import { ListCardsModel } from 'src/app/_models/listCards/listCardsModel';

export const LOAD_LISTS_SUCCESS = '[card component] load lists success';
export const LOAD_LISTS = '[card component] load lists';

export const loadLists = createAction(LOAD_LISTS, props<{ boardId: number }>());
export const loadListsSuccess = createAction(
  LOAD_LISTS_SUCCESS,
  props<{ lists: ListCardsModel[] }>(),
);
