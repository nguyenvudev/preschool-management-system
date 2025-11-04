import type { Query } from "@tanstack/react-query";

export  interface BaseEntity {
    id : string;
    createAt : string;
    updatedAt? : string;
    createdBy? : string;
    updatedBy? : string;
    isdeleted? : boolean;


}

export interface ApiRespose<T> {
    data: T;
    message: string;
    success: boolean;

}

export interface PagedResponse<T> {
    data: T[];
    page: number;
    pagesize: number;
    totalCount: number;
    totalPages: number;
    hasPrevious: boolean;
    hasNext: boolean;
}
export interface paginationQuery {
    page?: number;
    pageSize?: Query;
    sortBy?: string;
    sortDesc?: boolean;
    search?: string;
    

}