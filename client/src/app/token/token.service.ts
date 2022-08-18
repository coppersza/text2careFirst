import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map } from 'rxjs/operators';

import { IPagination } from '../shared/models/pagination';
import { IProductType } from '../shared/models/productType';
import { TokenParams } from '../shared/models/tokenParams';
import { IStore } from '../shared/models/store';
import { IToken } from '../shared/models/token';


@Injectable({
  providedIn: 'root'
})
export class TokenService {
  baseUrl = 'https://localhost:5001/api/';

  constructor(private http: HttpClient) { }

  getTokens(tokenParams: TokenParams){
    let params = new HttpParams();
    if (tokenParams.storeId !== 0){
      params = params.append('storeId', tokenParams.storeId.toString());
    }
    if (tokenParams.productTypeId !== 0){
      params = params.append('typeId', tokenParams.productTypeId.toString());
    }
    if (tokenParams.search){
      params = params.append('search', tokenParams.search);
    }
    params = params.append('sort', tokenParams.sort);
    params = params.append('pageIndex', tokenParams.pageNumber.toString());
    params = params.append('pageSize', tokenParams.pageSize.toString());

    return this.http.get<IPagination>(this.baseUrl + 'token', {observe: 'response', params})
      .pipe(
        map(response =>{
          return response.body;
        })
      );
  }
  getToken(id: number){
    return this.http.get<IToken>(this.baseUrl + 'token/' + id);
  }
  getStores(){
    return this.http.get<IStore[]>(this.baseUrl + 'store');
  }
  getProductTypes(){
    return this.http.get<IProductType[]>(this.baseUrl + 'product/type');
  }
}
