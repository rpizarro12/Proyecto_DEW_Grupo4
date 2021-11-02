import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { BlogComponent } from './pages/blog/blog.component';
import { CarritoComponent } from './pages/carrito/carrito.component';
import { ContactanosComponent } from './pages/contactanos/contactanos.component';
import { DondeestamosComponent } from './pages/dondeestamos/dondeestamos.component';
import { HomeComponent } from './pages/home/home.component';
import { NosotrosComponent } from './pages/nosotros/nosotros.component';
import { RecetasComponent } from './pages/recetas/recetas.component';
import { TiendaComponent } from './pages/tienda/tienda.component';

const routes: Routes = [
  {path: 'home', component: HomeComponent},
  {path: 'blog', component: BlogComponent},
  {path: 'carrito', component: CarritoComponent},
  {path: 'contactanos', component: ContactanosComponent},
  {path: 'dondeestamos', component: DondeestamosComponent},
  {path: 'nosotros', component: NosotrosComponent},
  {path: 'recetas', component: RecetasComponent},
  {path: 'tienda', component: TiendaComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
