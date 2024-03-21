import { Component, EventEmitter, Input, Output } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { circulatingSupplyValidator } from '../add-coin-form/invalidCirculatingSupply';
import { CoinService } from '../coin.service';
import { Cryptocurrency } from 'src/models/Cryptocurrency';


@Component({
  selector: 'app-edit-coin-form',
  templateUrl: './edit-coin-form.component.html',
  styleUrls: ['./edit-coin-form.component.css']
})
export class EditCoinFormComponent {


  @Input() coin!: Cryptocurrency;
  @Output() coinUpdated: EventEmitter<Cryptocurrency> = new EventEmitter<Cryptocurrency>();
  @Output() editCanceled: EventEmitter<void> = new EventEmitter<void>();

  constructor(private coinService: CoinService){}



  coinForm = new FormGroup({
    coinName: new FormControl('', [Validators.required]),
    coinSymbol: new FormControl('', [Validators.required]),
    coinCirulatingSupply: new FormControl('', [Validators.required, Validators.min(0), circulatingSupplyValidator]),
    coinTotalSupply: new FormControl('', [Validators.required, Validators.min(0), circulatingSupplyValidator]),
  });

  ngOnChanges() {
    if (this.coin) {
      this.coinForm.patchValue({
        coinName: this.coin.name,
        coinSymbol: this.coin.symbol,
        coinCirulatingSupply: this.coin.circulatingSupply.toString(),
        coinTotalSupply: this.coin.totalSupply.toString()
        });
    }
  }

  updateCoin() {

    const id = this.coin.id;
    const name = this.coinForm.get('coinName')!.value as string;
    const symbol = this.coinForm.get('coinSymbol')!.value as string;
    const circulatingSupplyValue = this.coinForm.get('coinCirulatingSupply')!.value;
    const totalSupplyValue = this.coinForm.get('coinTotalSupply')!.value;

    const circulatingSupply = circulatingSupplyValue ? parseFloat(circulatingSupplyValue) : null;
    const totalSupply = totalSupplyValue ? parseFloat(totalSupplyValue) : null;

    if (circulatingSupply != null && totalSupply != null && !isNaN(circulatingSupply) && !isNaN(totalSupply)) {
      const updatedCoin = new Cryptocurrency(id, name, symbol, circulatingSupply, totalSupply);
      this.coinService.updateCryptocurrency(id, updatedCoin).subscribe((data: any) => {
        this.coinUpdated.emit(data);
      });
    } else {
      console.error('Invalid circulatingSupply or totalSupply value.');
    }
  }

  editCancelClicked(){
    this.editCanceled.emit();
  }

}
