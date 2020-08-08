import { Injectable, Injector } from '@angular/core';
import { URL_SERVICIOS } from 'src/app/config/config';
import { HttpClient, HttpResponse, HttpHeaders } from '@angular/common/http';
import { Router } from '@angular/router';
import 'rxjs/Rx';
import { Observable } from 'rxjs/Rx';

@Injectable()
export class DetalleService {

  constructor(
    public http: HttpClient,
    public router: Router
  ) {
  }

  getDetalleList(filter: any) {
    let url = URL_SERVICIOS + 'detalle';
    return this.http.get(url)
      .catch(error => {
        return Observable.throw(error);
      })
      .map((resp: any) => {
        const data = resp;
        return data;
      });
  }

  saveupdateDetalle(Detalle: any, Id?: string) {
    let url = URL_SERVICIOS + 'detalle';
    if (Id) {
      url += '/' + Id;
    } else {
      url += '/';
    }
    return this.http
      .post(url, Detalle)
      .catch(error => {
        return Observable.throw(error);
      })
      .map((resp: any) => {
        const data = resp;
        console.log(data);
        return data;
      });
  }

  getDetalleById(id: string) {
    const url = URL_SERVICIOS + 'detalle/' + id;
    return this.http.get(url)
      .catch(error => {
        return Observable.throw(error);
      })
      .map((resp: any) => {
        const data = resp;
        return data;
      });
  }

  deleteDetalle(Detalle: any, id: string) {
    const url = URL_SERVICIOS + 'detalle/' + id;
    return this.http.delete(url, Detalle)
      .catch(error => {
        return Observable.throw(error);
      })
      .map((resp: any) => {
        return resp;
      });
  }


}
