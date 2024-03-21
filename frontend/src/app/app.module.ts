import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';


import { AppComponent } from './app.component';
import { CoinTrackerModule } from './coin-tracker/coin-tracker.module';

@NgModule({
  declarations: [
    AppComponent,
  ],
  imports: [
    BrowserModule,
    CoinTrackerModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
