import { createReducer, on } from "@ngrx/store";
import { cardState } from "./card.state";
import { loadCard, loadCardSuccess } from "./card.actions";

const _cardReducer = createReducer(cardState, 
    on(loadCard, (state, action)=>{
        return{
            ...state,
            cardId: action.cardId
        }
    }),
    on(loadCardSuccess,(state, action) =>{
        return{
            ...state,
            card:action.card
        };
    })
    )

export function cardReducer(state: any, action: any){
    return _cardReducer(state, action);
}