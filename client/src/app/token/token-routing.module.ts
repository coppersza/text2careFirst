import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { TokenComponent } from './token.component';
import { TokenDetailsComponent } from './token-details/token-details.component';

const routes: Routes = [
  {path: '', component: TokenComponent},
  {path: ':id', component: TokenDetailsComponent, data: {breadcrumb: {alias: 'tokenDetails'} } },
];

@NgModule({
  declarations: [],
  imports: [
    RouterModule.forChild(routes)
  ],
  exports: [
    RouterModule
  ]
})
export class TokenRoutingModule { }
