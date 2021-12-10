import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  loginForm = this.lg.group({
    loginusuario: ['', [Validators.required, Validators.email]],
    passwordusuario: ['', Validators.required]
  });

  constructor(
    private lg: FormBuilder,
    private readonly us: UserService,
    private router: Router
    ) { }

  __login(data: any) {
    this.us.__login(data).subscribe((rest: any) => {
      if(rest.issuccess){
        sessionStorage.setItem('token', rest.data.token);
        sessionStorage.setItem('user', rest.data.nombres + ' ' + rest.data.apellidopaterno);

        this.router.navigateByUrl('/home',{skipLocationChange: false}).then(() => {
          this.router.navigate(['home']);
          window.location.reload();
        })

      } else {
        alert('Credenciales incorrectas')
      }
    })
  }

  __onSubmit() {
    if (this.loginForm.valid) {
      this.__login(this.loginForm.value);
    } else {
      alert("Email o contraseña no válido")
    }
  }

  ngOnInit(): void {
  }

}