import { ShareModule } from './../shared/shared.modules';
import { PagesComponent } from './pages.component';
import { NgModule } from '@angular/core';
import { PAGES_ROUTES } from './pages.routes';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { MatChipsModule } from '@angular/material/chips';
import { MatOptionModule, MatRippleModule } from '@angular/material/core';
import { MatDialogModule } from '@angular/material/dialog';
import { MatDividerModule } from '@angular/material/divider';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatGridListModule } from '@angular/material/grid-list';
import { MatIconModule, MatIconRegistry } from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';
import { MatListModule } from '@angular/material/list';
import { MatMenuModule } from '@angular/material/menu';
import { MatProgressBarModule } from '@angular/material/progress-bar';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { MatRadioModule } from '@angular/material/radio';
import { MatSelectModule } from '@angular/material/select';
import { MatSidenavModule } from '@angular/material/sidenav';
import { MatSlideToggleModule } from '@angular/material/slide-toggle';
import { MatTabsModule } from '@angular/material/tabs';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatTooltipModule } from '@angular/material/tooltip';
import { FlexLayoutModule } from '@angular/flex-layout';
import {MatPaginatorModule} from '@angular/material/paginator';
import { ClienteComponent } from './cliente/cliente.component';
import { ClientepopupComponent } from './cliente/clientepopup.component';
import {MatAutocompleteModule} from '@angular/material/autocomplete';
import { ProductopopupComponent } from './producto/Productopopup.component';
import { ProductoComponent } from './producto/producto.component';
import { FacturapopupComponent } from './factura/facturapopup.component';
import { FacturaComponent } from './factura/factura.component';
import { DetalleComponent } from './detalle/detalle.component';
import { DetallepopupComponent } from './detalle/detallepopup.component';
import { InformeComponent } from './informe/informe.component';

@NgModule({
  declarations: [
    PagesComponent,
    ClienteComponent,
    ClientepopupComponent,
    ProductoComponent,
    ProductopopupComponent,
    FacturaComponent,
    FacturapopupComponent,
    DetalleComponent,
    DetallepopupComponent,
    InformeComponent
  ], entryComponents: [
    ClientepopupComponent,
    ProductopopupComponent,
    FacturapopupComponent,
    DetallepopupComponent
  ],
  exports: [
    PagesComponent,
    ClienteComponent,
    ProductoComponent,
    FacturaComponent,
    DetalleComponent,
    InformeComponent
  ],
  imports: [
    CommonModule,
    PAGES_ROUTES,
    ShareModule,
    FormsModule,
    ReactiveFormsModule,
    MatDialogModule,
    MatInputModule,
    MatSlideToggleModule,
    MatFormFieldModule,
    MatDividerModule,
    MatChipsModule,
    MatSidenavModule,
    MatIconModule,
    MatOptionModule,
    MatSelectModule,
    MatMenuModule,
    MatGridListModule,
    MatTooltipModule,
    MatListModule,
    MatToolbarModule,
    MatProgressSpinnerModule,
    MatProgressBarModule,
    MatCardModule,
    MatRadioModule,
    MatCheckboxModule,
    MatPaginatorModule,
    MatButtonModule,
    MatRippleModule,
    MatTabsModule,
    FlexLayoutModule,
    MatAutocompleteModule,

  ]

})

export class PagesModules {}
