import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Params } from '@angular/router';
import { ProductsService } from 'src/app/services/products.service';

@Component({
  selector: 'app-articulos',
  templateUrl: './articulos.component.html',
  styleUrls: ['./articulos.component.scss']
})
export class ArticulosComponent implements OnInit {

  article:any=[];

  constructor(private readonly ps:ProductsService, private ar:ActivatedRoute) { }

  _getArticleById(id:number){
    this.ps._getProducts().subscribe((rest:any)=>{
      this.article=rest.data.filter((item:{id:number})=>item.id==id);
      console.log(this.article);
    })
  }

  _be_getArticleById(id:number){
    this.ps._be_getProducts().subscribe((rest:any)=>{
      this.article=rest.data.filter((item:{idproducto:number})=>item.idproducto==id);
      console.log(this.article);
    })
  }

  
  ngOnInit(): void {
    this.ar.params.subscribe((params:Params)=>{
      if(params.id){
        this._be_getArticleById(params.id);
      }
    })    
  }

}
