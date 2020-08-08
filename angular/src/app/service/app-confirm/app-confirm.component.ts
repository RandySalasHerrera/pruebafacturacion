import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Inject, Component} from '@angular/core';

@Component({
  selector: 'app-confirm',
  templateUrl: './app-confirm.component.html',
})
export class AppComfirmComponent {

  public justificacion: string = "";

  constructor(public dialogRef: MatDialogRef<AppComfirmComponent>, @Inject(MAT_DIALOG_DATA) public data: any
  ) { }
}
