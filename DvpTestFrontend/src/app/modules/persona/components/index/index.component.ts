import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatTableDataSource } from '@angular/material/table';
import { ToastrService } from 'ngx-toastr';
import { HttpService } from 'src/app/services/http.service';
import { FormComponent } from '../form/form.component';

@Component({
  selector: 'app-index',
  templateUrl: './index.component.html',
  styleUrls: ['./index.component.scss']
})
export class IndexComponent implements OnInit {

  displayedColumns: string[] = ['Identificador', 'Nombres', 'Apellidos', 'Email', 'TipoIdentificacion','FechaDeCreacion','IdentificacionTipo','NombresCompletos','acciones'];
  dataSource = new MatTableDataSource<any>([]);

  cantidadTotal = 0;
  cantidadPorPagina = 10;
  numeroDePagina = 0;
  opcionesDePaginado: number[] = [1,5,10,25,100];

  textoBusqueda = '';

  constructor(
    private httpService: HttpService,
    private toastr: ToastrService,
    public dialog: MatDialog
  ) {}

  ngOnInit(): void {
    this.LeerTodo();
  }
  
  LeerTodo() {
    this.httpService.LeerTodo(this.cantidadPorPagina, this.numeroDePagina, this.textoBusqueda)
      .subscribe((respuesta: any) => {
        this.dataSource.data = respuesta.datos.elemento;
        this.cantidadTotal = respuesta.datos.cantidadTotal;
      });
  }

  cambiarPagina(event: any) {
    this.cantidadPorPagina = event.pageSize;
    this.numeroDePagina = event.pageIndex;

    this.LeerTodo();
  }

  eliminar(personaId: string) {
    let confirmacion = confirm('Está seguro/a que desea eliminar el elemento?');

    if (confirmacion) {
      let ids = [personaId];

      this.httpService.Eliminar(ids)
        .subscribe((respuesta: any) => {
          this.toastr.success('Elemento <b>eliminado</b> satisfactoriamente','Confirmación');
          this.LeerTodo();
        });
    }
  }

  crearPersona() {
    const dialogRef = this.dialog.open(FormComponent, {
      disableClose: true,
      autoFocus: true,
      closeOnNavigation: false,
      position: { top: '30px' },
      width: '700px',
      data: {
        tipo: 'CREAR'
      }
  
    });

    dialogRef.afterClosed().subscribe(result => {
      if (result) {
        this.LeerTodo(); 
      }
    });
  }

}
