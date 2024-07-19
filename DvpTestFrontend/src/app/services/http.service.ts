import { HttpClient, HttpHeaders, HttpParams } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";


@Injectable({
    providedIn: "root"
})
export class HttpService {

    
    constructor(
        private httpCliente: HttpClient
    ){}

    LeerTodo(cantidad: number,pagina: number, textoBusqueda: string) {
        let parametros = new HttpParams();

        parametros = parametros.append('cantidad', cantidad);
        parametros = parametros.append('pagina', pagina);
        parametros = parametros.append('textoBusqueda', textoBusqueda);

        return this.httpCliente.get('http://localhost:51395/api/persona',{ params: parametros });
    }

    CrearPersona(personaData: any) {
        return this.httpCliente.post('http://localhost:51395/api/persona', personaData);
    }


    Eliminar(ids: string[]) {
        const option = {
            headers: new HttpHeaders({
                'Content-Type': 'application/json'
            }),
            body: ids
        };
        return this.httpCliente.delete('http://localhost:51395/api/persona', option);
    }

    
    LeerTodosUsuarios(cantidad: number, pagina: number, textoBusqueda: string) {
        let parametros = new HttpParams();

        parametros = parametros.append('cantidad', cantidad);
        parametros = parametros.append('pagina', pagina);
        parametros = parametros.append('textoBusqueda', textoBusqueda);

        return this.httpCliente.get('http://localhost:51395/api/usuario', { params: parametros });
    }

    CrearUsuario(usuarioData: any) {
        return this.httpCliente.post('http://localhost:51395/api/usuario', usuarioData);
    }

    EliminarUsuarios(ids: string[]) {
        const option = {
            headers: new HttpHeaders({
                'Content-Type': 'application/json'
            }),
            body: ids
        };
        return this.httpCliente.delete('http://localhost:51395/api/usuario', option);
    }

    iniciarSesion(credentials: any): Observable<any> {
        return this.httpCliente.post('http://localhost:51395/api/usuario/iniciarsesion', credentials);
    }

}