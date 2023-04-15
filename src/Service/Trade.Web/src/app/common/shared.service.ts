import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { throwError } from 'rxjs';
import { catchError, map } from 'rxjs/operators';
//import {config} from '../../assets/config/app.config';

const apiUrl : string = "https://localhost:44359/api/";
//const apiKey = config.apiKey;
@Injectable({
    providedIn: 'root' // or specify a module where it should be provided
  })
export class SharedService {

    constructor(private httpClient: HttpClient) { }

    customGetApi(api: string): Observable<ApiResponse> {
        return this.httpClient.get<any>(apiUrl + api).pipe(map(t => t), catchError(err => throwError(err)));
    }


    customPostApi(api: string, data: any): Observable<ApiResponse> {
        return this.httpClient.post<any>(apiUrl + api, data).pipe(map(t => t),catchError(err => throwError(err)));
    }
}

export class ApiResponse {
    success: boolean = false;
    statusCode: number;
    sessage: string = '';
    data: any
}