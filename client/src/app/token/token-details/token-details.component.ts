import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { IToken } from 'src/app/shared/models/token';
import { TokenService } from '../token.service';
import { BreadcrumbService } from 'xng-breadcrumb';

@Component({
  selector: 'app-token-details',
  templateUrl: './token-details.component.html',
  styleUrls: ['./token-details.component.scss']
})
export class TokenDetailsComponent implements OnInit {
  token: IToken;

  constructor(
    private tokenService: TokenService,
    private activatedRoute: ActivatedRoute,
    private breadCrumbService: BreadcrumbService) {
      this.breadCrumbService.set('@tokenDetails', ' ');
    }

  ngOnInit(): void {
    this.loadToken();
  }

  loadToken(){
    this.tokenService.getToken(+this.activatedRoute.snapshot.paramMap.get('id')).subscribe(token => {
      this.token = token;
      this.breadCrumbService.set('@tokenDetails', token.tokenName);
    }, error => {
      console.log(error);
    });
  }

}
