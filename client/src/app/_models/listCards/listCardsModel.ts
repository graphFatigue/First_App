import { CardModel } from "../card/cardModel"

export interface ListCardsModel {
    id: number
    name: string
    boardId: number
    cards: CardModel[] | null
  }