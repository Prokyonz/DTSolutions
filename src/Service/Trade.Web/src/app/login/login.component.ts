import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { SharedService } from '../common/shared.service';
import { AuthService } from '../auth.service';

export class RememberLogin{
  username : string;
  password: string;
  rememberme: string;
}

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})

export class LoginComponent implements OnInit {
  loginForm: FormGroup;
  isLoggedIn = false;
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
=======
  showCompanySelection = false;
>>>>>>> added company selection and css pdate

  constructor(private fb: FormBuilder, private router: Router) {
=======
=======
  showCompanySelection = false;
  rememberMe : boolean = false;  
  RememberLogin: RememberLogin = new RememberLogin;
>>>>>>> Add Company Data On Login
  constructor(private fb: FormBuilder, private router: Router, private shared: SharedService, private authService: AuthService,) {
>>>>>>> Login Module and Add code in API
    this.isLoggedIn = false;
    this.loginForm = fb.group({
      username: ['', Validators.required],
      password: ['', Validators.required],
      rememberMe: [null,null]       
    });
  }

<<<<<<< HEAD
<<<<<<< HEAD
  onLogin() {
<<<<<<< HEAD
      this.router.navigate(['/dashboard']);    
=======
=======
  ngOnInit(): void {
    var data = localStorage.getItem('loginremember');
    if (data != null){
      var loginData = JSON.parse(data);
      if (loginData.rememberme == "true"){
        this.loginForm.get("username")?.setValue(loginData.username);
        this.loginForm.get("password")?.setValue(loginData.password);
        this.rememberMe = true
      }
      else{
        this.rememberMe = false
      }
    }
  }

  

>>>>>>> Add Company Data On Login

  onlogin(){
    if (this.loginForm.valid){      
      this.authService.login(this.loginForm.get("username")?.value, this.loginForm.get("password")?.value)
      .subscribe((response: any) => {
        debugger;
          if (response.success == true){
            if (response.data != null){
<<<<<<< HEAD
              localStorage.setItem("userid",response.data.id);
              this.router.navigate(['/dashboard']);
=======
              localStorage.setItem("userid", response.data.id);
                if (this.rememberMe){      
                  this.RememberLogin.username = this.loginForm.get("username")?.value;
                  this.RememberLogin.password = this.loginForm.get("password")?.value;
                  this.RememberLogin.rememberme = this.rememberMe.toString(); 
                  localStorage.setItem("loginremember", JSON.stringify(this.RememberLogin))
                }
                else{
                  localStorage.removeItem("loginremember")                 
                }
                this.showCompanySelection = true;
              //this.router.navigate(['/dashboard']);
>>>>>>> Add Company Data On Login
            }
          }
          else{
            localStorage.removeItem("userid");
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
