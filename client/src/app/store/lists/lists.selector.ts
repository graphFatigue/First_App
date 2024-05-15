import { createFeatureSelector, createSelector } from "@ngrx/store";
import { ListCardsModel } from "src/app/_models/listCards/listCardsModel";

const getlistsstate=createFeatureSelector<ListCardsModel[]>('listsoo');

export const getlists=createSelector(getlistsstate,(state)=>{
    return state
});