import { Component } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent {
  loginForm: FormGroup;
  isLoggedIn = false;

  constructor(private fb: FormBuilder, private router: Router) {
    this.isLoggedIn = false;
    this.loginForm = fb.group({
      username: ['', null],
      password: ['', null],
      rememberme: ['', null]
    });
  }

  onLogin() {
      this.router.navigate(['/dashboard']);    
  }
}
