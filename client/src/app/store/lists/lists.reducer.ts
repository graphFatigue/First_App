import { createReducer, on } from "@ngrx/store";
import { listsState } from "./lists.state";
import { loadLists, loadListsSuccess } from "./lists.action";

const _listsReducer = createReducer(listsState, 
    on(loadLists,(state, action)=>{
        return{
            ...state,
            boardId: action.boardId
        };
    }),
    on(loadListsSuccess,(state, action)=>{
        return{
            ...state,
            lists:action.lists
        };
    }),
    )

export function listsReducer(state: any, action: any){
    return _listsReducer(state, action);
}