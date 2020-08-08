import { Page404Component } from './shared/page404/page404.component';
import { RouterModule, Routes } from '@angular/router';

const appRoutes: Routes = [
  { path: '**', component: Page404Component },
];

export const APP_ROUTES = RouterModule.forRoot(appRoutes, { useHash: true });
