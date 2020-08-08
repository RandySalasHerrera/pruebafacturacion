import { AppConfirmService } from './../../service/app-confirm/app-confirm.service';
import { FormGroup, FormBuilder } from '@angular/forms';
import { OnInit, Component } from '@angular/core';
import { MatDialog, MatDialogRef } from '@angular/material/dialog';
import { ToastrService } from 'ngx-toastr';
import { PageEvent } from '@angular/material/paginator';
import { ClienteService } from 'src/app/service/cliente/cliente.services';
import { ClientepopupComponent } from './clientepopup.component';

@Component({
  selector: 'app-cliente',
  templateUrl: './cliente.component.html',
  styles: []
})
export class ClienteComponent implements OnInit {

  public cargando = false;
  public usuarios = [];
  public totalRegistros = 0;
  public tituloModal = 'Crear';
  public itemForm: FormGroup;
  public hidebuscador = false;
  public hideCliente = false;
  public hidetabla = true;
  public busy: Promise<any>;
  public ClienteText = 'Cliente';
  public AdministradorText = 'Administrador';

  constructor(
    private fb: FormBuilder,
    private _Cliente: ClienteService,
    public dialog: MatDialog,
    private _confirmService: AppConfirmService,
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
    this.hideCliente = false;
    const formValuesCopy = Object.assign({}, this.itemForm.value);
    return this._Cliente
      .getClienteList(formValuesCopy)
      .toPromise()
      .then(data => {
        this.totalRegistros = data.total;
        this.usuarios = data.data;
        this.cargando = false;
      })
      .catch(e => {
        this._toastr.warning(e.message);
      });
  }

  openPopUp(inputData: any, isNew?) {
    const title = isNew ? 'Crear registro' : 'Actualizar registro';
    const id = inputData.id;
    if (!isNew) {
      this._Cliente
        .getClienteById(id)
        .toPromise()
        .then(data => {
          inputData = data;
          this.popupManager(data.data, title, id);
        })
        .catch(error => {
          this._toastr.warning(error.message);
        });
    } else {
      this.popupManager(inputData, title, null);
    }
  }

  popupManager(rowData: any, title: string, id?: any) {
    const dialogRef: MatDialogRef<ClientepopupComponent> = this.dialog.open(
      ClientepopupComponent,
      {
        width: '720px',
        disableClose: false,
        data: {
          title: title,
          payload: rowData,
          id: id
        }
      }
    );

    dialogRef.afterClosed().subscribe(res => {
      if (!res) {
        return;
      }

      this.loadList();
    });
  }

  delete(row: any) {

    this._confirmService
      .confirm({ title: 'Confirmacion!', message: `Eliminar ${row.nombre}?` })
      .subscribe(res => {
        if (res) {
          const formValuesCopy = Object.assign({}, this.itemForm.value);
          this._Cliente
            .deleteCliente(formValuesCopy, row.id)
            .toPromise()
            .then(data => {
              this.busy = this.loadList();
              this._toastr.success(`${row.descripcion} se ha eliminado!`);
              //    this._loader.close();
            })
            .catch(error => {
              //    this._loader.close();
            });
        }
      });
  }

  paginator(event: PageEvent) {
    console.log(event);
    this.itemForm.controls['PageNo'].setValue(event.pageIndex + 1);
    this.itemForm.controls['PageSize'].setValue(event.pageSize);
    this.loadList();
  }

}
