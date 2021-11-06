import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HomeComponent } from './pages/home/home.component';
import { NosotrosComponent } from './pages/nosotros/nosotros.component';
import { RecetasComponent } from './pages/recetas/recetas.component';
import { BlogComponent } from './pages/blog/blog.component';
import { TiendaComponent } from './pages/tienda/tienda.component';
import { DondeestamosComponent } from './pages/dondeestamos/dondeestamos.component';
import { ContactanosComponent } from './pages/contactanos/contactanos.component';
import { CarritoComponent } from './pages/carrito/carrito.component';
import { LoginComponent } from './access/login/login.component';
import { ReactiveFormsModule } from '@angular/forms';
import { RegistroComponent } from './access/registro/registro.component';
import { ArticulosComponent } from './pages/articulos/articulos.component';
import { FavoritosComponent } from './pages/favoritos/favoritos.component';
import { QueofrecemosComponent } from './pages/queofrecemos/queofrecemos.component';
import { Impacto360Component } from './pages/impacto360/impacto360.component';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    NosotrosComponent,
    RecetasComponent,
    BlogComponent,
    TiendaComponent,
    DondeestamosComponent,
    ContactanosComponent,
    CarritoComponent,
    LoginComponent,
    RegistroComponent,
    ArticulosComponent,
    FavoritosComponent,
    QueofrecemosComponent,
    Impacto360Component
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    ReactiveFormsModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
