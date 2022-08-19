



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
  tokenParams = new TokenParams();
  totalCount: number;

  sortOptions = [
    {name: 'Alphabetical', value: 'name'},
    {name: 'Date: Low to High', value: 'dateAsc'},
    {name: 'Date: High to Low ', value: 'dateDesc'}
  ];


  constructor(private tokenService: TokenService) { }

  ngOnInit(): void {
    this.getTokens();
    this.getStores();
    this.getProductTypes();
  }
  getTokens(){
    this.tokenService.getTokens(this.tokenParams).subscribe(response => {
        this.tokens = response.data;
        this.tokenParams.pageNumber = response.pageIndex;
        this.tokenParams.pageSize = response.pageSize;
        this.totalCount = response.count;
      }, error => {
        console.log(error);
      });
  }
  getStores(){
    this.tokenService.getStores().subscribe(response => {
      this.stores = [{id: 0, storeName: 'All', country:'', description:'', imageUrl:''}, ...response];
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
    this.tokenParams.storeId = storeId;
    this.tokenParams.pageNumber = 1;
    this.getTokens();
  }
  onProductTypeSelected(productTypeId: number){
    this.tokenParams.productTypeId = productTypeId;
    this.tokenParams.pageNumber = 1;
    this.getTokens();
  }
  onSortSelected(sort: string){
    this.tokenParams.sort = sort;
    this.getTokens();
  }
  onPageChanged(event: any){
    if (this.tokenParams.pageNumber !== event){
      this.tokenParams.pageNumber = event;
      this.getTokens();
    }
  }
  onSearch(){
    this.tokenParams.search = this.searchValue.nativeElement.value;
    this.tokenParams.pageNumber = 1;
    this.getTokens();
  }
  onReset(){
    this.searchValue.nativeElement.value = '';
    this.tokenParams = new TokenParams();
    this.getTokens();
  }

}
