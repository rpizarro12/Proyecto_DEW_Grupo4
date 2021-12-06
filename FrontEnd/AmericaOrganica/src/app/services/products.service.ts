import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class ProductsService {

  constructor(private readonly http: HttpClient) { }

  _getProducts(){
    return this.http.get('/api/project/GetProject');
  }

  _be_getProducts(){
    return this.http.get('https://localhost:44309/api/product/getproducts');
  }
}
