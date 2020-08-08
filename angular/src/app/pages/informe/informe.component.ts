import { AppConfirmService } from './../../service/app-confirm/app-confirm.service';
import { FormGroup, FormBuilder } from '@angular/forms';
import { OnInit, Component } from '@angular/core';
import { MatDialog, MatDialogRef } from '@angular/material/dialog';
import { ToastrService } from 'ngx-toastr';
import { PageEvent } from '@angular/material/paginator';
import { InformeService } from 'src/app/service/informe/informe.services';

@Component({
  selector: 'app-informe',
  templateUrl: './informe.component.html',
  styles: []
})
export class InformeComponent implements OnInit {

  public cargando = false;
  public usuarios = [];
  public ultimacompra = [];
  public alertaproducto = [];
  public totalvendido = [];
  public totalRegistros = 0;
  public itemForm: FormGroup;
  public hidebuscador = false;
  public hideInforme = false;
  public hidetabla = true;
  public busy: Promise<any>;
  public InformeText = 'Informe';
  public AdministradorText = 'Administrador';

  constructor(
    private fb: FormBuilder,
    private _Informe: InformeService,
    public dialog: MatDialog,
    private _toastr: ToastrService,
  ) { }

  ngOnInit() {
    this.buildItemForm();
    this.loadList();
  }

  buildItemForm() {
    this.itemForm = this.fb.group(
      {
          filter: null,
      }
    );
  }

  loadList() {
    this.cargando = true;
    this.hidetabla = true;
    this.hideInforme = false;
    this.clienteNoMayores();
    this.clientesUltimaCompra();
    this.alertaProducto();
    this.listaTotalVendidoProducto();
  }

  clienteNoMayores() {
    return this._Informe
      .getclientesnomayores()
      .toPromise()
      .then(data => {
        this.usuarios = data.data;
        this.cargando = false;
      })
      .catch(e => {
        this._toastr.warning(e.message);
      });
  }

  clientesUltimaCompra() {
    return this._Informe
      .getclientesultimacompra()
      .toPromise()
      .then(data => {
        this.ultimacompra = data.data;
        this.cargando = false;
      })
      .catch(e => {
        this._toastr.warning(e.message);
      });
  }

  alertaProducto() {
    return this._Informe
      .getalertaproducto()
      .toPromise()
      .then(data => {
        this.alertaproducto = data.data;
        this.cargando = false;
      })
      .catch(e => {
        this._toastr.warning(e.message);
      });
  }

  listaTotalVendidoProducto() {
    return this._Informe
      .getvalorvendidoproducto()
      .toPromise()
      .then(data => {
        this.totalvendido = data.data;
        this.cargando = false;
      })
      .catch(e => {
        this._toastr.warning(e.message);
      });
  }


}
