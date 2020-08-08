import { OnInit, Inject, Component, ViewChild } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { ClienteService } from 'src/app/service/cliente/cliente.services';

import Swal from 'sweetalert2';
@Component({
  selector: 'app-clientepopup',
  templateUrl: './clientepopup.component.html',
  styles: []
})
export class ClientepopupComponent implements OnInit {

  public itemForm: FormGroup;
  public isSaving = false;


  constructor(
    @Inject(MAT_DIALOG_DATA) public data: any,
    public _dialogRef: MatDialogRef<ClientepopupComponent>,
    private fb: FormBuilder,
    private _Cliente: ClienteService

  ) {

  }

  ngOnInit() {
    this.buildItemForm(this.data.payload !== undefined ? this.data.payload : this.data.payload);
  }

  buildItemForm(Cliente: any) {
    this.itemForm = this.fb.group(
      {
        nombre: [Cliente.nombre || null, Validators.required],
        apellidos: [Cliente.apellidos || null, Validators.required],
        direccion: [Cliente.direccion || null, Validators.required],
        telefono: [Cliente.telefono || null, Validators.required],
        edad: [Cliente.edad || null, Validators.required],
      }
    );
  }

  submit() {

    const formValuesCopy = Object.assign({}, this.itemForm.value);
    this.isSaving = true;
    this._dialogRef.disableClose = true;
    this._Cliente
    .saveupdateCliente(formValuesCopy, this.data.id)
    .toPromise()
    .then(data => {
      this.isSaving = false;
      Swal.fire('Felicidades', data.message, 'success');
      this._dialogRef.close(true);
      })
      .catch(repError => {
        this.isSaving = false;
        Swal.fire('Error', repError.error.message, 'error');
        this._dialogRef.disableClose = false;
      });
  }

  seleccion(event: any) {
    console.log(event.value);
  }

}

