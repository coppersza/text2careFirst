import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { IProduct } from '../shared/models/product';
import { IProductType } from '../shared/models/productType';
import { ShopParams } from '../shared/models/shopParams';
import { IStore } from '../shared/models/store';
import { ShopService } from './shop.service';

@Component({
  selector: 'app-shop',
  templateUrl: './shop.component.html',
  styleUrls: ['./shop.component.scss']
})
export class ShopComponent implements OnInit {
  @ViewChild('search', {static: false}) searchValue: ElementRef;
  products: IProduct[];
  stores: IStore[];
  store: IStore;
  productTypes: IProductType[];
  shopParams: ShopParams;
  totalCount: number;

  sortOptions = [
    {name: 'Alphabetical', value: 'name'},
    {name: 'Price: Low to High', value: 'priceAsc'},
    {name: 'Price: High to Low ', value: 'priceDesc'}
  ];


  constructor(private shopService: ShopService) {
    this.shopParams = this.shopService.getShopParams();
   }

  ngOnInit(): void {
    this.getProducts(true);
    this.getStores();
    this.getProductTypes();

  }

  getProducts(useCache = false){
    this.shopService.getProducts(useCache).subscribe(response => {
        this.products = response.data;
        this.totalCount = response.count;
      }, error => {
        console.log(error);
      });
  }
  getStores(){
    this.shopService.getStores().subscribe(response => {
      this.stores = [{id: 0, storeName: 'All', description:'', imageUrl:'', country:'', fullName:''}, ...response];
      // this.stores = response;
    }, error => {
      console.log(error);
    });
  }
  getProductTypes(){
    this.shopService.getProductTypes().subscribe(response => {
      this.productTypes = response;
      this.productTypes = [{id: 0, name: 'All', description:''}, ...response];
    }, error => {
      console.log(error);
    });
  }

  onStoreSelected(storeId: number){
    const params = this.shopService.getShopParams();
    params.storeId = storeId;
    params.pageNumber = 1;
    this.shopService.setShopParams(params);
    this.store = this.stores.find(store => store.id === storeId);
    this.getProducts();
  }
  onProductTypeSelected(productTypeId: number){
    const params = this.shopService.getShopParams();
    params.productTypeId = productTypeId;
    params.pageNumber = 1;
    this.shopService.setShopParams(params);

    this.getProducts();
  }
  onSortSelected(sort: string){
    const params = this.shopService.getShopParams();
    params.sort = sort;
    this.shopService.setShopParams(params);
    this.getProducts();
  }
  onPageChanged(event: any){
    const params = this.shopService.getShopParams();

    if (params.pageNumber !== event){
      params.pageNumber = event;
      this.shopService.setShopParams(params);
      this.getProducts(true);
    }
  }
  onSearch(){
    const params = this.shopService.getShopParams();

    params.search = this.searchValue.nativeElement.value;
    params.pageNumber = 1;
    this.shopService.setShopParams(params);
    this.getProducts();
  }
  onReset(){
    this.searchValue.nativeElement.value = '';
    this.shopParams = new ShopParams();
    this.shopService.setShopParams(this.shopParams);
    this.getProducts();
  }

}
