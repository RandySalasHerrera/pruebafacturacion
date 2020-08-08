import { OnInit, Inject, Component, ViewChild } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import Swal from 'sweetalert2';
import { DetalleService } from 'src/app/service/detalle/detalle.services';

@Component({
  selector: 'app-detallepopup',
  templateUrl: './detallepopup.component.html',
  styles: []
})
export class DetallepopupComponent implements OnInit {

  public itemForm: FormGroup;
  public isSaving = false;


  constructor(
    @Inject(MAT_DIALOG_DATA) public data: any,
    public _dialogRef: MatDialogRef<DetallepopupComponent>,
    private fb: FormBuilder,
    private _Detalle: DetalleService

  ) {

  }

  ngOnInit() {
    this.buildItemForm(this.data.payload !== undefined ? this.data.payload : this.data.payload);
  }

  buildItemForm(Detalle: any) {
    this.itemForm = this.fb.group(
      {
        facturaid: [Detalle.facturaid || null, Validators.required],
        productoid: [Detalle.productoid || null, Validators.required],
        cantidad: [Detalle.cantidad || null, Validators.required],
      }
    );
  }

  submit() {

    const formValuesCopy = Object.assign({}, this.itemForm.value);
    this.isSaving = true;
    this._dialogRef.disableClose = true;
    this._Detalle
    .saveupdateDetalle(formValuesCopy, this.data.id)
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

