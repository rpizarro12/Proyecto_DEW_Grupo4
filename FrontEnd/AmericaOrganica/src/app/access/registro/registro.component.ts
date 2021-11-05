import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';

@Component({
  selector: 'app-registro',
  templateUrl: './registro.component.html',
  styleUrls: ['./registro.component.scss']
})
export class RegistroComponent implements OnInit {

  registerForm = this.reg.group({
    person: this.reg.group({
      nombres: ['',Validators.required],
      apellidos: ['',Validators.required],
      dni: ['',Validators.required]
    }),
    email: ['', [Validators.required, Validators.email]],
    password: ['',Validators.required],
    acepta1: ['',Validators.required], //acepta uso de datos personales
    acepta2: [''], //acepta suscripcion al boletin
    acepta3: ['',Validators.required] //acepta terminos y condiciones y politicas de privacidad
  })

  constructor(private reg: FormBuilder) { }

  __onSubmit() {
    if (this.registerForm.valid) {
      console.log(this.registerForm.value);
    } else {
      alert("Debe completar los campos obligatorios (Tienen un *).")
    }
  }
  ngOnInit(): void {
  }

}
