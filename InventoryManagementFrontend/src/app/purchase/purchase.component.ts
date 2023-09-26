import { Component } from '@angular/core';
import { Purchase } from '../purchase';
import { ProductService } from '../product.service';
@Component({
  selector: 'app-purchases',
  templateUrl: './purchases.component.html',
})
export class PurchasesComponent {

  constructor(private purchasesService: ProductService) {}
}
