import { Routes } from "@angular/router";
import { IndexComponent } from "./components/index/index.component";

export const usuarioRoutes: Routes = [
    {
        path: 'usuario/index',
        component: IndexComponent,
        loadChildren: () => import('./usuario.module').then(m => m.usuarioModule)
    }
];