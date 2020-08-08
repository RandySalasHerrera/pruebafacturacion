import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class SidebarService {

  menuadmin: any = [
    {
     titulo: 'Principal',
     icono:  'mdi mdi-gauge',
     submenu: [
       { titulo: 'Cliente ', url: '/cliente'},
       { titulo: 'Producto', url: '/producto'},
       { titulo: 'Factura ', url: '/factura'},
       { titulo: 'Detalle', url: '/detalle'},
     ]
    },
    {
      titulo: 'Informes',
      icono:  'mdi mdi-file-document',
      submenu: [
        { titulo: 'informe', url: '/informe'},
      ]
     }
  ];

  constructor(

  ) { }
}
