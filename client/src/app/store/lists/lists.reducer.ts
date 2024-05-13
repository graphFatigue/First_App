import { createReducer, on } from "@ngrx/store";
import { listsState } from "./lists.state";
import { addList, addListSuccess, loadLists, loadListsSuccess } from "./lists.action";

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
            lists:[...action.lists]
        };
    }),
    // on(addList,(state, action)=>{
    //     const _list = {}
    //     return{
    //         ...state,
    //         boardId: action.boardId
    //     };
    // }),
    on(addListSuccess,(state, action)=>{
        const _list = {...action.list}
        return{
            ...state,
            lists:[...state, _list]
        };
    })
    )

export function listsReducer(state: any, action: any){
    return _listsReducer(state, action);
}