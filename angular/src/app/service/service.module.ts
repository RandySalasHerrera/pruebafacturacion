import { DetalleService } from './detalle/detalle.services';
import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AppConfirmService } from './app-confirm/app-confirm.service';
import { AppComfirmComponent } from './app-confirm/app-confirm.component';
import { MatDialogModule } from '@angular/material/dialog';
import { FormsModule } from '@angular/forms';
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';
import { MatInputModule } from '@angular/material/input';
import { MatFormFieldModule } from '@angular/material/form-field';
import { FlexLayoutModule } from '@angular/flex-layout';
import { ToastrModule } from 'ngx-toastr';
import { SubirArchivoService } from './subir-archivo/subir-archivo.service';
import { ClienteService } from './cliente/cliente.services';
import { ProductoService } from './producto/producto.services';
import { FacturaService } from './factura/factura.services';
import { InformeService } from './informe/informe.services';

export const SERVICES = [
  AppConfirmService,
  SubirArchivoService,
  ClienteService,
  ProductoService,
  FacturaService,
  DetalleService,
  InformeService
];

const ENTRY_COMPONENTS = [
  AppComfirmComponent
];

const COMPONENTS = [
  AppComfirmComponent
];

@NgModule({
  imports: [
    CommonModule,
    HttpClientModule,
    MatDialogModule,
    FormsModule,
    MatIconModule,
    MatButtonModule,
    MatInputModule,
    MatFormFieldModule,
    FlexLayoutModule,
    ToastrModule.forRoot({
      timeOut: 5000,
      positionClass: 'toast-bottom-full-width',
      preventDuplicates: true
    }),

  ],
  providers: [
    ...SERVICES,
  ],
  entryComponents: [...ENTRY_COMPONENTS],
  declarations: [...COMPONENTS]
})
export class ServiceModule { }
