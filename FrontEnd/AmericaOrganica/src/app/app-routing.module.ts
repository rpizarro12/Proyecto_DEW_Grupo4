import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './access/login/login.component';
import { RegistroComponent } from './access/registro/registro.component';
import { ArticulosComponent } from './pages/articulos/articulos.component';
import { BlogComponent } from './pages/blog/blog.component';
import { CarritoComponent } from './pages/carrito/carrito.component';
import { ContactanosComponent } from './pages/contactanos/contactanos.component';
import { DondeestamosComponent } from './pages/dondeestamos/dondeestamos.component';
import { FavoritosComponent } from './pages/favoritos/favoritos.component';
import { HomeComponent } from './pages/home/home.component';
import { Impacto360Component } from './pages/impacto360/impacto360.component';
import { NosotrosComponent } from './pages/nosotros/nosotros.component';
import { QueofrecemosComponent } from './pages/queofrecemos/queofrecemos.component';
import { RecetasComponent } from './pages/recetas/recetas.component';
import { TiendaComponent } from './pages/tienda/tienda.component';

const routes: Routes = [
  {path:'',redirectTo:'home',pathMatch:'full'},
  {path: 'home', component: HomeComponent},
  {path: 'blog', component: BlogComponent},
  {path: 'carrito', component: CarritoComponent},
  {path: 'contactanos', component: ContactanosComponent},
  {path: 'dondeestamos', component: DondeestamosComponent},
  {path: 'nosotros', component: NosotrosComponent},
  {path: 'que-ofrecemos', component:QueofrecemosComponent},
  {path: 'impacto-360', component:Impacto360Component},
  {path: 'recetas', component: RecetasComponent},
  {path: 'tienda', component: TiendaComponent},
  {path: 'login', component: LoginComponent},
  {path: 'registro', component: RegistroComponent},
  {path: 'favoritos', component: FavoritosComponent},
  {path: 'articulos/:id', component: ArticulosComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
