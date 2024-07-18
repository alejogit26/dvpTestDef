import { NgModule } from "@angular/core";
import { RouterModule } from "@angular/router";
import { globalRoutes } from "./modules/global/global.routing";
import { personaRoutes } from "./modules/persona/persona.routing";
import { usuarioRoutes } from "./modules/usuario/usuario.routing";



@NgModule({
    imports: [RouterModule.forChild([
        ...globalRoutes,
        ...personaRoutes,
        ...usuarioRoutes
    ])],
    exports: [RouterModule]
})
export class RutasModule { }