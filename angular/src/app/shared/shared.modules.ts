import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { HeaderComponent } from './header/header.component';
import { BreadcrumbsComponent } from './breadcrumbs/breadcrumbs.component';
import { NgModule } from '@angular/core';
import { Page404Component } from './page404/page404.component';
import { SidebarComponent } from './sidebar/sidebar.component';

@NgModule({
  imports: [
    RouterModule,
    CommonModule
  ],
  declarations: [
  BreadcrumbsComponent,
  HeaderComponent,
  Page404Component,
  SidebarComponent
  ],
  exports: [
    BreadcrumbsComponent,
    HeaderComponent,
    Page404Component,
    SidebarComponent
  ]
})

export class ShareModule { }
