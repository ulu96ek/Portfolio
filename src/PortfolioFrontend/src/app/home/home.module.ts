import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { HomeRoutingModule } from './home-routing.module';
import { HomeComponent } from './home.component';
import { SharedModule } from '../shared/shared.module';

@NgModule({
  imports: [
    CommonModule,
    HomeRoutingModule,
    SharedModule.forRoot()
  ],
  declarations: [
    HomeComponent
  ],
  exports: [
    HomeComponent
  ]
})

export class HomeModule {
  constructor() {
  }
}
