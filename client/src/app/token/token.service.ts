import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map } from 'rxjs/operators';
import { of } from 'rxjs';

import { IPagination, TokenPagination } from '../shared/models/pagination';
import { IToken } from '../shared/models/token';
import { IProductType } from '../shared/models/productType';
import { TokenParams } from '../shared/models/tokenParams';
import { IStore } from '../shared/models/store';

@Injectable({
  providedIn: 'root'
})
export class TokenService {
  baseUrl = 'https://localhost:5001/api/';
  tokens: IToken[] = [];
  stores: IStore[] = [];
  productTypes: IProductType[] = [];
  pagination = new TokenPagination();
  tokenParams = new TokenParams();
  tokenCache = new Map();

  constructor(private http: HttpClient) { }

  getTokens(useCache: boolean){
    if (useCache === false){
      this.tokenCache = new Map();
    }
    if (this.tokenCache.size > 0 && useCache){
      if (this.tokenCache.has(Object.values(this.tokenParams).join('-'))){
        this.pagination.data = this.tokenCache.get(Object.values(this.tokenParams).join('-'));
        return of(this.pagination);
      }
    }
    let params = new HttpParams();
    if (this.tokenParams.storeId !== 0){
      params = params.append('storeId', this.tokenParams.storeId.toString());
    }
    if (this.tokenParams.productTypeId !== 0){
      params = params.append('productTypeId', this.tokenParams.productTypeId.toString());
    }
    if (this.tokenParams.search){
      params = params.append('search', this.tokenParams.search);
    }
    params = params.append('sort', this.tokenParams.sort);
    params = params.append('pageIndex', this.tokenParams.pageNumber.toString());
    params = params.append('pageSize', this.tokenParams.pageSize.toString());

    return this.http.get<TokenPagination>(this.baseUrl + 'token', {observe: 'response', params})
      .pipe(
        map(response =>{

          this.tokenCache.set(Object.values(this.tokenParams).join('-'), response.body.data);
          this.pagination = response.body;
          return this.pagination;
        })
      );
  }

  setTokenParams(params: TokenParams){
    this.tokenParams = params;
  }

  getTokenParams(){
    return this.tokenParams;
  }

  getToken(id: number){
    let token: IToken;
    this.tokenCache.forEach((tokens: IToken[]) => {
      token = tokens.find(p => p.id === id);
    })
    if (token){
      return of(token);
    }

    if (token){
      return of(token);
    }
    return this.http.get<IToken>(this.baseUrl + 'token/' + id);

  }

  getStores(){
    if (this.stores.length > 0){
      return of(this.stores);
    }
    return this.http.get<IStore[]>(this.baseUrl + 'store').pipe(
      map(response => {
        this.stores = response;
        return response;
      })
    );
  }

  getProductTypes(){
    if (this.productTypes.length > 0){
      return of(this.productTypes);
    }
    return this.http.get<IProductType[]>(this.baseUrl + 'product/producttype').pipe(
      map(response => {
        this.productTypes = response;
        return response;
      })
    );
  }
}
