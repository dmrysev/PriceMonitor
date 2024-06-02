import { Product } from '../../products/product.model';
import { Store } from '../../stores/stores.model';
import { SelectField } from '../../util/select/select.component';
import { UtilComponent } from '../../util/util.component';
import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-new-store-product',
  templateUrl: './new-store-product.component.html',
  styleUrls: ['./new-store-product.component.css', '../../app.component.css']
})
export class NewStoreProductComponent {
  productsSelectField = new SelectField<Product, number>("Products", [], p => p.productId, p => p.name);
  storesSelectField = new SelectField<Store, number>("Stores", [], s => s.storeId, s => s.name);
  selectedStoreId?: number;
  formFields = [ this.productsSelectField, this.storesSelectField ];

  constructor(private http: HttpClient) {
  }

  ngOnInit() {
    this.getProducts();
    this.getStores();
  }

  getProducts() {
    this.http.get<Product[]>('/api/Products').subscribe(
      (result) => {
        this.productsSelectField.items = result;
      },
      (error) => {
        console.error(error);
      }
    );
  }

  getStores() {
    this.http.get<Store[]>('/api/Stores').subscribe(
      (result) => {
        this.storesSelectField.items = result;
      },
      (error) => {
        console.error(error);
      }
    );
  }

  save() {
    if(!UtilComponent.validateFormFields(this.formFields)) return;
  }

}
