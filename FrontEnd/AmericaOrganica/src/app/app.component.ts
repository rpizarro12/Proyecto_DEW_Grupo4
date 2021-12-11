import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'AmericaOrganica';
  token = sessionStorage.getItem('token');
  user = sessionStorage.getItem('user');
}
