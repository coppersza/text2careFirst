import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { IToken } from 'src/app/shared/models/token';
import { TokenService } from '../token.service';

@Component({
  selector: 'app-token-details',
  templateUrl: './token-details.component.html',
  styleUrls: ['./token-details.component.scss']
})
export class TokenDetailsComponent implements OnInit {
  token: IToken;

  constructor(private tokenService: TokenService, private activatedRoute: ActivatedRoute) { }

  ngOnInit(): void {
    this.loadToken();
  }

  loadToken(){
    this.tokenService.getToken(+this.activatedRoute.snapshot.paramMap.get('id')).subscribe(token => {
      this.token = token;
    }, error => {
      console.log(error);
    });
  }

}
