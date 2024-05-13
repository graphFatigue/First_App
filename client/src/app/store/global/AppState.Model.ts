import { ListCardsModel } from "src/app/_models/listCards/listCardsModel";

export interface AppStateModel{
    boardId: number,
    lists: ListCardsModel[]
}