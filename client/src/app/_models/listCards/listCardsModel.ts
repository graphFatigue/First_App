import { CardModel } from "../card/cardModel"

export interface ListCardsModel {
    id: number
    name: string
    description: string
    cards: CardModel[]
  }