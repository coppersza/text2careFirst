



import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { IToken } from '../shared/models/token';
import { IProductType } from '../shared/models/productType';
import { TokenParams } from '../shared/models/tokenParams';
import { IStore } from '../shared/models/store';
import { TokenService } from './token.service';

@Component({
  selector: 'app-token',
  templateUrl: './token.component.html',
  styleUrls: ['./token.component.scss']
})
export class TokenComponent implements OnInit {
  @ViewChild('search', {static: false}) searchValue: ElementRef;
  tokens: IToken[];
  stores: IStore[];
  productTypes: IProductType[];
  tokenParams: TokenParams;
  totalCount: number;

  sortOptions = [
    {name: 'Alphabetical', value: 'name'},
    {name: 'Date: Low to High', value: 'dateAsc'},
    {name: 'Date: High to Low ', value: 'dateDesc'}
  ];


  constructor(private tokenService: TokenService) {
    this.tokenParams = this.tokenService.getTokenParams();
   }

  ngOnInit(): void {
    this.getTokens(true);
    this.getStores();
    this.getProductTypes();
  }
  getTokens(useCache = false){
    this.tokenService.getTokens(useCache).subscribe(response => {
        this.tokens = response.data;
        this.totalCount = response.count;
      }, error => {
        console.log(error);
      });
  }
  getStores(){
    this.tokenService.getStores().subscribe(response => {
      this.stores = [{id: 0, storeName: 'All', description:'', imageUrl:'', country:'', fullName:''}, ...response];
      // this.stores = response;
    }, error => {
      console.log(error);
    });
  }
  getProductTypes(){
    this.tokenService.getProductTypes().subscribe(response => {
      this.productTypes = response;
      this.productTypes = [{id: 0, name: 'All', description:''}, ...response];
    }, error => {
      console.log(error);
    });
  }

  onStoreSelected(storeId: number){
    const params = this.tokenService.getTokenParams();
    params.storeId = storeId;
    params.pageNumber = 1;
    this.tokenService.setTokenParams(params);
    this.getTokens();
  }

  onProductTypeSelected(productTypeId: number){
    const params = this.tokenService.getTokenParams();
    params.productTypeId = productTypeId;
    params.pageNumber = 1;
    this.tokenService.setTokenParams(params);
    this.getTokens();

  }
  onSortSelected(sort: string){
    const params = this.tokenService.getTokenParams();
    params.sort = sort;
    this.tokenService.setTokenParams(params);
    this.getTokens();
  }
  onPageChanged(event: any){
    const params = this.tokenService.getTokenParams();

    if (params.pageNumber !== event){
      params.pageNumber = event;
      this.tokenService.setTokenParams(params);
      this.getTokens(true);
    }
  }

  onSearch(){
    const params = this.tokenService.getTokenParams();

    params.search = this.searchValue.nativeElement.value;
    params.pageNumber = 1;
    this.tokenService.setTokenParams(params);
    this.getTokens();
  }
  onReset(){
    this.searchValue.nativeElement.value = '';
    this.tokenParams = new TokenParams();
    this.tokenService.setTokenParams(this.tokenParams);
    this.getTokens();
  }

}
