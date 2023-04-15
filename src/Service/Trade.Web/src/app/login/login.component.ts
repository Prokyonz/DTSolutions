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
      this.router.navigate(['/dashboard']);    
=======

  onlogin(){
    if (this.loginForm.valid){
      // const data = {
      //   UserName: this.loginForm.get("username")?.value,
      //   Password: this.loginForm.get("password")?.value
      // };
      // this.shared.customPostApi("auth/login",data).subscribe((t) => {
      //   if (t.status == true){
      //     this.router.navigate(['/dashboard']);
      //   }
      // });      

      debugger;
      this.authService.login(this.loginForm.get("username")?.value, this.loginForm.get("password")?.value)
      .subscribe((data: any) => {
        debugger;
        if (data.success == true){
          this.router.navigate(['/dashboard']);
        }
        //this.router.navigateByUrl('/');
        
      }, (ex: any) => {
      });

    }
>>>>>>> Login Module and Add code in API
  }
}
