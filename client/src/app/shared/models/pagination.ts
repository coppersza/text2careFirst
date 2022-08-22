import { IProduct } from "./product";
import { IToken } from "./token";

export interface IPagination {
    pageIndex: number;
    pageSize: number;
    count: number;
    data: any[];
}
export class ProductPagination implements IPagination{
    pageIndex: number;
    pageSize: number;
    count: number;
    data: IProduct[] = [];
}
export class TokenPagination implements IPagination{
  pageIndex: number;
  pageSize: number;
  count: number;
  data: IToken[] = [];
}

