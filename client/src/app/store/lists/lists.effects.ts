import { Injectable } from "@angular/core";
import {Actions, createEffect, ofType} from '@ngrx/effects'
import { ListsCardsService } from "src/app/_services/lists-cards.service";
import { addList, addListSuccess, loadLists, loadListsSuccess } from "./lists.action";
import { EMPTY, catchError, exhaustMap, map, switchMap } from "rxjs";

@Injectable()
export class ListsEffects{
    constructor(private action$: Actions, private listsService: ListsCardsService){}

    _loadLists = createEffect(() =>
    this.action$.pipe(
        ofType(loadLists),
        switchMap((action) => {
            return this.listsService.getListsCardsByBoardId(action.boardId).pipe(
                map((data) => {
                    return loadListsSuccess({lists: data});
                }),
                catchError((err)=> EMPTY)
            )
        })
    ));

    _addList = createEffect(()=>
    this.action$.pipe(
        ofType(addList),
        exhaustMap((action) => {
            return this.listsService.createListCards(action.listInput).pipe(
                map((data) => {
                    return addListSuccess({list: data});
                }),
                catchError(()=> EMPTY)
            )
        })
    ));
}