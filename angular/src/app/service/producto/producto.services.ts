import { Injectable, Injector } from '@angular/core';
import { URL_SERVICIOS } from 'src/app/config/config';
import { HttpClient, HttpResponse, HttpHeaders } from '@angular/common/http';
import { Router } from '@angular/router';
import 'rxjs/Rx';
import { Observable } from 'rxjs/Rx';

@Injectable()
export class ProductoService {

  constructor(
    public http: HttpClient,
    public router: Router
  ) {
  }

  getProductoList(filter: any) {
    let url = URL_SERVICIOS + 'producto';
    return this.http.get(url)
      .catch(error => {
        return Observable.throw(error);
      })
      .map((resp: any) => {
        const data = resp;
        return data;
      });
  }

  saveupdateProducto(Producto: any, Id?: string) {
    let url = URL_SERVICIOS + 'producto';
    if (Id) {
      url += '/' + Id;
    } else {
      url += '/';
    }
    return this.http
      .post(url, Producto)
      .catch(error => {
        return Observable.throw(error);
      })
      .map((resp: any) => {
        const data = resp;
        console.log(data);
        return data;
      });
  }

  getProductoById(id: string) {
    const url = URL_SERVICIOS + 'producto/' + id;
    return this.http.get(url)
      .catch(error => {
        return Observable.throw(error);
      })
      .map((resp: any) => {
        const data = resp;
        return data;
      });
  }

  deleteProducto(Producto: any, id: string) {
    const url = URL_SERVICIOS + 'producto/' + id;
    return this.http.delete(url, Producto)
      .catch(error => {
        return Observable.throw(error);
      })
      .map((resp: any) => {
        return resp;
      });
  }


}
