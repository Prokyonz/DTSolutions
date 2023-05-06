import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { SharedService } from '../common/shared.service';
import { AuthService } from '../auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent {
  loginForm: FormGroup;
    isLoggedIn = false;
    showCompanySelection = false;
  constructor(private fb: FormBuilder, private router: Router, private shared: SharedService, private authService: AuthService,) {
    this.isLoggedIn = false;
    this.loginForm = fb.group({
      username: ['', Validators.required],
      password: ['', Validators.required],
      rememberme: ['', null]
    });
  }


  onLogin(){
    if (this.loginForm.valid){      
      debugger;
      this.authService.login(this.loginForm.get("username")?.value, this.loginForm.get("password")?.value)
      .subscribe((response: any) => {
        debugger;
          if (response.success == true){
            if (response.data != null){
                localStorage.setItem("userid", response.data.id);
                this.showCompanySelection = true;
              //this.router.navigate(['/dashboard']);
            }
          }
          else{
            localStorage.clear();       
          }
      }, (ex: any) => {
      });
    }
  }
}
