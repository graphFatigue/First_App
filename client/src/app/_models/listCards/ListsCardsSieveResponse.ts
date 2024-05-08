import { ListCardsModel } from "./listCardsModel"

export interface ListsCardsSieveResponse {
    items: ListCardsModel[]
    currentPage: number,
    totalPages: number,
    pageSize: number,
    totalCount: number,
    hasPrevious: boolean,
    hasNext: boolean
}