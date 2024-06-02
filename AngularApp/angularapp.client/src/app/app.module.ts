import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ProductsComponent } from './products/products.component';
import { NewProductComponent } from './products/new-product/new-product.component';
import { ProductsListComponent } from './products/products-list/products-list.component';
import { StoresComponent } from './stores/stores.component';
import { StoreProductsComponent } from './store-products/store-products.component';
import { StoreProductsListComponent } from './store-products/store-products-list/store-products-list.component';
import { NewStoreProductComponent } from './store-products/new-store-product/new-store-product.component';
import { UtilComponent } from './util/util.component';
import { InputComponent } from './util/input/input.component';
import { SelectComponent } from './util/select/select.component';

@NgModule({
  declarations: [
    AppComponent,
    ProductsComponent,
    NewProductComponent,
    ProductsListComponent,
    StoresComponent,
    StoreProductsComponent,
    StoreProductsListComponent,
    NewStoreProductComponent,
    UtilComponent,
    InputComponent,
    SelectComponent,
  ],
  imports: [
    BrowserModule, 
    HttpClientModule,
    AppRoutingModule,
    FormsModule,
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
