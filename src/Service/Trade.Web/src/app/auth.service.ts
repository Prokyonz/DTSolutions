import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Router } from "@angular/router";
import { Observable } from "rxjs";
import { map } from 'rxjs/operators';
import { Injectable } from '@angular/core';
import { environment } from "./environments";

const apiUrl : string = environment.apiURL + "Auth/login";

@Injectable({
    providedIn: 'root' // or specify a module where it should be provided
  })



export class AuthService {
    constructor(private http: HttpClient,private router: Router){
        
    }
    private isUserLoggedIn = this.hasToken();

    public login(user: string, password: string): Observable<any> {

        const data = {
            UserName: user,
            Password: password
        };

        return this.http.post<any>(apiUrl , data)
            .pipe((data: any) => {
            this.isUserLoggedIn = true;
            //localStorage.setItem('AuthorizeData', JSON.stringify(data));
            return data;
        });
    }

    private hasToken() {
        return !!localStorage.getItem('AuthorizeData');
    }

    public get isAuthenticated(): boolean {
        return (this.isUserLoggedIn && this.hasToken());
    }

    logOut(anyParam = ''): any {
        try {
          localStorage.removeItem('AuthorizeData');
            this.router.navigate(['/login']);
        }
        catch (error) {
          console.log(error);
        }
        finally {
        }
      }
}