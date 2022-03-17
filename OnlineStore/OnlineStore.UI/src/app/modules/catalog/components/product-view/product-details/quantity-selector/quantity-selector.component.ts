import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-quantity-selector',
  templateUrl: './quantity-selector.component.html',
  styleUrls: ['./quantity-selector.component.css']
})
export class QuantitySelectorComponent implements OnInit {

  constructor() { }

  quantitySelected : number = 1;
  ngOnInit(): void {
  }
  @Input()
  availableQuantity:number = 3;


  minus(){
    if(this.quantitySelected != 1){
      this.quantitySelected -= 1;
    }
  }

  plus(){
    if(this.quantitySelected < this.availableQuantity)
        this.quantitySelected += 1;
  }
}
