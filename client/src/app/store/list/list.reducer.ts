import { createReducer, on } from '@ngrx/store';
import { listState } from './list.state';
import { addListSuccess, loadList, loadListSuccess } from './list.actions';

const _listReducer = createReducer(
  listState,
  on(loadList, (state, action) => {
    return {
      ...state,
      listId: action.listId,
    };
  }),
  on(loadListSuccess, (state, action) => {
    return {
      ...state,
      list: action.list,
    };
  }),
  on(addListSuccess, (state, action) => {
    const _list = { ...action.listInput };
    return {
      ...state,
      bloglist: _list,
    };
  }),
);

export function listReducer(state: any, action: any) {
  return _listReducer(state, action);
}
