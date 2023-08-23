import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ProductlistComponent } from './productlist/productlist.component';
import { ProductUpdateComponent } from './product-update/product-update.component';

const routes: Routes = [
  { path: 'products', component: ProductlistComponent },
  { path: 'update-product/:id', component: ProductUpdateComponent },
  { path: '', redirectTo: '/products', pathMatch: 'full' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {}
