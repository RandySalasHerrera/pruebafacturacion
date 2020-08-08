import { Injectable, Injector } from '@angular/core';
import { URL_SERVICIOS } from 'src/app/config/config';
import { HttpClient, HttpResponse, HttpHeaders } from '@angular/common/http';
import { Router } from '@angular/router';
import 'rxjs/Rx';
import { Observable } from 'rxjs/Rx';

@Injectable()
export class ClienteService {

  constructor(
    public http: HttpClient,
    public router: Router
  ) {
  }

  getClienteList(filter: any) {
    let url = URL_SERVICIOS + 'cliente';
    return this.http.get(url)
      .catch(error => {
        return Observable.throw(error);
      })
      .map((resp: any) => {
        const data = resp;
        return data;
      });
  }

  saveupdateCliente(Cliente: any, Id?: string) {
    let url = URL_SERVICIOS + 'cliente';
    if (Id) {
      url += '/' + Id;
    } else {
      url += '/';
    }
    return this.http
      .post(url, Cliente)
      .catch(error => {
        return Observable.throw(error);
      })
      .map((resp: any) => {
        const data = resp;
        console.log(data);
        return data;
      });
  }

  getClienteById(id: string) {
    const url = URL_SERVICIOS + 'cliente/' + id;
    return this.http.get(url)
      .catch(error => {
        return Observable.throw(error);
      })
      .map((resp: any) => {
        const data = resp;
        return data;
      });
  }

  deleteCliente(Cliente: any, id: string) {
    const url = URL_SERVICIOS + 'cliente/' + id;
    return this.http.delete(url, Cliente)
      .catch(error => {
        return Observable.throw(error);
      })
      .map((resp: any) => {
        return resp;
      });
  }


}
