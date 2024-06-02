import { Product, ProductTag } from '../product.model';
import { InputField } from '../../util/input/input.component';

import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { UtilComponent } from '../../util/util.component';

@Component({
  selector: 'app-new-product',
  templateUrl: './new-product.component.html',
  styleUrls: ['./new-product.component.css', '../products.component.css', '../../app.component.css']
})
export class NewProductComponent {
  productName = new InputField("Product name");
  productTags = new InputField("Tags (comma separated)", false);
  formFields = [ this.productName, this.productTags ];

  constructor(private http: HttpClient, private router: Router) {
  }

  saveProduct() {
    if (!UtilComponent.validateFormFields(this.formFields)) return;
    let productTags =
      this.productTags.value
      .split(",")
      .map(s => s.trim())
      .filter(s => s !== "")
      .map(tag => <ProductTag> { value: tag } );
    let product: Product = { productId: 0, name: this.productName.value, tags: productTags };
    this.http.post<Product>("/api/Products", product).subscribe(
      (response: Product) => { 
        console.log(response);
        this.router.navigate(["/products"]);
      },
      (error) => { 
        console.error(error);
      }
    );
  }
}
