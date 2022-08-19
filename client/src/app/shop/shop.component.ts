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
  productTypes: IProductType[];
  shopParams = new ShopParams();
  totalCount: number;

  sortOptions = [
    {name: 'Alphabetical', value: 'name'},
    {name: 'Price: Low to High', value: 'priceAsc'},
    {name: 'Price: High to Low ', value: 'priceDesc'}
  ];


  constructor(private shopService: ShopService) { }

  ngOnInit(): void {
    this.getProducts();
    this.getStores();
    this.getProductTypes();

  }

  getProducts(){
    this.shopService.getProducts(this.shopParams).subscribe(response => {
        this.products = response.data;
        this.shopParams.pageNumber = response.pageIndex;
        this.shopParams.pageSize = response.pageSize;
        this.totalCount = response.count;
      }, error => {
        console.log(error);
      });
  }
  getStores(){
    this.shopService.getStores().subscribe(response => {
      this.stores = [{id: 0, storeName: 'All', country:'', description:'', imageUrl:''}, ...response];
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
    this.shopParams.storeId = storeId;
    this.shopParams.pageNumber = 1;
    this.getProducts();
  }
  onProductTypeSelected(productTypeId: number){
    this.shopParams.productTypeId = productTypeId;
    this.shopParams.pageNumber = 1;
    this.getProducts();
  }
  onSortSelected(sort: string){
    this.shopParams.sort = sort;
    this.getProducts();
  }
  onPageChanged(event: any){
    if (this.shopParams.pageNumber !== event){
      this.shopParams.pageNumber = event;
      this.getProducts();
    }
  }
  onSearch(){
    this.shopParams.search = this.searchValue.nativeElement.value;
    this.shopParams.pageNumber = 1;
    this.getProducts();
  }
  onReset(){
    this.searchValue.nativeElement.value = '';
    this.shopParams = new ShopParams();
    this.getProducts();
  }

}
