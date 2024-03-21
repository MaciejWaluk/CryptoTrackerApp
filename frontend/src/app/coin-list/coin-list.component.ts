import { Component, OnInit } from '@angular/core';
import { Cryptocurrency } from 'src/models/Cryptocurrency';
import { CoinService } from '../coin.service';

@Component({
  selector: 'app-coin-list',
  templateUrl: './coin-list.component.html',
  styleUrls: ['./coin-list.component.css']
})
export class CoinListComponent implements OnInit{

  cryptocurrencies: Cryptocurrency[] = [];
  isEditing: boolean = false;
  editCoinData: Cryptocurrency | null = null;


  constructor(private coinService: CoinService){}
  

  ngOnInit(): void {
    this.coinService.getCryptocurrencies().subscribe((data: any) => {
      this.cryptocurrencies = data;
    })
  }

  handleCoinAdded(data: any){
    this.cryptocurrencies.push(data);
  }
  handleCoinDeleted(data:any){
    this.cryptocurrencies = this.cryptocurrencies.filter((coin) => coin.id !== data.id);
  }

  handleEditClicked(data: any){
    this.editCoinData = data;
    this.isEditing = true;
  }

  handleCoinUpdated(updatedCoin: Cryptocurrency) {
    const index = this.cryptocurrencies.findIndex(coin => coin.id === updatedCoin.id);
    if (index !== -1) {
        this.cryptocurrencies[index] = updatedCoin;
    }
    this.isEditing = false;
  }

  handleEditCanceled(){
    this.isEditing = false;
    this.editCoinData = null;
  }


}
