import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ProductsListComponent } from './products/products-list/products-list.component';
import { ProductsComponent } from './products/products.component';
import { NewProductComponent } from './products/new-product/new-product.component';
import { StoresComponent } from './stores/stores.component';
import { StoreProductsComponent } from './store-products/store-products.component';
import { NewStoreProductComponent } from './store-products/new-store-product/new-store-product.component';

const routes: Routes = [
  { path: "home", component: ProductsComponent, title: "Products" },
  { path: "products", component: ProductsComponent, title: "Products" },
  { path: "products/add", component: NewProductComponent, title: "Add new product" },
  { path: "stores", component: StoresComponent, title: "Stores" },
  { path: "store-products", component: StoreProductsComponent, title: "Store products" },
  { path: "store-products/add", component: NewStoreProductComponent, title: "Add new store product" },
  { path: "", redirectTo: "/home", pathMatch: "full" },
];
@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }