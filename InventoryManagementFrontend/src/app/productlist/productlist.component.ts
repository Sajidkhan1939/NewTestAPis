import { Component } from '@angular/core';
import { OnInit } from '@angular/core';
import { Product } from '../product';
import { ProductService } from '../product.service';
import { Router } from '@angular/router';


@Component({
  selector: 'app-productlist',
  templateUrl: './productlist.component.html',
  styleUrls: ['./productlist.component.css']
})
export class ProductlistComponent implements OnInit{
  products: Product[] = [];
  newProduct: Product = { id: 0, name: '', quantity: 0 };
  selectedProductId: number | null = null;
  selectedProduct: Product | null = null;

  constructor(private productService: ProductService,private router:Router) {}

  ngOnInit(): void {
    this.fetchProducts();
  }

  fetchProducts() {
    this.productService.getProducts().subscribe(products => {
      this.products = products;
    });
  }

  navigateToUpdateProduct(productId: number) {
    this.router.navigate(['/update-product', productId]);
  }
  addProduct() {
    this.productService.addProduct(this.newProduct).subscribe(() => {
      console.log('Product added successfully');
      this.fetchProducts(); // Refresh the product list
      this.newProduct = { id: 0, name: '', quantity: 0 }; // Reset form
    });
  }
    showUpdateForm(product: Product) {
    this.selectedProduct = { ...product };
  }
  deleteProduct(productId: number) {
    this.productService.deleteProduct(productId).subscribe(() => {
      console.log('Product deleted successfully');
      this.fetchProducts(); // Refresh the product list
    });
  }
 // navigateToUpdate(productId: number) {
  //  this.router.navigate(['/update-product', productId]);
 // }
 //updateProduct(product: Product) {
  //this.selectedProductId = product.id;
   //}
  
}
