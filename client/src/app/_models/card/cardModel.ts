import { UpdateCardModel } from "./updateCardModel"

export interface CardModel {
    id: number,
    name: string
    description: string
    dueDate: string
    priority: string
    listCardsName: string | null
  }