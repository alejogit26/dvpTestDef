import { Routes } from "@angular/router";
import { IndexComponent } from "./components/index/index.component";
import { AuthGuard } from "src/app/guards/guard";

export const usuarioRoutes: Routes = [
    {
        path: 'usuario/index',
        canActivate: [AuthGuard],
        component: IndexComponent,
        loadChildren: () => import('./usuario.module').then(m => m.usuarioModule)
    }
];