import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';

@Component({
  selector: 'app-contactanos',
  templateUrl: './contactanos.component.html',
  styleUrls: ['./contactanos.component.scss']
})
export class ContactanosComponent implements OnInit {


  contactForm = this.form.group({
    person: this.form.group({
      nombres: ['',Validators.required],
      apellidos: ['',Validators.required]
    }),
    email: ['', [Validators.required, Validators.email]],
    asunto: ['',Validators.required],
    mensaje: ['',Validators.required]
  })

  constructor(private form: FormBuilder) { }

  __onSubmit() {
    if (this.contactForm.valid) {
      console.log(this.contactForm.value);
    } else {
      alert("Error en formulario, hay campos vacíos.")
    }
  }
  ngOnInit(): void {
  }

}