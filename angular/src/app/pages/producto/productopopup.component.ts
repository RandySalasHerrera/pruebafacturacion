import { OnInit, Inject, Component, ViewChild } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';

import Swal from 'sweetalert2';
import { ProductoService } from 'src/app/service/producto/producto.services';
@Component({
  selector: 'app-productopopup',
  templateUrl: './productopopup.component.html',
  styles: []
})
export class ProductopopupComponent implements OnInit {

  public itemForm: FormGroup;
  public isSaving = false;


  constructor(
    @Inject(MAT_DIALOG_DATA) public data: any,
    public _dialogRef: MatDialogRef<ProductopopupComponent>,
    private fb: FormBuilder,
    private _Producto: ProductoService

  ) {

  }

  ngOnInit() {
    this.buildItemForm(this.data.payload !== undefined ? this.data.payload : this.data.payload);
  }

  buildItemForm(Producto: any) {
    this.itemForm = this.fb.group(
      {
        nombre: [Producto.nombre || null, Validators.required],
        descripcion: [Producto.descripcion || null, Validators.required],
        precio: [Producto.precio || null, Validators.required],
        cantidad: [Producto.cantidad || null, Validators.required],
        fecha: [Producto.fecha || null, Validators.required],
      }
    );
  }

  submit() {

    const formValuesCopy = Object.assign({}, this.itemForm.value);
    this.isSaving = true;
    this._dialogRef.disableClose = true;
    this._Producto
    .saveupdateProducto(formValuesCopy, this.data.id)
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

