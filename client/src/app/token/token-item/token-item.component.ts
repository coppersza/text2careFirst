import { Component, Input, OnInit } from '@angular/core';
import { IToken } from 'src/app/shared/models/token';

@Component({
  selector: 'app-token-item',
  templateUrl: './token-item.component.html',
  styleUrls: ['./token-item.component.scss']
})
export class TokenItemComponent implements OnInit {
  @Input() token: IToken;

  constructor() { }

  ngOnInit(): void {
  }

}
