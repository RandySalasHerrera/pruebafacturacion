import { PagesComponent } from './pages.component';

import { RouterModule, Routes } from '@angular/router';
import { ClienteComponent } from './cliente/cliente.component';
import { ProductoComponent } from './producto/producto.component';
import { FacturaComponent } from './factura/factura.component';
import { DetalleComponent } from './detalle/detalle.component';
import { InformeComponent } from './informe/informe.component';

const PagesRotes: Routes = [
  {
    path: '',
    component: PagesComponent,
 //   canActivate: [ LoginGuardGuard ],
    children: [
   //   { path: 'dashboard', component: DashboardComponent , data: { titulo: 'Dashboard' } },
      { path: 'cliente', component: ClienteComponent , data: { titulo: 'Cliente' } },
      { path: 'producto', component: ProductoComponent , data: { titulo: 'Producto' } },
      { path: 'factura', component: FacturaComponent , data: { titulo: 'Factura' } },
      { path: 'detalle', component: DetalleComponent , data: { titulo: 'Detalle' } },
      { path: 'informe', component: InformeComponent , data: { titulo: 'Informe' } },
      { path: '', redirectTo: '/cliente', pathMatch: 'full' },
    ]
  }
];



export const PAGES_ROUTES = RouterModule.forRoot(PagesRotes, { useHash: true })
