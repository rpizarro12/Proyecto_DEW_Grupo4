import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  loginForm = this.lg.group({
    email: ['', [Validators.required, Validators.email]],
    password: ['', Validators.required]
  });

  constructor(private lg: FormBuilder) { }

  __onSubmit() {
    if (this.loginForm.valid) {
      console.log(this.loginForm.value);
    } else {
      alert("Email o contraseña no válido")
    }
  }

  ngOnInit(): void {
  }

}