import { BrowserModule } from '@angular/platform-browser';
import { NgModule, NO_ERRORS_SCHEMA, CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { AppRoutingModule } from './app-routing.module';

// RUTAS
import { APP_ROUTES } from './app.routes';

// MODULOS
import { PagesModules } from './pages/pages.modules';

// COMPONENTES
import { AppComponent } from './app.component';
import { ServiceModule } from './service/service.module';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { HTTP_INTERCEPTORS } from '@angular/common/http';
@NgModule({
  declarations: [
    AppComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    APP_ROUTES,
    PagesModules,
    ServiceModule,
    BrowserAnimationsModule,
  ],
  bootstrap: [AppComponent],
  schemas: [
      CUSTOM_ELEMENTS_SCHEMA,
      NO_ERRORS_SCHEMA
  ]
})
export class AppModule { }
