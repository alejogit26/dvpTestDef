import { Component, Inject, inject, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { ToastrService } from 'ngx-toastr';
import { HttpService } from 'src/app/services/http.service';

@Component({
  selector: 'app-form',
  templateUrl: './form.component.html',
  styleUrls: ['./form.component.scss']
})
export class FormComponent implements OnInit {

  formGroup!: FormGroup;
  tipoIdentificacionOptions = ['','CE', 'TI', 'CC'];

  constructor(
    @Inject(MAT_DIALOG_DATA) public data: any, 
    public dialogRef: MatDialogRef<FormComponent>,
    private fb: FormBuilder,
    private httpService: HttpService, 
    private toastr: ToastrService
  ){}

  ngOnInit(): void {
    this.initForm();
  }

  cancelar(){
    this.dialogRef.close();
  }

  guardar(): void{
    if (this.formGroup.valid) {
      const personaData = this.formGroup.value;

      this.httpService.CrearPersona(personaData).subscribe(
        (response: any) => {
          this.toastr.success('Persona creada exitosamente', 'Éxito');
          this.dialogRef.close(true); 
        },
        (error: any) => {
          console.error('Error al crear persona', error);
          this.toastr.error('Error al crear persona', 'Error');
        }
      );
    } else {
      this.formGroup.markAllAsTouched();
      this.toastr.warning('Por favor complete todos los campos', 'Advertencia');
    }
  }

  initForm(){
    this.formGroup = this.fb.group({      
      Nombres: [{ value: null, disabled: false}, [Validators.required]],
      Apellidos: [{ value: null, disabled: false }, [Validators.required]],
      NumeroDeIdentificacion: [null, [Validators.required, Validators.pattern('^[0-9]*$')]],
      Email: [null, [Validators.required, Validators.email]], 
      TipoIdentificacion: [null, Validators.required], 
      FechaDeCreacion: [{ value: null, disabled: false }],      
    });
  }
}
