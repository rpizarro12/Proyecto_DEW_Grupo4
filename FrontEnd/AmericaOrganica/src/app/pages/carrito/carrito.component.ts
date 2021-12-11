import { Component, OnInit } from '@angular/core';
import { ArticleService } from 'src/app/services/article.service';

@Component({
  selector: 'app-carrito',
  templateUrl: './carrito.component.html',
  styleUrls: ['./carrito.component.scss']
})
export class CarritoComponent implements OnInit {
  
  //cartTotal:number=0;
  constructor(public cart:ArticleService) { }

  _deleteToCart(id:number){
    this.cart._deleteArticleToCart(id);    
  }

  _getItemsCart(){
    this.cart._getItemsCart();    
    //console.log(this.cart.itemCart);
  }

  _confirmarCompra(){
    if(this.cart.cartTotal!=0)
    {    
    alert("Gracias por su compra!");
    this.cart._clearCart();
    this.cart.cartTotal=0;
    return;
    }
    alert("Añada productos a su carrito");
  }

  ngOnInit(): void {
    this._getItemsCart();    
    //console.log(this.cart.cartTotal.toFixed(2));
    
  }

}
