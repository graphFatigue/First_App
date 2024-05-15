import { createAction, props } from "@ngrx/store";
import { CreateListCardsModel } from "src/app/_models/listCards/createListCardsModel";
import { ListCardsModel } from "src/app/_models/listCards/listCardsModel";

export const LOAD_LIST_SUCCESS='[edit list component] load list success'
export const LOAD_LIST='[edit list component] load list'
export const ADD_LIST_SUCCESS='[create list component] add list success';
export const ADD_LIST='[create list component] add list';

export const loadList=createAction(LOAD_LIST, props<{listId: number}>());
export const loadListSuccess=createAction(LOAD_LIST_SUCCESS, props<{list: ListCardsModel}>());
export const addList=createAction(ADD_LIST,props<{listinput:CreateListCardsModel}>());
export const addListSuccess=createAction(ADD_LIST_SUCCESS,props<{listInput:CreateListCardsModel}>());