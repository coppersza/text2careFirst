import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map } from 'rxjs/operators';

import { IPagination } from '../shared/models/pagination';
import { IProduct } from '../shared/models/product';
import { IProductType } from '../shared/models/productType';
import { ShopParams } from '../shared/models/shopParams';
import { IStore } from '../shared/models/store';

@Injectable({
  providedIn: 'root'
})
export class ShopService {
  baseUrl = 'https://localhost:5001/api/';

  constructor(private http: HttpClient) { }

  getProducts(shopParams: ShopParams){
    let params = new HttpParams();
    if (shopParams.storeId !== 0){
      params = params.append('storeId', shopParams.storeId.toString());
    }
    if (shopParams.productTypeId !== 0){
      params = params.append('typeId', shopParams.productTypeId.toString());
    }
    if (shopParams.search){
      params = params.append('search', shopParams.search);
    }
    params = params.append('sort', shopParams.sort);
    params = params.append('pageIndex', shopParams.pageNumber.toString());
    params = params.append('pageSize', shopParams.pageSize.toString());

    return this.http.get<IPagination>(this.baseUrl + 'product', {observe: 'response', params})
      .pipe(
        map(response =>{
          return response.body;
        })
      );
  }
  getProduct(id: number){
    return this.http.get<IProduct>(this.baseUrl + 'product/' + id);
  }
  getStores(){
    return this.http.get<IStore[]>(this.baseUrl + 'store');
  }
  getProductTypes(){
    return this.http.get<IProductType[]>(this.baseUrl + 'product/type');
  }

}
