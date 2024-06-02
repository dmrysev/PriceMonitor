import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { StoreProduct } from '../store-product.model';

interface StoreProductViewModel {
  storeProductId: number;
  storeId: number;
  storeName: string;
  productId: number;
  productName: string;
  apiString: string;
  isSelected: boolean;
}

@Component({
  selector: 'app-store-products-list',
  templateUrl: './store-products-list.component.html',
  styleUrls: ['./store-products-list.component.css', '../../app.component.css']
})
export class StoreProductsListComponent {
  storeProducts: StoreProductViewModel[] = []
  
  constructor(private http: HttpClient) {
  }

  ngOnInit() {
    this.getStoreProducts();
  }

  getStoreProducts() {
    this.http.get<StoreProduct[]>('/api/StoreProducts').subscribe(
      (result) => {
        this.storeProducts = 
          result.map(p => 
            <StoreProductViewModel> { 
              storeProductId: p.storeProductId,
            }
          );
      },
      (error) => {
        console.error(error);
      }
    );
  }

  selectionChanged(storeProduct: StoreProductViewModel) {}

}
