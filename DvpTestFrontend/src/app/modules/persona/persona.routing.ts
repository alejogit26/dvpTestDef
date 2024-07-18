import { Routes } from "@angular/router";
import { IndexComponent } from "./components/index/index.component";

export const personaRoutes: Routes = [
    {
        path: 'persona/index',
        component: IndexComponent,
        loadChildren: () => import('./persona.module').then(m => m.personaModule)
    }
];