import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Product } from './product';
import { HttpResponse } from '@angular/common/http';
import { Sale } from './sale';
import { Purchase } from './purchase';
@Injectable({
  providedIn: 'root'
})
export class ProductService {
  private baseUrl = 'https://localhost:7138/api/products';

  constructor(private http: HttpClient) { }

  getProducts(): Observable<Product[]> {
    return this.http.get<Product[]>(`${this.baseUrl}`);
  }
  getProduct(productId: number): Observable<Product> {
    const url = `${this.baseUrl}/${productId}`;
    return this.http.get<Product>(url);
  }
  updateProduct(product: Product): Observable<Product> {
    const url = `${this.baseUrl}/${product.id}`;
    return this.http.put<Product>(url, product);
  }
  addProduct(product: Product): Observable<Product> {
    return this.http.post<Product>(`${this.baseUrl}`, product);
  }
  deleteProduct(productId: number): Observable<void> {
    const url = `${this.baseUrl}/${productId}`;
    return this.http.delete<void>(url);
  }
  recordSale(sales: Sale): Observable<Sale> {
    return this.http.post<Sale>(`${this.baseUrl}/RecordSale`, sales);
  }
  
  trackPurchase(purchased: Purchase): Observable<Purchase> {
    return this.http.post<Purchase>(`${this.baseUrl}/TrackPurchase`, purchased);
  }

}
