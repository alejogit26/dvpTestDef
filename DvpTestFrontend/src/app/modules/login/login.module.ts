import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { IndexComponent } from './components/index/index.component';
import { GlobalModule } from '../global/global.module';
import { RouterModule } from '@angular/router';
import { loginRoutes } from './login.routing';

@NgModule({
  declarations: [
    IndexComponent
  ],
  imports: [
    CommonModule,
    GlobalModule,
    RouterModule.forChild(loginRoutes)
  ]
})
export class loginModule { }
