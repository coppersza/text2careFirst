import { Component, Input, OnInit } from '@angular/core';
import { IStore } from 'src/app/shared/models/store';

@Component({
  selector: 'app-shop-details',
  templateUrl: './shop-details.component.html',
  styleUrls: ['./shop-details.component.scss']
})
export class ShopDetailsComponent implements OnInit {
  @Input() store: IStore;

  constructor() { }

  ngOnInit(): void {
  }

}
