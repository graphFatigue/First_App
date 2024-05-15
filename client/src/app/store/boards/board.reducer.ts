import { createReducer, on } from '@ngrx/store';
import { closeBoard, openBoard } from './board.actions';
import { boardId } from './board.state';

const _boardReducer = createReducer(
  boardId,
  on(openBoard, (state, action) => {
    return {
      ...state,
      id: action.id,
    };
  }),
  on(closeBoard, (state) => {
    return {
      ...state,
      id: 0,
    };
  }),
);

export function boardReducer(state: any, action: any) {
  return _boardReducer(state, action);
}
