import { Component, EventEmitter, Output } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { DeleteManyProductsArgs, Product } from '../product.model';

interface ProductViewModel {
  productId: number;
  name: string;
  tags: string;
  isSelected: boolean;
}

@Component({
  selector: 'app-products-list',
  templateUrl: './products-list.component.html',
  styleUrls: ['./products-list.component.css', '../products.component.css', '../../app.component.css']
})

export class ProductsListComponent {
  products: ProductViewModel[] = [];
  isDeleteButtonEnabled = false;

  constructor(private http: HttpClient) {
  }

  ngOnInit() {
    this.getProducts();
  }

  getProducts() {
    this.http.get<Product[]>('/api/Products').subscribe(
      (result) => {
        this.products = 
          result.map(p => 
            <ProductViewModel> { 
              productId: p.productId,
              name: p.name, 
              tags: p.tags.map(t => t.value).join(", "),
              isSelected: false,
            }
          );
      },
      (error) => {
        console.error(error);
      }
    );
  }

  updateDeleteButtinStatus() {
    this.isDeleteButtonEnabled = this.products.some(p => p.isSelected);
  }

  selectionChanged(product: ProductViewModel) {
    product.isSelected = !product.isSelected;
    this.updateDeleteButtinStatus();
  }

  deleteSelected() {
    this.isDeleteButtonEnabled = false;
    let deleteManyArgs: DeleteManyProductsArgs = {
      productIds: 
        this.products
        .filter(p => p.isSelected)
        .map(p => p.productId!)
    }
    this.http.post<DeleteManyProductsArgs>("/api/Products/DeleteMany", deleteManyArgs).subscribe(
      response => this.getProducts(),
      error => console.log(error),
      () => this.updateDeleteButtinStatus()
    );
  }
}
