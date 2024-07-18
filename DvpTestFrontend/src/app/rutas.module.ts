import { NgModule } from "@angular/core";
import { RouterModule } from "@angular/router";
import { globalRoutes } from "./modules/global/global.routing";
import { personaRoutes } from "./modules/persona/persona.routing";
import { usuarioRoutes } from "./modules/usuario/usuario.routing";
import { loginRoutes } from "./modules/login/login.routing";


@NgModule({
    imports: [RouterModule.forChild([
        ...globalRoutes,
        ...personaRoutes,
        ...usuarioRoutes,
        ...loginRoutes
    ])],
    exports: [RouterModule]
})
export class RutasModule { }