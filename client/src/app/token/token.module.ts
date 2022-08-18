import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TokenComponent } from './token.component';
import { TokenItemComponent } from './token-item/token-item.component';
import { SharedModule } from '../shared/shared.module';



@NgModule({
  declarations: [
    TokenComponent,
    TokenItemComponent
  ],
  imports: [
    CommonModule,
    SharedModule
  ],
  exports: [
    TokenComponent
  ]
})
export class TokenModule { }
