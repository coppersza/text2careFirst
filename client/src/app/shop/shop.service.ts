import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { of } from 'rxjs';
import { map } from 'rxjs/operators';

import { IPagination, ProductPagination } from '../shared/models/pagination';
import { IProduct } from '../shared/models/product';
import { IProductType } from '../shared/models/productType';
import { ShopParams } from '../shared/models/shopParams';
import { IStore } from '../shared/models/store';

@Injectable({
  providedIn: 'root'
})
export class ShopService {
  baseUrl = 'https://localhost:5001/api/';
  products: IProduct[] = [];
  stores: IStore[] = [];
  productTypes: IProductType[] = [];
  pagination = new ProductPagination();
  shopParams = new ShopParams();
  productCache = new Map();
  constructor(private http: HttpClient) { }

  getProducts(useCache: boolean){
    if (useCache === false){
      this.productCache = new Map();
    }

    if (this.productCache.size > 0 && useCache){
      if (this.productCache.has(Object.values(this.shopParams).join('-'))){
        this.pagination.data = this.productCache.get(Object.values(this.shopParams).join('-'));
        return of(this.pagination);
      }
    }

    let params = new HttpParams();
    if (this.shopParams.storeId !== 0){
      params = params.append('storeId', this.shopParams.storeId.toString());
    }
    if (this.shopParams.productTypeId !== 0){
      params = params.append('typeId', this.shopParams.productTypeId.toString());
    }
    if (this.shopParams.search){
      params = params.append('search', this.shopParams.search);
    }
    params = params.append('sort', this.shopParams.sort);
    params = params.append('pageIndex', this.shopParams.pageNumber.toString());
    params = params.append('pageIndex', this.shopParams.pageSize.toString());
    return this.http.get<ProductPagination>(this.baseUrl + 'product', {observe:'response', params})
      .pipe(
        map(response => {
          this.productCache.set(Object.values(this.shopParams).join('-'), response.body.data);
          this.pagination = response.body;
          return this.pagination;
        })
      );
  }
  setShopParams(params: ShopParams){
    this.shopParams = params;
  }

  getShopParams(){
    return this.shopParams;
  }
  getProduct(id: number){
    let product: IProduct;
    this.productCache.forEach((products: IProduct[]) => {
      product = products.find(p => p.id === id);
    })
    if (product){
      return of(product);
    }

    if (product){
      return of(product);
    }
    return this.http.get<IProduct>(this.baseUrl + 'product/' + id);
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
    return this.http.get<IProductType[]>(this.baseUrl + 'product/type').pipe(
      map(response => {
        this.productTypes = response;
        return response;
      })
    );
  }

}
