import { CardModel } from "./cardModel"

export interface CardsSieveResponse {
    items: CardModel[]
    currentPage: number,
    totalPages: number,
    pageSize: number,
    totalCount: number,
    hasPrevious: boolean,
    hasNext: boolean
}