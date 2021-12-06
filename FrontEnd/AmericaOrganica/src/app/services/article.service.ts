import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class ArticleService {

  constructor(private readonly http:HttpClient) { }

  _getArticle(){
    return this.http.get('/api/apartment/GetApartments');
  }

  _be_getArticle(){
    return this.http.get('https://localhost:44309/api/product/getproducts');
  }
}
