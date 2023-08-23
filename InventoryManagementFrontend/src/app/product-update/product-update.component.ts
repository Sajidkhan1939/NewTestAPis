import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ProductService } from '../product.service';
import { Product } from '../product';

@Component({
  selector: 'app-product-update',
  templateUrl: './product-update.component.html',
  styleUrls: ['./product-update.component.css']
})
export class ProductUpdateComponent implements OnInit {
  product: Product = { id: 0, name: '', quantity: 0 }; // Initialize with default values

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private productService: ProductService
  ) {}

  ngOnInit(): void {
    const productId = this.route.snapshot.paramMap.get('id');
    if (productId) {
      const productIdNumber = +productId; // Convert to number if needed
      this.productService.getProduct(productIdNumber).subscribe(product => {
        this.product = product;
      });
    }
  }

  updateProduct() {
    this.productService.updateProduct(this.product).subscribe(() => {
      console.log('Product updated successfully');
      this.router.navigate(['/products']); // Navigate back to product list
    });
  }
}
