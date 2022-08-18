import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { IPagination } from './models/pagination';
import { IProduct } from './models/product';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {
  title = 'Text2Care';
  products: IProduct[] = [];

  constructor(private http: HttpClient){

  }

  ngOnInit(): void {
    this.http.get('https://localhost:5001/api/product')
      .subscribe((response: IPagination) => {
        this.products = response.data;
        console.log(response);
      }, error => {
        console.log(error);
      });
  }


}
