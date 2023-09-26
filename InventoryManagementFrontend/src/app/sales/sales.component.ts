import { Component } from '@angular/core';
import { Sale } from '../sale';
import { ProductService } from '../product.service';

@Component({
  selector: 'app-sales',
  templateUrl: './sales.component.html',
})
export class SaleComponent {
  sale: Sale = { ProductId: 0, Quantity: 0, SaleDate: new Date() };

  constructor(private saleService: ProductService) {}

  recordSale() {
    this.saleService.recordSale(this.sale).subscribe(
      response => {
        console.log('Sale recorded successfully', response);
        // Optionally, you can reset the form or perform other actions
      },
      error => {
        console.error('Error recording sale', error);
      }
    );
  }
}
