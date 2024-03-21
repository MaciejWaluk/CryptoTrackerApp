import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http'


import { AppComponent } from './app.component';
import { CoinListItemComponent } from './coin-list-item/coin-list-item.component';
import { AddCoinFormComponent } from './add-coin-form/add-coin-form.component';
import { ReactiveFormsModule } from '@angular/forms';
import { CoinListComponent } from './coin-list/coin-list.component';
import { EditCoinFormComponent } from './edit-coin-form/edit-coin-form.component';

@NgModule({
  declarations: [
    AppComponent,
    CoinListItemComponent,
    AddCoinFormComponent,
    CoinListComponent,
    EditCoinFormComponent,
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    ReactiveFormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
