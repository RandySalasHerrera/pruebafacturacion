import { Injectable, Injector } from '@angular/core';
import { URL_SERVICIOS } from 'src/app/config/config';
import { HttpClient, HttpResponse, HttpHeaders } from '@angular/common/http';
import { Router } from '@angular/router';
import 'rxjs/Rx';
import { Observable } from 'rxjs/Rx';

@Injectable()
export class FacturaService {

  constructor(
    public http: HttpClient,
    public router: Router
  ) {
  }

  getFacturaList(filter: any) {
    let url = URL_SERVICIOS + 'factura';
    return this.http.get(url)
      .catch(error => {
        return Observable.throw(error);
      })
      .map((resp: any) => {
        const data = resp;
        return data;
      });
  }

  saveupdateFactura(Factura: any, Id?: string) {
    let url = URL_SERVICIOS + 'factura';
    if (Id) {
      url += '/' + Id;
    } else {
      url += '/';
    }
    return this.http
      .post(url, Factura)
      .catch(error => {
        return Observable.throw(error);
      })
      .map((resp: any) => {
        const data = resp;
        console.log(data);
        return data;
      });
  }

  getFacturaById(id: string) {
    const url = URL_SERVICIOS + 'factura/' + id;
    return this.http.get(url)
      .catch(error => {
        return Observable.throw(error);
      })
      .map((resp: any) => {
        const data = resp;
        return data;
      });
  }

  deleteFactura(Factura: any, id: string) {
    const url = URL_SERVICIOS + 'factura/' + id;
    return this.http.delete(url, Factura)
      .catch(error => {
        return Observable.throw(error);
      })
      .map((resp: any) => {
        return resp;
      });
  }


}
