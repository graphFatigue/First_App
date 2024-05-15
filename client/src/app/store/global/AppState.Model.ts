import { CardModel } from "src/app/_models/card/cardModel";
import { ListCardsModel } from "src/app/_models/listCards/listCardsModel";

export interface AppStateModel{
    id: number,
    lists: ListCardsModel[],
    card: CardModel,
    list: ListCardsModel
}