import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { MenuGlobalComponent } from './modules/global/components/menu-global/menu-global.component';
import { AuthGuard } from './guards/guard';

const routes: Routes = [
  {
    path: '',
    canActivate: [AuthGuard],
    component: MenuGlobalComponent,
    loadChildren: () => import('./rutas.module').then(m => m.RutasModule)
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
