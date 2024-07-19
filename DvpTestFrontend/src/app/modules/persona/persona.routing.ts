import { Routes } from "@angular/router";
import { IndexComponent } from "./components/index/index.component";
import { AuthGuard } from "src/app/guards/guard";

export const personaRoutes: Routes = [
    {
        path: 'persona/index',
        canActivate: [AuthGuard],
        component: IndexComponent,
        loadChildren: () => import('./persona.module').then(m => m.personaModule)
    }
];