import { createAction, props } from "@ngrx/store";
import { CreateListCardsModel } from "src/app/_models/listCards/createListCardsModel";
import { ListCardsModel } from "src/app/_models/listCards/listCardsModel";

export const LOAD_LISTS_SUCCESS='[card component] load lists success'
export const LOAD_LISTS='[card component] load lists'

export const ADD_LIST_SUCCESS='[list component] add list success'
export const ADD_LIST='[list component] add list'

export const loadLists=createAction(LOAD_LISTS, props<{boardId: number}>());
export const loadListsSuccess=createAction(LOAD_LISTS_SUCCESS, props<{lists: ListCardsModel[]}>());

export const addList=createAction(ADD_LIST, props<{listInput: CreateListCardsModel}>);
export const addListSuccess=createAction(ADD_LIST_SUCCESS, props<{list: ListCardsModel}>());