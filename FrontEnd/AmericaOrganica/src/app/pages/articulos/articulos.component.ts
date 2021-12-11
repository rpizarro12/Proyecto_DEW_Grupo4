import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Params } from '@angular/router';
import { ArticleService } from 'src/app/services/article.service';
import { ProductsService } from 'src/app/services/products.service';

@Component({
  selector: 'app-articulos',
  templateUrl: './articulos.component.html',
  styleUrls: ['./articulos.component.scss']
})
export class ArticulosComponent implements OnInit {

  article:any=[];

  constructor(private readonly ps:ProductsService, private ar:ActivatedRoute, private cart:ArticleService) { }

  _getArticleById(id:number){
    this.ps._getProducts().subscribe((rest:any)=>{
      this.article=rest.data.filter((item:{id:number})=>item.id==id);
      console.log(this.article);
    })
  }

  _be_getArticleById(id:number){
    this.ps._be_getProducts().subscribe((rest:any)=>{
      this.article=rest.data.filter((item:{idproducto:number})=>item.idproducto==id);
      //console.log(this.article);
    })
  }

  _addToCart(){
    this.cart._addArticleToCart(this.article);
    //console.log(this.cart.itemCart);
  }

  _deleteToCart(){
    this.cart._deleteArticleToCart(this.article);
    console.log(this.cart.itemCart);
  }
  

  ngOnInit(): void {
    this.ar.params.subscribe((params:Params)=>{
      if(params.id){
        this._be_getArticleById(params.id);
      }
    })       
  }

}
