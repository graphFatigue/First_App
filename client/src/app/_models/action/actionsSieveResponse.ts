import { ActionModel } from "./actionModel";

export interface ActionsSieveResponse {
    items: ActionModel[]
    currentPage: number,
    totalPages: number,
    pageSize: number,
    totalCount: number,
    hasPrevious: boolean,
    hasNext: boolean
}