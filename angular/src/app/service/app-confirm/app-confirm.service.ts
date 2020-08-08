import { Observable } from 'rxjs';
import { MatDialogRef, MatDialog } from '@angular/material/dialog';
import { Injectable } from '@angular/core';
import { AppComfirmComponent } from './app-confirm.component';

interface confirmData {
  title?: string;
  message?: string;
  showjustification?: boolean;
}

@Injectable()
export class AppConfirmService {

  constructor(private dialog: MatDialog) { }

  public confirm(data: confirmData = {}): Observable<boolean | any> {

    let dialogRef: MatDialogRef<AppComfirmComponent>;

    data.title = data.title || 'Confirmación';
    data.message = data.message || '¿Estás seguro?';
    data.showjustification = data.showjustification || false;

    dialogRef = this.dialog.open(AppComfirmComponent, {
      width: '380px',
      disableClose: true,
      data: {
        title: data.title
        , message: data.message
        , showjustification: data.showjustification
      }
    });

    return dialogRef.afterClosed();
  }
}
