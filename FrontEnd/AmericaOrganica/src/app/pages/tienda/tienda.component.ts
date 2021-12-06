import { Component, OnInit } from '@angular/core';
import { ProductsService } from 'src/app/services/products.service';

@Component({
  selector: 'app-tienda',
  templateUrl: './tienda.component.html',
  styleUrls: ['./tienda.component.scss']
})
export class TiendaComponent implements OnInit {

  products:any=[];

  constructor(private readonly ps:ProductsService) { }

  _getProducts(){
    this.ps._getProducts().subscribe((rest:any) => {
      this.products=rest.data;
      //console.log(this.products);
    })
  }

  _be_getProducts(){
    this.ps._be_getProducts().subscribe((rest:any)=>{
      this.products=rest.data;
      console.log(this.products);
    })
  }

  ngOnInit(): void {
    //this._getProducts();
    this._be_getProducts();
  }

}
