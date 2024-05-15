import { createAction, props } from '@ngrx/store';

export const openBoard = createAction('openBoard', props<{ id: number }>());
export const closeBoard = createAction('closeBoard');
