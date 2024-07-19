import { Routes } from "@angular/router";
import { IndexComponent } from "./components/index/index.component";
import { AuthGuard } from "src/app/guards/guard";

export const globalRoutes: Routes = [
    {
        path: '',
        canActivate: [AuthGuard],
        component: IndexComponent,
        loadChildren: () => import('./global.module').then(m => m.GlobalModule)
    }
];