import { OnInit, Inject, Component, ViewChild } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import Swal from 'sweetalert2';
import { FacturaService } from 'src/app/service/factura/factura.services';

@Component({
  selector: 'app-facturapopup',
  templateUrl: './facturapopup.component.html',
  styles: []
})
export class FacturapopupComponent implements OnInit {

  public itemForm: FormGroup;
  public isSaving = false;


  constructor(
    @Inject(MAT_DIALOG_DATA) public data: any,
    public _dialogRef: MatDialogRef<FacturapopupComponent>,
    private fb: FormBuilder,
    private _Factura: FacturaService

  ) {

  }

  ngOnInit() {
    this.buildItemForm(this.data.payload !== undefined ? this.data.payload : this.data.payload);
  }

  buildItemForm(Factura: any) {
    this.itemForm = this.fb.group(
      {
        clienteid: [Factura.clienteid || null, Validators.required],
        total: [Factura.total || null, Validators.required],
        fecha: [Factura.fecha || null, Validators.required],
      }
    );
  }

  submit() {

    const formValuesCopy = Object.assign({}, this.itemForm.value);
    this.isSaving = true;
    this._dialogRef.disableClose = true;
    this._Factura
    .saveupdateFactura(formValuesCopy, this.data.id)
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

