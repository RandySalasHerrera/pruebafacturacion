import { Injectable, Injector } from '@angular/core';
import { URL_SERVICIOS } from 'src/app/config/config';
import { HttpClient, HttpResponse, HttpHeaders } from '@angular/common/http';
import { Router } from '@angular/router';
import 'rxjs/Rx';
import { Observable } from 'rxjs/Rx';

@Injectable()
export class InformeService {

  constructor(
    public http: HttpClient,
    public router: Router
  ) {
  }

  getclientesnomayores() {
    let url = URL_SERVICIOS + 'informe/clientesnomayores';
    return this.http.get(url)
      .catch(error => {
        return Observable.throw(error);
      })
      .map((resp: any) => {
        const data = resp;
        return data;
      });
  }

  getclientesultimacompra() {
    let url = URL_SERVICIOS + 'informe/clientesultimacompra';
    return this.http.get(url)
      .catch(error => {
        return Observable.throw(error);
      })
      .map((resp: any) => {
        const data = resp;
        return data;
      });
  }

  getalertaproducto() {
    let url = URL_SERVICIOS + 'informe/alertaproducto';
    return this.http.get(url)
      .catch(error => {
        return Observable.throw(error);
      })
      .map((resp: any) => {
        const data = resp;
        return data;
      });
  }

  getvalorvendidoproducto() {
    let url = URL_SERVICIOS + 'informe/valorvendidoproducto';
    return this.http.get(url)
      .catch(error => {
        return Observable.throw(error);
      })
      .map((resp: any) => {
        const data = resp;
        return data;
      });
  }


}
