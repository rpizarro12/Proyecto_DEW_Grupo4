import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-registro',
  templateUrl: './registro.component.html',
  styleUrls: ['./registro.component.scss']
})
export class RegistroComponent implements OnInit {

  registerForm = this.reg.group({
    nombres: ['',Validators.required],
    apellidopaterno: ['',Validators.required],
    apellidomaterno: ['',Validators.required],
    loginusuario: ['', [Validators.required, Validators.email]],
    passwordusuario: ['',Validators.required],
    documentoidentidad: ['',Validators.required],
    idperfil: [0],
    usuarioCrea: [0]
    //acepta1: ['',Validators.required], //acepta uso de datos personales
    //acepta2: [''], //acepta suscripcion al boletin
    //acepta3: ['',Validators.required] //acepta terminos y condiciones y politicas de privacidad
  })

  constructor(
    private reg: FormBuilder,
    private readonly us: UserService,
    private router: Router
    ) { }


  __insert(data: any){
    //const token = sessionStorage.getItem("token");
    //const header = { Authorization: 'Bearer ' + token };
    //alert(token);

    this.us.__insert(data).subscribe((rest: any) => {
      if(rest.issuccess) {
        alert("Usuario creado");
        this.router.navigate(['login']);
      } else {
        alert(rest.errormessage);
      }
    })
  }

  __onSubmit() {
    if (this.registerForm.valid) {
      console.log(this.registerForm.value);
      this.__insert(this.registerForm.value);
    } else {
      alert("Debe completar los campos obligatorios (Tienen un *).")
    }
  }
  ngOnInit(): void {
  }

}
