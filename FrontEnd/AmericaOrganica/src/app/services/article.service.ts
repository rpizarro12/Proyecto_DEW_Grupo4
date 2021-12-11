import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class ArticleService {

  itemCart:any=[];
  cartTotal:number=0;

  constructor(private readonly http:HttpClient) { }

  _getItemsCart(){
    this.itemCart;
  }
  
  _addArticleToCart(articulo:any){
    this.itemCart.push(articulo);  
    this.cartTotal+=articulo[0].precio;
    //console.log(articulo[0].precio.toFixed(2));     
    alert("Se añadio el producto al carrito");
  }

  _clearCart(){
    this.itemCart.splice(0);
  }

  

  _deleteArticleToCart(idproducto:number){
    for(let i=0;i<this.itemCart.length;i++){
      if(this.itemCart[i][0].idproducto==idproducto){        
        this.cartTotal-=this.itemCart[i][0].precio;
        this.itemCart.splice(i,1);
        
      }
    }
  }
}
