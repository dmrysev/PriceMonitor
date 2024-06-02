import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { Store } from './stores.model';

interface StoreViewModel {
  storeId: number;
  name: string;
}

@Component({
  selector: 'app-stores',
  templateUrl: './stores.component.html',
  styleUrls: ['./stores.component.css', '../app.component.css']
})
export class StoresComponent {
  stores: Store[] = [];
  
  constructor(private http: HttpClient) {
  }

  ngOnInit() {
    this.getStores();
  }

  getStores() {    
    this.http.get<Store[]>('/api/Stores').subscribe(
      (result) => {
        this.stores = 
          result.map(s =>
            <StoreViewModel> { 
              storeId: s.storeId,
              name: s.name, 
            }
          );
      },
      (error) => {
        console.error(error);
      }
    );
  }

}
