import { CardModel } from "../card/cardModel"
import { ListCardsModel } from "../listCards/listCardsModel"

export interface BoardModel {
    id: number
    name: string
    listsCards: ListCardsModel[] | null
    cards: CardModel[] | null
  }