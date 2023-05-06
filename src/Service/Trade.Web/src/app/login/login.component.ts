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
<<<<<<< HEAD
<<<<<<< HEAD
=======
  showCompanySelection = false;
>>>>>>> added company selection and css pdate

  constructor(private fb: FormBuilder, private router: Router) {
=======
  constructor(private fb: FormBuilder, private router: Router, private shared: SharedService, private authService: AuthService,) {
>>>>>>> Login Module and Add code in API
    this.isLoggedIn = false;
    this.loginForm = fb.group({
      username: ['', Validators.required],
      password: ['', Validators.required],
      rememberme: ['', null]
    });
  }

<<<<<<< HEAD
  onLogin() {
<<<<<<< HEAD
      this.router.navigate(['/dashboard']);    
=======

  onlogin(){
    if (this.loginForm.valid){      
      debugger;
      this.authService.login(this.loginForm.get("username")?.value, this.loginForm.get("password")?.value)
      .subscribe((response: any) => {
        debugger;
          if (response.success == true){
            if (response.data != null){
              localStorage.setItem("userid",response.data.id);
              this.router.navigate(['/dashboard']);
            }
          }
          else{
            localStorage.clear();       
          }
      }, (ex: any) => {
      });
    }
>>>>>>> Login Module and Add code in API
=======
      this.showCompanySelection = true;
      //this.router.navigate(['/dashboard']);    
>>>>>>> added company selection and css pdate
  }
}
