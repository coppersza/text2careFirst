import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TokenComponent } from './token.component';
import { TokenItemComponent } from './token-item/token-item.component';
import { SharedModule } from '../shared/shared.module';
import { TokenDetailsComponent } from './token-details/token-details.component';
import { TokenRoutingModule } from './token-routing.module';

@NgModule({
  declarations: [
    TokenComponent,
    TokenItemComponent,
    TokenDetailsComponent
  ],
  imports: [
    CommonModule,
    SharedModule,
    TokenRoutingModule
  ]
})
export class TokenModule { }
