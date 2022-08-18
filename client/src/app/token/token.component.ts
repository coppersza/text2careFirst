import { Component, OnInit } from '@angular/core';
import { IToken } from '../shared/models/token';
import { TokenService } from './token.service';

@Component({
  selector: 'app-token',
  templateUrl: './token.component.html',
  styleUrls: ['./token.component.scss']
})
export class TokenComponent implements OnInit {
  tokens: IToken[];

  constructor(private tokenService: TokenService) { }

  ngOnInit(): void {
    this.tokenService.getTokens().subscribe(response => {
      this.tokens = response.data;
    }, error => {
      console.log(error);
    });
  }

}
