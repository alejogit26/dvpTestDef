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

  formGroup!: FormGroup

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
      const usuarioData = this.formGroup.value;

      this.httpService.CrearUsuario(usuarioData).subscribe(
        (response: any) => {
          this.toastr.success('Usuario creado exitosamente', 'Éxito');
          this.dialogRef.close(true);
        },
        (error: any) => {
          console.error('Error al crear usuario', error);
          this.toastr.error('Error al crear usuario', 'Error');
        }
      );
    } else {
      this.toastr.warning('Por favor complete todos los campos', 'Advertencia');
    }
  }

  initForm(){
    this.formGroup = this.fb.group({      
      NombreUsuario: [{ value: null, disabled: false}, [Validators.required]],
      Pass: [{ value: null, disabled: false }, [Validators.required]],
      FechaDeCreacion: [{ value: null, disabled: false }, [Validators.required]],      
    });
  }
}
