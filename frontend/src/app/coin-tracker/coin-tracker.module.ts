import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CoinListItemComponent } from './coin-list-item/coin-list-item.component';
import { AddCoinFormComponent } from './add-coin-form/add-coin-form.component';
import { CoinListComponent } from './coin-list/coin-list.component';
import { EditCoinFormComponent } from './edit-coin-form/edit-coin-form.component';



import { HttpClientModule } from '@angular/common/http';
import { ReactiveFormsModule } from '@angular/forms';



@NgModule({
  declarations: [
    CoinListItemComponent,
    AddCoinFormComponent,
    CoinListComponent,
    EditCoinFormComponent,

  ],
  imports: [
    CommonModule,
    HttpClientModule,
    ReactiveFormsModule
  ],
  exports: [
    CoinListItemComponent,
    AddCoinFormComponent,
    CoinListComponent,
    EditCoinFormComponent,
  ]
})
export class CoinTrackerModule { }
