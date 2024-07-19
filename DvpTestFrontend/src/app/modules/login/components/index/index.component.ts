import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { ActivatedRouteSnapshot, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { take } from 'rxjs';
import { HttpService } from 'src/app/services/http.service';

@Component({
  selector: 'app-index',
  templateUrl: './index.component.html',
  styleUrls: ['./index.component.scss'],
})
export class IndexComponent implements OnInit {
  formGroup: FormGroup;
  datos?: string;

  constructor(
    private httpService: HttpService,
    private toastr: ToastrService,
    public dialog: MatDialog,
    private fb: FormBuilder,
    private router: Router
  ) {
    this.formGroup = this.fb.group({
      NombreUsuario: ['', [Validators.required]],
      Password: ['', [Validators.required]],
    });
  }

  ngOnInit(): void {}

  async onSubmit(): Promise<void> {
    if (this.formGroup.valid) {
      let credenciales = {
        NombreUsuario: this.formGroup.value.NombreUsuario,
        Password: this.formGroup.value.Password,
      };

      this.httpService
        .iniciarSesion(credenciales)
        .pipe(take(1))
        .subscribe({
          next: (response) => {
            this.datos = response?.datos;
            localStorage.setItem('currentUser', this.datos ?? '');

            if (this.datos) {
              this.router.navigate(['']);
            }
          },
          error: (error) => {
            this.toastr.error(
              'El nombre de usuario o password no son válidos',
              'Error'
            );
            console.log({ error });
          },
        });
    }
  }
}
