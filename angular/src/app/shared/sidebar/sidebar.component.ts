import { SidebarService } from './../../service/share/sidebar.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-sidebar',
  templateUrl: './sidebar.component.html',
  styles: []
})
export class SidebarComponent implements OnInit {


  public usuarioJson: any;
  public mostrarMenu: any[] = [];
  constructor(
    public _sidebarService: SidebarService,
  ) { }

  ngOnInit() {
    this.mostrarMenu = this._sidebarService.menuadmin;
  }

}
