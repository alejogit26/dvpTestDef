import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { IndexComponent } from './components/index/index.component';
import { FormComponent } from './components/form/form.component';
import { GlobalModule } from '../global/global.module';
import { RouterModule } from '@angular/router';
import { usuarioRoutes } from './usuario.routing';

@NgModule({
  declarations: [
    IndexComponent,
    FormComponent
  ],
  imports: [
    CommonModule,
    GlobalModule,
    RouterModule.forChild(usuarioRoutes)
  ]
})
export class usuarioModule { }
